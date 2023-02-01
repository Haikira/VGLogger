using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using VGLogger.Api.Test.Extensions;
using VGLogger.API.Controllers;
using VGLogger.API.ViewModels;
using VGLogger.Service.Dtos;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Services;

namespace VGLogger.API.Test.Controllers
{
    public class UsersControllerTests
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersControllerTests()
        {
            _logger = Substitute.For<ILogger<UsersController>>();
            _mapper = Substitute.For<IMapper>();
            _userService = Substitute.For<IUserService>();
        }

        private UsersController RetrieveController()
        {
            return new UsersController(_logger, _userService, _mapper);
        }
    }
}
