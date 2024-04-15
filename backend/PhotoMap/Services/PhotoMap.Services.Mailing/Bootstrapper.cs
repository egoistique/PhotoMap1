namespace PhotoMap.Services.Mailing;

using Microsoft.Extensions.DependencyInjection;
public static class Bootstrapper
{
    public static IServiceCollection AddMailingService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IMailingService, MailingService>();
    }
}
