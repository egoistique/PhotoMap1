namespace NetSchool.Services.Feedbacks;

using Microsoft.Extensions.DependencyInjection;
public static class Bootstrapper
{
    public static IServiceCollection AddFeedbackService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IFeedbackService, FeedbackService>();
    }
}
