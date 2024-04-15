using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoMap.Common.Security;
using PhotoMap.Services.ImagePathes;
using PhotoMap.Services.Logger;
using PhotoMap.Services.Mailing;
using PhotoMap.Services.Points;

namespace PhotoMap.Api.Controllers;

[ApiController]

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class SubscriberController : Controller
{
    private readonly IAppLogger logger;
    private readonly IMailingService mailingService;

    public SubscriberController(IAppLogger logger, IMailingService mailingService)
    {
        this.logger = logger;
        this.mailingService = mailingService;
    }

    [HttpGet("")]
    public async Task<IEnumerable<SubscriberModel>> GetAll()
    {
        var result = await mailingService.GetAll();

        return result;
    }

    [HttpPost("")]
    public async Task<SubscriberModel> Create(CreateSubscriberModel request)
    {
        var result = await mailingService.Create(request);

        return result;
    }

    [HttpDelete("{email}")]
    public async Task Delete([FromRoute] string email)
    {
        await mailingService.Delete(email);
    }

}
