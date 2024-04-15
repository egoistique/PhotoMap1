namespace PhotoMap.Services.Actions;

using PhotoMap.Services.RabbitMq;
using System.Threading.Tasks;

public class Action : IAction
{
    private readonly IRabbitMq rabbitMq;

    public Action(IRabbitMq rabbitMq)
    {
        this.rabbitMq = rabbitMq;
    }

    public async Task PublicatePoint(PublicatePointModel model)
    {
        await rabbitMq.PushAsync(QueueNames.PUBLICATE_POINT, model);
    }
}
