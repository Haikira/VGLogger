using Microsoft.AspNetCore.Mvc;
using VGLogger.API.ViewModels;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Dtos;
using VGLogger.API.Controllers.Base;
using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace VGLogger.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : VGLoggerBaseController
{
    private readonly ILogger<UsersController> _logger;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UsersController(ILogger<UsersController> logger, IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserViewModel createUserViewModel)
    {
        await _userService.CreateUser(_mapper.Map<UserDto>(createUserViewModel));

        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        await _userService.DeleteUser(id);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserViewModel>> GetUserById(int id)
    {
        var user = await _userService.GetUserById(id);

        return Ok(_mapper.Map<UserViewModel>(user));
    }

    [HttpGet]
    public async Task<ActionResult<IList<UserViewModel>>> GetUsers()
    {
        var users = await _userService.GetUsers();

        return OkOrNoContent(_mapper.Map<List<UserViewModel>>(users));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(int id, [FromBody] UpdateUserViewModel updateUserViewModel)
    {
        await _userService.UpdateUser(id, _mapper.Map<UserDto>(updateUserViewModel));

        return NoContent();
    }

    [HttpGet("{id}/games", Name = "GetUserGames")]
    [AllowAnonymous]
    public async Task<ActionResult<IList<GameViewModel>>> GetUserGames(int id)
    {
        var userGames = await _userService.GetUserGames(id);

        return Ok(_mapper.Map<List<GameViewModel>>(userGames));
    }

    [HttpPost("{id}/games", Name = "CreateUserGames")]
    [AllowAnonymous]
    public async Task<ActionResult> CreateUserGames(int id, ICollection<CreateUserGameViewModel> games)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{id}/games", Name = "UpdateUserGames")]
    [AllowAnonymous]
    public async Task<ActionResult> UpdateUserGames(int id, ICollection<UpdateUserGameViewModel> games)
    {
        throw new NotImplementedException();
    }
}
