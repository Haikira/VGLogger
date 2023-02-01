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
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UsersController> _logger;
    private readonly IMapper _mapper;

    public UsersController(ILogger<UsersController> logger, IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _logger = logger;
        _mapper = mapper;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public ActionResult<IList<UserViewModel>> GetUsers()
    {        
        return new ActionResult<IList<UserViewModel>>(new List<UserViewModel>());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<UserViewModel> GetUserById(int id)
    {       
        return new ActionResult<UserViewModel>(new UserViewModel());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="createUserViewModel"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult CreateUser([FromBody] CreateUserViewModel createUserViewModel)
    {
        return StatusCode((int)HttpStatusCode.Created);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateUserViewModel"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, [FromBody] UpdateUserViewModel updateUserViewModel)
    {
        return Ok();
    }

    // TODO - GET /users/{id}/games

    // TODO - POST /users/{id}/games

    // POST /users/{id}/games/{id}

    // PUT /users/{id}/games/{id}

    // DELETE /users/{id}

    // DELETE /users/{id}/games/{id}
}
