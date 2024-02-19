namespace NetSchool.Services.Feedbacks;
public interface IFeedbackService
{
    Task<IEnumerable<FeedbackModel>> GetAll();
    Task<FeedbackModel> Create(CreateModel model);
}
