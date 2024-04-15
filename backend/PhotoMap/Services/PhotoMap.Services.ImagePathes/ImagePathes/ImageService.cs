namespace PhotoMap.Services.ImagePathes;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using PhotoMap.Common.Exceptions;
using PhotoMap.Common.Validator;
using PhotoMap.Context;
using PhotoMap.Context.Entities;
using PhotoMap.Services.ImagePathes;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ImageService : IImageService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<CreateModel> createModelValidator;

    public ImageService(IDbContextFactory<MainDbContext> dbContextFactory,
    IMapper mapper,
    IModelValidator<CreateModel> createModelValidator
    )
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
        this.createModelValidator = createModelValidator;
    }
    public async Task<IEnumerable<ImagePathModel>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var imagePath = await context.ImagePathes
            .ToListAsync();

        var result = mapper.Map<IEnumerable<ImagePathModel>>(imagePath);

        return result;
    }

    public async Task<ImagePathModel> GetById(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var imagePath = await context.ImagePathes
            .ToListAsync();

        var result = mapper.Map<ImagePathModel>(imagePath);

        return result;
    }

    public async Task<ImagePathModel> Create(CreateModel model)
    {
        await createModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var imagePath = mapper.Map<ImagePath>(model);

        await context.ImagePathes.AddAsync(imagePath);

        await context.SaveChangesAsync();

        return mapper.Map<ImagePathModel>(imagePath);
    }


    public async Task Delete(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var imagePath = await context.ImagePathes.Where(x => x.Uid == id).FirstOrDefaultAsync();

        if (imagePath == null)
            throw new ProcessException($"Image Path (ID = {id}) not found.");

        context.ImagePathes.Remove(imagePath);

        await context.SaveChangesAsync();
    }
}
