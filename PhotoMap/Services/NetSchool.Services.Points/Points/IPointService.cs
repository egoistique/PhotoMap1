namespace NetSchool.Services.Points;
public interface IPointService
{
    Task<IEnumerable<PointModel>> GetAll();
    Task<PointModel> GetById(Guid id);
    Task<PointModel> Create(CreateModel model);
    Task Update(Guid id, UpdateModel model);
    Task Delete(Guid id);
}
