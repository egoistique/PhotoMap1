namespace NetSchool.Services.Points;

using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddPointService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IPointService, PointService>();
    }
}
