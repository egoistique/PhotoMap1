namespace PhotoMap.Services.Mailing;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PhotoMap.Common.Exceptions;
using PhotoMap.Common.Validator;
using PhotoMap.Context;
using PhotoMap.Context.Entities;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

public class MailingService : IMailingService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;
    private readonly IModelValidator<CreateSubscriberModel> createModelValidator;

    public MailingService(IDbContextFactory<MainDbContext> dbContextFactory, IMapper mapper, IModelValidator<CreateSubscriberModel> createModelValidator)
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
        this.createModelValidator = createModelValidator;
    }

    private const string smtpServer = "smtp.mail.ru"; //smpt сервер(зависит от почты отправителя)
    private const int smtpPort = 587; // Обычно используется порт 587 для TLS
    private const string smtpUsername = "photo.map.sender@mail.ru"; //твоя почта, с которой отправляется сообщение
    private const string smtpPassword = "s0cSiGMUzjAArxmSwhJT";//пароль приложения (от почты)



    public async Task<IEnumerable<SubscriberModel>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var subscribers = await context.Subscribers.ToListAsync();

        var result = mapper.Map<IEnumerable<SubscriberModel>>(subscribers);

        return result;
    }

    public async Task<SubscriberModel> Create(CreateSubscriberModel model)
    {
        await createModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var subscriber = mapper.Map<Subscriber>(model);

        await context.Subscribers.AddAsync(subscriber);

        await context.SaveChangesAsync();

        return mapper.Map<SubscriberModel>(subscriber);
    }

    public async Task DoMailing(String pointTitle)
    {
        var subscribers = await GetAll();

        foreach (var subscriber in subscribers)
        {
            SendMessage(subscriber.Email, pointTitle);
        }
    }


    public void SendMessage(string recipient, string pointTitle)
    {
        string subject = "Новая точка";
        string body = $"Добавлена новая точка '{pointTitle}', скорее проверьте карту и поделитесь впечатлениями";

        using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
        {
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.EnableSsl = true;

            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(smtpUsername);
                mailMessage.To.Add(recipient);
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                try
                {
                    smtpClient.Send(mailMessage);
                    Console.WriteLine("Сообщение успешно отправлено.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка отправки сообщения: {ex.Message}");
                }
            }
        }
    }

    public async Task Delete(String email)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var subscriber = await context.Subscribers.Where(x => x.Email == email).FirstOrDefaultAsync();

        if (subscriber == null)
            throw new ProcessException($"Subscriber (Email = {email}) not found.");

        context.Subscribers.Remove(subscriber);

        await context.SaveChangesAsync();
    }
}
