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
public class PlatformsController : VGLoggerBaseController
{
    private readonly ILogger<PlatformsController> _logger;
    private readonly IMapper _mapper;
    private readonly IPlatformService _platformService;

    public PlatformsController(ILogger<PlatformsController> logger, IPlatformService platformService, IMapper mapper)
    {
        _platformService = platformService;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePlatform([FromBody] CreatePlatformViewModel createPlatformViewModel)
    {
        await _platformService.CreatePlatform(_mapper.Map<PlatformDto>(createPlatformViewModel));

        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlatform(int id)
    {
        await _platformService.DeletePlatform(id);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PlatformViewModel>> GetPlatformById(int id)
    {
        var platform = await _platformService.GetPlatformById(id);

        return Ok(_mapper.Map<PlatformViewModel>(platform));        
    }

    [HttpGet]
    public async Task<ActionResult<IList<PlatformViewModel>>> GetPlatforms()
    {        
        var platforms = await _platformService.GetPlatforms();

        return OkOrNoContent(_mapper.Map<List<PlatformViewModel>>(platforms));        
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePlatform(int id, [FromBody] UpdatePlatformViewModel updatePlatformViewModel)
    {
        await _platformService.UpdatePlatform(id, _mapper.Map<PlatformDto>(updatePlatformViewModel));

        return NoContent();
    }
}
