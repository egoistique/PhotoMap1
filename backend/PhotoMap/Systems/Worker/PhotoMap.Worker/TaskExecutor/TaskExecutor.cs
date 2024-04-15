namespace PhotoMap.Worker;

using PhotoMap.Services.RabbitMq;
using System.Threading.Tasks;
using PhotoMap.Services.Actions;
using PhotoMap.Services.Logger;

public class TaskExecutor : ITaskExecutor
{
    private readonly IAppLogger logger;
    private readonly IRabbitMq rabbitMq;

    public TaskExecutor(
        IAppLogger logger,
        IRabbitMq rabbitMq
    )
    {
        this.logger = logger;
        this.rabbitMq = rabbitMq;
    }

    public void Start()
    {
        rabbitMq.Subscribe<PublicatePointModel>(QueueNames.PUBLICATE_POINT, async data =>
        {
            logger.Information($"Starting publication of the point::: {data.Id}");

            await Task.Delay(3000);

            logger.Information($"The point was publicated::: {data.Id} | {data.Title} | {data.Description}");
        });
    }
}