using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NetSchool.Context.Entities;
using NetSchool.Context;
using NetSchool.Settings;
using FluentValidation;

namespace NetSchool.Services.Feedbacks;
public class CreateModel
{
    public Guid PointId { get; set; }
    public string Title { get; set; }
    public int Rating { get; set; }

}

public class CreateModelProfile : Profile
{
    public CreateModelProfile()
    {
        CreateMap<CreateModel, Feedback>()
            .ForMember(dest => dest.PointId, opt => opt.Ignore())
            .AfterMap<CreateModelActions>();
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

            var point = db.Points.FirstOrDefault(x => x.Uid == source.PointId);

            destination.PointId = point.Id;
        }
    }
}

public class CreatePointModelValidator : AbstractValidator<CreateModel>
{
    public CreatePointModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.Title)
             .NotEmpty().WithMessage("Title is required")
             .MaximumLength(1000).WithMessage("Maximum length is 1000"); ;

        RuleFor(x => x.PointId)
            .NotEmpty().WithMessage("Point is required")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                var found = context.Points.Any(a => a.Uid == id);
                return found;
            }).WithMessage("Point not found");
    }
}