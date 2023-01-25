using Microsoft.AspNetCore.Mvc;
using VGLogger.API.ViewModels;

namespace VGLogger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DevelopersController : ControllerBase
{
    private readonly ILogger<DevelopersController> _logger;

    public DevelopersController(ILogger<DevelopersController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IList<DeveloperViewModel>> GetDevelopers()
    {
        var ret = new List<DeveloperViewModel>();

        return new ActionResult<IList<DeveloperViewModel>>(ret);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<DeveloperViewModel> GetDeveloperById(int id)
    {
        var ret = new DeveloperViewModel();

        return new ActionResult<DeveloperViewModel>(ret);
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
