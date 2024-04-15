namespace PhotoMap.Services.Actions;

using System.Threading.Tasks;

public interface IAction
{
    Task PublicatePoint(PublicatePointModel model);
}
