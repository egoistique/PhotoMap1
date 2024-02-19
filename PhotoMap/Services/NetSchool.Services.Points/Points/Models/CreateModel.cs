using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetSchool.Context.Entities;
using NetSchool.Context;
using NetSchool.Settings;
using FluentValidation;

namespace NetSchool.Services.Points;
public class CreateModel
{
    public Guid PointCategoryId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; } // Широта
    public double Longitude { get; set; } // Долгота
}

public class CreateModelProfile : Profile
{
    public CreateModelProfile()
    {
        CreateMap<CreateModel, Point>()
            .ForMember(dest => dest.PointCategoryId, opt => opt.Ignore())
            .AfterMap<CreateModelActions>();
    }

    public class CreateModelActions : IMappingAction<CreateModel, Point>
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public CreateModelActions(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Process(CreateModel source, Point destination, ResolutionContext context)
        {
            using var db = contextFactory.CreateDbContext();

            var pointCategory = db.PointCategories.FirstOrDefault(x => x.Uid == source.PointCategoryId);

            destination.PointCategoryId = pointCategory.Id;
        }
    }
}

public class CreatePointModelValidator : AbstractValidator<CreateModel>
{
    public CreatePointModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.Title).PointTitle();

        RuleFor(x => x.PointCategoryId)
            .NotEmpty().WithMessage("Category is required")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var found = context.PointCategories.Any(a => a.Uid == id);
                return found;
            }).WithMessage("Category not found");

        RuleFor(x => x.Latitude)
            .NotEmpty().WithMessage("Latitude is required");
        
        RuleFor(x => x.Longitude)
            .NotEmpty().WithMessage("Longitude is required");


        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Maximum length is 1000");
    }
}