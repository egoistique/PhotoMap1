namespace NetSchool.Services.Feedbacks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using NetSchool.Common.Exceptions;
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
        IMapper mapper,
        IModelValidator<CreateModel> createModelValidator
        )
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
        this.createModelValidator = createModelValidator;
    }

    public async Task<IEnumerable<FeedbackModel>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var feedback = await context.Feedbacks
            .ToListAsync();

        var result = mapper.Map<IEnumerable<FeedbackModel>>(feedback);

        return result;
    }

    public async Task<FeedbackModel> GetById(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var feedback = await context.Feedbacks
            .FirstOrDefaultAsync(x => x.Uid == id);

        var result = mapper.Map<FeedbackModel>(feedback);

        return result;
    }

    public async Task<FeedbackModel> Create(CreateModel model)
    {
        await createModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        //проблема тут, неормальная модель маппится в фитбек без поинт ид
        var feedback = mapper.Map<Feedback>(model);

        await context.Feedbacks.AddAsync(feedback);

        await context.SaveChangesAsync();

        return mapper.Map<FeedbackModel>(feedback);
    }

    public async Task Delete(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var feedback = await context.Feedbacks.Where(x => x.Uid == id).FirstOrDefaultAsync();

        if (feedback == null)
            throw new ProcessException($"Feedback (ID = {id}) not found.");

        context.Feedbacks.Remove(feedback);

        await context.SaveChangesAsync();
    }
}
