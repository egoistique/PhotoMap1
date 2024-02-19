namespace NetSchool.Api.App;

using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetSchool.Common.Security;
using NetSchool.Services.PointCategories;
using NetSchool.Services.Logger;


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

    [HttpPost("")]
    [Authorize(AppScopes.BooksWrite)]
    public async Task<PointCategoryModel> Create(CreateModel request)
    {
        var result = await pointCategoryService.Create(request);

        return result;
    }
}
