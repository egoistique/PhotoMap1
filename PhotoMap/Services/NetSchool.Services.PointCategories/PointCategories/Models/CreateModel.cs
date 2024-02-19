using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetSchool.Context.Entities;
using NetSchool.Context;
using NetSchool.Settings;
using FluentValidation;

namespace NetSchool.Services.PointCategories;
public class CreateModel
{
    public string Title { get; set; }

}

public class CreateModelProfile : Profile
{
    public CreateModelProfile()
    {
        CreateMap<CreateModel, PointCategory>();

    }

    public class CreateModelActions : IMappingAction<CreateModel, PointCategory>
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public CreateModelActions(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Process(CreateModel source, PointCategory destination, ResolutionContext context)
        {
            using var db = contextFactory.CreateDbContext();

        }
    }
}

public class CreatePointCategoryModelValidator : AbstractValidator<CreateModel>
{
    public CreatePointCategoryModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(50).WithMessage("Maximum length is 50");
    }
}
