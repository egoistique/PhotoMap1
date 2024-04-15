namespace PhotoMap.Api.App;

using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoMap.Common.Security;
using PhotoMap.Services.ImagePathes;
using PhotoMap.Services.Logger;


[ApiController]

[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class ImagePathController : Controller
{
    private readonly IAppLogger logger;
    private readonly IImageService imageService;

    public ImagePathController(IAppLogger logger, IImageService imageService)
    {
        this.logger = logger;
        this.imageService = imageService;
    }

    [HttpGet("")]
    [AllowAnonymous]
    public async Task<IEnumerable<ImagePathModel>> GetAll()
    {
        var result = await imageService.GetAll();

        return result;
    }

    [HttpGet("{id:Guid}")]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var result = await imageService.GetById(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }


    [HttpPost("")]
    //[Authorize(AppScopes.PointsWrite)]
    [AllowAnonymous]
    public async Task<ImagePathModel> Create(CreateModel request)
    {
        var result = await imageService.Create(request);

        return result;
    }


    [HttpDelete("{id:Guid}")]
    [Authorize(AppScopes.PointsWrite)]
    //[AllowAnonymous]
    public async Task Delete([FromRoute] Guid id)
    {
        await imageService.Delete(id);
    }

}
