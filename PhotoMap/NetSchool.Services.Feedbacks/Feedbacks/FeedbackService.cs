namespace NetSchool.Services.Feedbacks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NetSchool.Common.Validator;
using NetSchool.Context;
using NetSchool.Context.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public class FeedbackService : IFeedbackService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<CreateModel> createModelValidator;


    public FeedbackService(IDbContextFactory<MainDbContext> dbContextFactory,
        IMapper mapper
        )
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<FeedbackModel>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var feedback = await context.Feedbacks
            .ToListAsync();

        var result = mapper.Map<IEnumerable<FeedbackModel>>(feedback);

        return result;
    }

    public async Task<FeedbackModel> Create(CreateModel model)
    {
        //await createModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var feedback = mapper.Map<Feedback>(model);

        await context.Feedbacks.AddAsync(feedback);

        await context.SaveChangesAsync();

        return mapper.Map<FeedbackModel>(feedback);
    }
}
