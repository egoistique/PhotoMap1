using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhotoMap.Common.Exceptions;
using PhotoMap.Common.Validator;
using PhotoMap.Context;
using PhotoMap.Context.Entities;
using PhotoMap.Services.Actions;
using PhotoMap.Services.Mailing;

namespace PhotoMap.Services.Points;

public class PointService : IPointService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;
    private readonly IAction action;
    private readonly IModelValidator<CreateModel> createModelValidator;
    private readonly IModelValidator<UpdateModel> updateModelValidator;
    private readonly IMailingService mailingService;

    public PointService(IDbContextFactory<MainDbContext> dbContextFactory,
        IMapper mapper,
        IAction action,
        IModelValidator<CreateModel> createModelValidator,
        IModelValidator<UpdateModel> updateModelValidator,
        IMailingService mailingService
        )
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
        this.action = action;
        this.createModelValidator = createModelValidator;
        this.updateModelValidator = updateModelValidator;
        this.mailingService = mailingService;
    }

    public async Task<IEnumerable<PointModel>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var points = await context.Points
            .Include(x => x.PointCategory)
            .Include(x => x.Feedbacks)
            .Include(x => x.ImagePathes)
            .ToListAsync();

        var result = mapper.Map<IEnumerable<PointModel>>(points);

        return result;
    }

    public async Task<PointModel> GetById(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var point = await context.Points
            .Include(x => x.PointCategory)
            .Include(x => x.Feedbacks)
            .Include(x => x.ImagePathes)
            .FirstOrDefaultAsync(x => x.Uid == id);

        var result = mapper.Map<PointModel>(point);

        return result;
    }

    public async Task<IEnumerable<PointModel>> GetByCategoryId(Guid categoryId)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var points = await context.Points
            .Include(x => x.PointCategory)
            .Include(x => x.Feedbacks)
            .Include(x => x.ImagePathes)
            .Where(x => x.PointCategory.Uid == categoryId) 
            .ToListAsync();

        var result = mapper.Map<IEnumerable<PointModel>>(points);

        return result;
    }


    public async Task<PointModel> Create(CreateModel model)
    {
        await createModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var point = mapper.Map<Point>(model);

        await context.Points.AddAsync(point);

        await context.SaveChangesAsync();

        //await action.PublicatePoint(new PublicatePointModel()
        //{
        //    Id = point.Id,
        //    Title = point.Title,
        //    //Latitude = point.Latitude,
        //    //Longitude = point.Longitude,
        //    Description = point.Description
        //});

        await mailingService.DoMailing(model.Title);

        return mapper.Map<PointModel>(point);
    }

    public async Task Update(Guid id, UpdateModel model)
    {
        await updateModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var point = await context.Points.Where(x => x.Uid == id).FirstOrDefaultAsync();

        point = mapper.Map(model, point);

        context.Points.Update(point);

        await context.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var point = await context.Points.Where(x => x.Uid == id).FirstOrDefaultAsync();

        if (point == null)
            throw new ProcessException($"Point (ID = {id}) not found.");

        context.Points.Remove(point);

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<PointModel>> SearchByName(string query)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var lowerQuery = query.ToLower(); 

        var points = await context.Points
            .Include(x => x.PointCategory)
            .Include(x => x.Feedbacks)
            .Include(x => x.ImagePathes)
            .Where(x => x.Title.ToLower().Contains(lowerQuery)) 
            .ToListAsync();

        var result = mapper.Map<IEnumerable<PointModel>>(points);

        return result;
    }
    public async Task<string> GetPointNameByCoordinates(double latitude, double longitude)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var point = await context.Points.FirstOrDefaultAsync(p => p.Latitude == latitude && p.Longitude == longitude);

        if (point == null)
        {
            
            throw new ProcessException($"Point with coordinates ({latitude}, {longitude}) not found.");
        }

        return point.Title;
    }

}
