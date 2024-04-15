namespace PhotoMap.Api.App;

using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoMap.Common.Security;
using PhotoMap.Services.PointCategories;
using PhotoMap.Services.Logger;


[ApiController]

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class PointCategoryController : Controller
{
    private readonly IAppLogger logger;
    private readonly IPointCategoryService pointCategoryService;

    public PointCategoryController(IAppLogger logger, IPointCategoryService pointCategoryService)
    {
        this.logger = logger;
        this.pointCategoryService = pointCategoryService;
    }

    [HttpGet("")]
    [AllowAnonymous]
    public async Task<IEnumerable<PointCategoryModel>> GetAll()
    {
        var result = await pointCategoryService.GetAll();

        return result;
    }

    [HttpGet("{id:Guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await pointCategoryService.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost("")]
    [Authorize(AppScopes.PointsWrite)]
    public async Task<PointCategoryModel> Create(CreateModel request)
    {
        var result = await pointCategoryService.Create(request);

        return result;
    }
}
