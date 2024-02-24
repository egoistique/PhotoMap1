using NetSchool.Services.ImagePathes;

namespace NetSchool.Services.ImagePathes;
public interface IImageService
{
    Task<IEnumerable<ImagePathModel>> GetAll();
    Task<ImagePathModel> GetById(Guid id);
    Task<ImagePathModel> Create(CreateModel model);

    Task Delete(Guid id);
}
