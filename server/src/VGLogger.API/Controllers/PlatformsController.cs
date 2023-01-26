using Microsoft.AspNetCore.Mvc;
using VGLogger.API.ViewModels;
using VGLogger.Service.Interfaces;

namespace VGLogger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PlatformsController : ControllerBase
{
    private readonly ILogger<DevelopersController> _logger;
    private readonly IPlatformService _platformService;

    public PlatformsController(
        ILogger<DevelopersController> logger, 
        IPlatformService platformService)
    {
        _logger = logger;
        _platformService = platformService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<PlatformViewModel> GetPlatformById(int id)
    {
        var platform = _platformService.GetPlatformById(id);

        return Ok(new PlatformViewModel() { Id = platform.Id, Platform = platform.Name });
        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IList<PlatformViewModel>> GetPlatforms()
    {        
        var platforms = _platformService.GetPlatforms();

        return Ok(platforms.Select(x => new PlatformViewModel { Id = x.Id, Platform = x.Name }).ToList());        
    }
}
