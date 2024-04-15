namespace PhotoMap.Worker;

using PhotoMap.Services.RabbitMq;
using Microsoft.Extensions.DependencyInjection;
using PhotoMap.Services.Logger;

public static class Bootstrapper
{
    public static IServiceCollection RegisterAppServices(this IServiceCollection services)
    {
        services
            .AddAppLogger()
            .AddRabbitMq()            
            ;

        services.AddSingleton<ITaskExecutor, TaskExecutor>();

        return services;
    }
}