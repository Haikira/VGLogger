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
public class DevelopersController : VGLoggerBaseController
{
    private readonly IDeveloperService _developerService;
    private readonly ILogger<DevelopersController> _logger;
    private readonly IMapper _mapper;

    public DevelopersController(ILogger<DevelopersController> logger, IDeveloperService developerService, IMapper mapper)
    {
        _developerService = developerService;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> CreateDeveloper([FromBody] CreateDeveloperViewModel createDeveloperViewModel)
    {
        await _developerService.CreateDeveloper(_mapper.Map<DeveloperDto>(createDeveloperViewModel));

        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDeveloper(int id)
    {
        await _developerService.DeleteDeveloper(id);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DeveloperViewModel>> GetDeveloperById(int id)
    {
        var developer = await _developerService.GetDeveloperById(id);

        return Ok(_mapper.Map<DeveloperViewModel>(developer));
    }

    [HttpGet]
    public async Task<ActionResult<IList<DeveloperViewModel>>> GetDevelopers()
    {
        var developers = await _developerService.GetDevelopers();        

        return OkOrNoContent(_mapper.Map<List<DeveloperViewModel>>(developers));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDeveloper(int id, [FromBody] UpdateDeveloperViewModel updateDeveloperViewModel)
    {
        await _developerService.UpdateDeveloper(id, _mapper.Map<DeveloperDto>(updateDeveloperViewModel));

        return NoContent();
    }
}
