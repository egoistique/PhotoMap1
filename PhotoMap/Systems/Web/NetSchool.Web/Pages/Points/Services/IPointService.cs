using NetSchool.Web.Pages.Points.Models;

namespace NetSchool.Web.Pages.Points.Services;

public interface IPointService
{
    Task<IEnumerable<PointModel>> GetPoints();
    Task<PointModel> GetPoint(Guid pointId);
    Task AddPoint(CreateModel model);
    Task EditPoint(Guid pointId, UpdateModel model);
    Task DeletePoint(Guid pointId);
    Task<IEnumerable<PointCategoryModel>> GetPointCategoryList();
}
