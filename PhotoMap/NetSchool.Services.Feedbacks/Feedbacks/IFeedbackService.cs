namespace NetSchool.Services.Feedbacks;
public interface IFeedbackService
{
    Task<IEnumerable<FeedbackModel>> GetAll();
    Task<FeedbackModel> GetById(Guid id);
    Task<FeedbackModel> Create(CreateModel model);

    Task Delete(Guid id);
}
