using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using VGLogger.API.ViewModels;

namespace VGLogger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
    private readonly ILogger<GamesController> _logger;

    public GamesController(ILogger<GamesController> logger)
    {
        _logger = logger;
    }

    // TODO GET /games/{id}/reviews

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IList<GameViewModel>> GetGames()
    {
        var ret = new List<GameViewModel> 
        { 
            new GameViewModel
            {
                Id = 1, 
                Description = "Red Dead Redemption 2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age.",
                Name = "TESTTSETSETSTTS"
            },
            new GameViewModel
            {
                Id = 2,
                Description = "NieR Automata tells the story of androids 2B, 9S and A2 and their battle to reclaim the machine-driven dystopia overrun by powerful machines.",
                Name = "NieR:Automata"
            }
        };

        return new ActionResult<IList<GameViewModel>>(ret);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<GameDetailViewModel> GetGameById(int id)
    {
        var ret = new GameDetailViewModel
        {
            Id = id,
            Description = "Red Dead Redemption 2 is the epic tale of outlaw Arthur Morgan and the infamous Van der Linde gang, on the run across America at the dawn of the modern age.",
            Developer = new DeveloperViewModel
            {
                Id = 1,
                Name = "Rockstar Games"
            },
            Name = "Red Dead Redemption 2",
            Platforms = new List<PlatformViewModel>()
            {
                new PlatformViewModel
                {
                    Id = 1,
                    Platform = "Playstation 4",
                    ReleaseDate = new DateTime(2018, 10, 26)
                },
                new PlatformViewModel
                {
                    Id = 1,
                    Platform = "Windows",
                    ReleaseDate = new DateTime(2019, 11, 19)
                }
            }
        };

        return new ActionResult<GameDetailViewModel>(ret);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="createGameViewModel"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult CreateGame([FromBody] CreateGameViewModel createGameViewModel)
    {
        return StatusCode((int)HttpStatusCode.Created);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateGameViewModel"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult UpdateGame(int id, [FromBody] UpdateGameViewModel updateGameViewModel)
    {
        return Ok();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public ActionResult DeleteGame(int id)
    {
        return Ok();
    }
}
