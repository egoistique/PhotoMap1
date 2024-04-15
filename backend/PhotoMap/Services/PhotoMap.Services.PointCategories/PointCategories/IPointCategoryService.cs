namespace PhotoMap.Services.PointCategories;
public interface IPointCategoryService
{
    Task<IEnumerable<PointCategoryModel>> GetAll();
    Task<PointCategoryModel> GetById(Guid id);
    Task<PointCategoryModel> Create(CreateModel model);
}
