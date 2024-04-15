using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhotoMap.Context.Entities;
using PhotoMap.Context;
using PhotoMap.Settings;
using FluentValidation;

namespace PhotoMap.Services.Mailing;

public class CreateSubscriberModel
{
    public string Email { get; set; }
}
public class CreateModelProfile : Profile
{
    public CreateModelProfile()
    {
        CreateMap<CreateSubscriberModel, Subscriber>();

    }

    public class CreateModelActions : IMappingAction<CreateSubscriberModel, Subscriber>
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public CreateModelActions(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Process(CreateSubscriberModel source, Subscriber destination, ResolutionContext context)
        {
            using var db = contextFactory.CreateDbContext();

        }
    }
}

public class CreateSubscriberModelValidator : AbstractValidator<CreateSubscriberModel>
{
    public CreateSubscriberModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required");
    }
}