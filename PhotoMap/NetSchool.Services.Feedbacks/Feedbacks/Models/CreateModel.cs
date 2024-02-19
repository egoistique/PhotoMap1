using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetSchool.Context.Entities;
using NetSchool.Context;
using NetSchool.Settings;
using FluentValidation;

namespace NetSchool.Services.Feedbacks;
public class CreateModel
{
    public string Title { get; set; }
    public int PointId { get; set; }
    public int Rating { get; set; }

}

public class CreateModelProfile : Profile
{
    public CreateModelProfile()
    {
        CreateMap<CreateModel, Feedback>();

    }

    public class CreateModelActions : IMappingAction<CreateModel, Feedback>
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public CreateModelActions(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Process(CreateModel source, Feedback destination, ResolutionContext context)
        {
            using var db = contextFactory.CreateDbContext();

        }
    }
}

public class CreateFeedbackModelValidator : AbstractValidator<CreateModel>
{
    public CreateFeedbackModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(1000).WithMessage("Maximum length is 50");
        RuleFor(x => x.Rating)
            .NotEmpty().WithMessage("Rating is required")
            ;
    }
}

