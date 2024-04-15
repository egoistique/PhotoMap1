namespace PhotoMap.Api.App;

using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoMap.Common.Security;
using PhotoMap.Services.Points;
using PhotoMap.Services.Logger;
using PhotoMap.Common.Exceptions;

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

    [HttpGet("category/{categoryId:Guid}")]
    [AllowAnonymous]
    public async Task<IEnumerable<PointModel>> GetByCategory([FromRoute] Guid categoryId)
    {
        var result = await pointService.GetByCategoryId(categoryId);
        return result;
    }

    [HttpPost("")]
    [Authorize(AppScopes.PointsWrite)]
    public async Task<PointModel> Create(CreateModel request)
    {
        var result = await pointService.Create(request);

        return result;
    }

    [HttpPut("{id:Guid}")]
    [Authorize(AppScopes.PointsWrite)]
    public async Task Update([FromRoute] Guid id, UpdateModel request)
    {
        await pointService.Update(id, request);
    }

    [HttpDelete("{id:Guid}")]
    [Authorize(AppScopes.PointsWrite)]
    public async Task Delete([FromRoute] Guid id)
    {
        await pointService.Delete(id);
    }

    [HttpGet("search")]
    [AllowAnonymous]
    public async Task<IEnumerable<PointModel>> Search([FromQuery] string query)
    {
        var result = await pointService.SearchByName(query);
        return result;
    }
    
    [HttpGet("name")]
    [AllowAnonymous]
    public async Task<IActionResult> GetPointNameByCoordinates([FromQuery] double latitude, [FromQuery] double longitude)
    {
        try
        {
            var result = await pointService.GetPointNameByCoordinates(latitude, longitude);
            return Ok(result);
        }
        catch (ProcessException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "An error occurred while processing your request.");
        }
    }

}
