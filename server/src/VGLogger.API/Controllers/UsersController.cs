using Microsoft.AspNetCore.Mvc;
using VGLogger.API.ViewModels;

namespace VGLogger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<DevelopersController> _logger;

    public UsersController(ILogger<DevelopersController> logger)
    {
        _logger = logger;
    }
}
