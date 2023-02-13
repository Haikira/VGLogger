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

        [Fact]
        public async Task GetUsers_WhenUsersExist_MapsAndReturns()
        {
            // Arrange 
            var userDtos = new List<UserDto> { new UserDto() };
            var userViewModels = new List<UserViewModel> { new UserViewModel() };
            var controller = RetrieveController();

            _userService.GetUsers().Returns(userDtos);
            _mapper.Map<List<UserViewModel>>(userDtos).Returns(userViewModels);

            // Act
            var actionResult = await controller.GetUsers();

            // Assert
            var result = actionResult.AssertObjectResult<IList<UserViewModel>, OkObjectResult>();

            result.Should().BeSameAs(userViewModels);

            await _userService.Received(1).GetUsers();

            _mapper.Received(1).Map<List<UserViewModel>>(userDtos);
        }

        [Fact]
        public async Task GetUsers_WhenNoUsersExist_ReturnsNoContent()
        {
            // Arrange 
            var controller = RetrieveController();

            // Act
            var actionResult = await controller.GetUsers();

            // Assert
            actionResult.AssertResult<IList<UserViewModel>, NoContentResult>();
        }

        private UsersController RetrieveController()
        {
            return new UsersController(_logger, _userService, _mapper);
        }
    }
}
