namespace PhotoMap.Api;

using PhotoMap.Context.Seeder;
using PhotoMap.Services.Logger;
using PhotoMap.Services.Settings;
using PhotoMap.Api.Settings;
using PhotoMap.Services.Points;
using PhotoMap.Services.PointCategories;
using PhotoMap.Services.Feedbacks;
using PhotoMap.Services.ImagePathes;
using PhotoMap.Services.RabbitMq;
using PhotoMap.Services.Actions;
using PhotoMap.Services.UserAccount;
using PhotoMap.Services.Mailing;

public static class Bootstrapper
{
    public static IServiceCollection RegisterServices (this IServiceCollection service, IConfiguration configuration = null)
    {
        service
            .AddMainSettings()
            .AddLogSettings()
            .AddSwaggerSettings()
            .AddIdentitySettings()
            .AddAppLogger()
            .AddDbSeeder()
            .AddApiSpecialSettings()
            .AddPointService()
            .AddPointCategoryService()
            .AddFeedbackService()
            .AddImageService()
            .AddRabbitMq()
            .AddActions()
            .AddUserAccountService()
            .AddHttpClient()
            .AddMailingService()
            ;

        return service;
    }
}
