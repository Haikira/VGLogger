using Microsoft.AspNetCore.Mvc;
using VGLogger.API.ViewModels;
using VGLogger.DAL.Interfaces;
using VGLogger.Service.Interfaces;
using VGLogger.Service.DTOs;
using VGLogger.API.Controllers.Base;
using Microsoft.Extensions.Logging;
using VGLogger.Service.Services;

namespace VGLogger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DevelopersController : VGLoggerBaseController
{
    private readonly ILogger<DevelopersController> _logger;
    private readonly IDeveloperService _developerService;

    public DevelopersController(ILogger<DevelopersController> logger, IDeveloperService developerService)
    {
        _logger = logger;
        _developerService = developerService;
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
    public async Task<ActionResult<DeveloperDTO>> GetDeveloperById(int id)
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

        return Ok();
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
        return Ok();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult DeleteDeveloper(int id)
    {
        return Ok();
    }
}
