namespace PhotoMap.Services.Mailing;

public interface IMailingService
{
    Task<IEnumerable<SubscriberModel>> GetAll();
    Task<SubscriberModel> Create(CreateSubscriberModel model);
    Task Delete(String email);
    Task DoMailing(String pointTitle);
    void SendMessage(String recipient, String pointTitle);
}
