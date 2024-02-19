using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetSchool.Common.Exceptions;
using NetSchool.Common.Validator;
using NetSchool.Context;
using NetSchool.Context.Entities;
using NetSchool.Services.Actions;

namespace NetSchool.Services.Points;

public class PointService : IPointService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;
    private readonly IAction action;
    private readonly IModelValidator<CreateModel> createModelValidator;
    private readonly IModelValidator<UpdateModel> updateModelValidator;

    public PointService(IDbContextFactory<MainDbContext> dbContextFactory,
        IMapper mapper,
        IAction action,
        IModelValidator<CreateModel> createModelValidator,
        IModelValidator<UpdateModel> updateModelValidator
        )
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
        this.action = action;
        this.createModelValidator = createModelValidator;
        this.updateModelValidator = updateModelValidator;
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
        //    Latitude = point.Latitude,
        //    Longitude = point.Longitude,
        //    Description = point.Description
        //});

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
}
