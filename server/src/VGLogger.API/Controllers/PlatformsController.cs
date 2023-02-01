using Microsoft.AspNetCore.Mvc;
using VGLogger.API.ViewModels;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Dtos;
using VGLogger.API.Controllers.Base;
using AutoMapper;
using System.Net;

namespace VGLogger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformService _platformService;
    private readonly ILogger<PlatformsController> _logger;
    private readonly IMapper _mapper;

    public PlatformsController(ILogger<PlatformsController> logger, IPlatformService platformService, IMapper mapper)
    {
        _platformService = platformService;
        _logger = logger;
        _mapper = mapper;
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

        return Ok();        
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IList<PlatformViewModel>> GetPlatforms()
    {        
        var platforms = _platformService.GetPlatforms();

        return Ok();        
    }
}
