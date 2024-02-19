namespace NetSchool.Services.PointCategories;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NetSchool.Common.Validator;
using NetSchool.Context;
using NetSchool.Context.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PointCategoryService : IPointCategoryService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<CreateModel> createModelValidator;


    public PointCategoryService(IDbContextFactory<MainDbContext> dbContextFactory,
        IMapper mapper
        )
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<PointCategoryModel>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var pointCategory = await context.PointCategories            
            .ToListAsync();

        var result = mapper.Map<IEnumerable<PointCategoryModel>>(pointCategory);

        return result;
    }

    public async Task<PointCategoryModel> Create(CreateModel model)
    {
        //await createModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var pointCategory = mapper.Map<PointCategory>(model);

        await context.PointCategories.AddAsync(pointCategory);

        await context.SaveChangesAsync();

        return mapper.Map<PointCategoryModel>(pointCategory);
    }
}



