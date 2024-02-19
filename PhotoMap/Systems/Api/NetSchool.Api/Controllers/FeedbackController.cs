namespace NetSchool.Api.App;

using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetSchool.Common.Security;
using NetSchool.Services.Feedbacks;
using NetSchool.Services.Logger;


[ApiController]

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class FeedbackController : Controller
{
    private readonly IAppLogger logger;
    private readonly IFeedbackService feedbackService;

    public FeedbackController(IAppLogger logger, IFeedbackService feedbackService)
    {
        this.logger = logger;
        this.feedbackService = feedbackService;
    }

    [HttpGet("")]
    [AllowAnonymous]
    public async Task<IEnumerable<FeedbackModel>> GetAll()
    {
        var result = await feedbackService.GetAll();

        return result;
    }

    [HttpPost("")]
    [Authorize(AppScopes.BooksWrite)]
    public async Task<FeedbackModel> Create(CreateModel request)
    {
        var result = await feedbackService.Create(request);

        return result;
    }
}
