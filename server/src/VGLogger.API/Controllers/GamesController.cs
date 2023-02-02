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
public class GamesController : VGLoggerBaseController
{
    private readonly IGameService _gameService;
    private readonly ILogger<GamesController> _logger;
    private readonly IMapper _mapper;

    public GamesController(ILogger<GamesController> logger, IGameService gameService, IMapper mapper)
    {
        _gameService = gameService;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGame([FromBody] CreateGameViewModel createGameViewModel)
    {
        await _gameService.CreateGame(_mapper.Map<GameDto>(createGameViewModel));

        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(int id)
    {
        await _gameService.DeleteGame(id);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameDetailViewModel>> GetGameById(int id)
    {
        var game = await _gameService.GetGameById(id);

        return Ok(_mapper.Map<GameDetailViewModel>(game));
    }

    [HttpGet]
    public async Task<ActionResult<IList<GameViewModel>>> GetGames()
    {
        var games = await _gameService.GetGames();

        return OkOrNoContent(_mapper.Map<List<GameViewModel>>(games));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGame(int id, [FromBody] UpdateGameViewModel updateGameViewModel)
    {
        await _gameService.UpdateGame(id, _mapper.Map<GameDto>(updateGameViewModel));

        return NoContent();
    }
}
