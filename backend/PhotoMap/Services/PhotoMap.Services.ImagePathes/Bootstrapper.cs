namespace PhotoMap.Services.ImagePathes;

using Microsoft.Extensions.DependencyInjection;
public static class Bootstrapper
{
    public static IServiceCollection AddImageService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IImageService, ImageService>();
    }
}

