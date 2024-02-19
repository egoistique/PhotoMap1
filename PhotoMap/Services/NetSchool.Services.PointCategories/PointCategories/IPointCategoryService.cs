namespace NetSchool.Services.PointCategories;
public interface IPointCategoryService
{
    Task<IEnumerable<PointCategoryModel>> GetAll();
    Task<PointCategoryModel> Create(CreateModel model);
}
