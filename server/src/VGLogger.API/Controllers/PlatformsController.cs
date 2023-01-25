using Microsoft.AspNetCore.Mvc;
using VGLogger.API.ViewModels;

namespace VGLogger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PlatformsController : ControllerBase
{
    private readonly ILogger<DevelopersController> _logger;

    public PlatformsController(ILogger<DevelopersController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<PlatformViewModel> GetPlatformById(int id)
    {        
        return new ActionResult<PlatformViewModel>(new PlatformViewModel());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IList<PlatformViewModel>> GetPlatforms()
    {
        return new ActionResult<IList<PlatformViewModel>>(new List<PlatformViewModel>());
    }
}
