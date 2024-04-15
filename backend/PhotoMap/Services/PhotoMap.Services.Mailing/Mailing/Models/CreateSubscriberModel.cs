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
    private readonly IDbContextFactory<MainDbContext> _contextFactory;

    public CreateSubscriberModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        _contextFactory = contextFactory;

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .Must((email) =>
            {
                using var context = contextFactory.CreateDbContext();
                var found = context.Subscribers.Any(a => a.Email == email);
                return !found;
            }).WithMessage("Email must be unique");
    }
}
