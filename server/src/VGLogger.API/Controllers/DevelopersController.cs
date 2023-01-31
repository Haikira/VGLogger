using Microsoft.AspNetCore.Mvc;
using VGLogger.API.ViewModels;
using VGLogger.DAL.Interfaces;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Dtos;
using VGLogger.API.Controllers.Base;
using Microsoft.Extensions.Logging;
using VGLogger.Service.Services;
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

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IList<DeveloperViewModel>>> GetDevelopers()
    {
        var developers = await _developerService.GetDevelopers();        

        return OkOrNoContent(developers.Select(x => new DeveloperViewModel { Id = x.Id, Name = x.Name }).ToList());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<DeveloperDto>> GetDeveloperById(int id)
    {
        var developer = await _developerService.GetDeveloperById(id);

        return Ok(developer);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="createDeveloperViewModel"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult CreateDeveloper([FromBody] CreateDeveloperViewModel createDeveloperViewModel)
    {
        _developerService.CreateDeveloper(_mapper.Map<DeveloperDto>(createDeveloperViewModel));

        return StatusCode((int)HttpStatusCode.Created);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateDeveloperViewModel"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult UpdateDeveloper(int id, [FromBody] UpdateDeveloperViewModel updateDeveloperViewModel)
    {
        _developerService.UpdateDeveloper(id, _mapper.Map<DeveloperDto>(updateDeveloperViewModel));

        return NoContent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult DeleteDeveloper(int id)
    {
        _developerService.DeleteDeveloper(id);

        return Ok();
    }
}
