namespace NetSchool.Api.App;

using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetSchool.Common.Security;
using NetSchool.Services.Points;
using NetSchool.Services.Logger;

[ApiController]

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]

public class PointController : ControllerBase
{
    private readonly IAppLogger logger;
    private readonly IPointService pointService;
    public PointController(IAppLogger logger, IPointService pointService)
    {
        this.logger = logger;
        this.pointService = pointService;
    }

    [HttpGet("")]
    [AllowAnonymous]
    public async Task<IEnumerable<PointModel>> GetAll()
    {
        var result = await pointService.GetAll();

        return result;
    }

    [HttpGet("{id:Guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await pointService.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("")]
    [Authorize(AppScopes.BooksWrite)]
    public async Task<PointModel> Create(CreateModel request)
    {
        var result = await pointService.Create(request);

        return result;
    }

    [HttpPut("{id:Guid}")]
    [Authorize(AppScopes.BooksWrite)]
    public async Task Update([FromRoute] Guid id, UpdateModel request)
    {
        await pointService.Update(id, request);
    }

    [HttpDelete("{id:Guid}")]
    [Authorize(AppScopes.BooksWrite)]
    public async Task Delete([FromRoute] Guid id)
    {
        await pointService.Delete(id);
    }

}
