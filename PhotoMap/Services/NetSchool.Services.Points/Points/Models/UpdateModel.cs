using AutoMapper;
using FluentValidation;
using NetSchool.Settings;
using NetSchool.Context.Entities;

namespace NetSchool.Services.Points;
public class UpdateModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; } // Широта
    public double Longitude { get; set; } // Долгота
}

public class UpdateModelProfile : Profile
{
    public UpdateModelProfile()
    {
        CreateMap<UpdateModel, Point>();
    }
}

public class UpdateModelValidator : AbstractValidator<UpdateModel>
{
    public UpdateModelValidator()
    {
        RuleFor(x => x.Title).PointTitle();

        RuleFor(x => x.Latitude)
            .NotEmpty().WithMessage("Latitude is required");

        RuleFor(x => x.Longitude)
            .NotEmpty().WithMessage("Longitude is required");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Maximum length is 1000");
    }
}