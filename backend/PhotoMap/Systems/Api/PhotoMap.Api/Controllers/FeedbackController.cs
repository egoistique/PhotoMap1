﻿namespace PhotoMap.Api.App;

using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoMap.Common.Security;
using PhotoMap.Services.Feedbacks;
using PhotoMap.Services.Logger;


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

    [HttpGet("{id:Guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await feedbackService.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }


    [HttpPost("")]
    [Authorize(AppScopes.PointsWrite)]
    //[AllowAnonymous]
    public async Task<FeedbackModel> Create(CreateModel request)
    {
        var result = await feedbackService.Create(request);

        return result;
    }


    [HttpDelete("{id:Guid}")]
    [Authorize(AppScopes.PointsWrite)]
    public async Task Delete([FromRoute] Guid id)
    {
        await feedbackService.Delete(id);
    }

}
