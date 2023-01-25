using Microsoft.AspNetCore.Mvc;
using VGLogger.API.ViewModels;

namespace VGLogger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly ILogger<DevelopersController> _logger;

    public ReviewsController(ILogger<DevelopersController> logger)
    {
        _logger = logger;
    }
}
