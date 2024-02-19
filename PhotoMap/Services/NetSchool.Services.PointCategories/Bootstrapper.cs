
namespace NetSchool.Services.PointCategories;
using Microsoft.Extensions.DependencyInjection;

public static class Bootstrapper
{
    public static IServiceCollection AddPointCategoryService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IPointCategoryService, PointCategoryService>();
    }
}