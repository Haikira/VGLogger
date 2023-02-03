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

namespace VGLogger.API.Test.Controllers
{
    public class GamesControllerTests
    {
        private readonly IGameService _gameService;
        private readonly ILogger<GamesController> _logger;
        private readonly IMapper _mapper;

        public GamesControllerTests()
        {
            _gameService = Substitute.For<IGameService>();
            _logger = Substitute.For<ILogger<GamesController>>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public async Task GetGames_WhenGamesExist_MapsAndReturns()
        {
            // Arrange
            var gameDtos = new List<GameDto> { new GameDto() };
            var gameViewModels = new List<GameViewModel> { new GameViewModel() };
            var controller = RetrieveController();

            _gameService.GetGames().Returns(gameDtos);
            _mapper.Map<List<GameViewModel>>(gameDtos).Returns(gameViewModels);

            // Act
            var actionResult = await controller.GetGames();

            // Assert
            var result = actionResult.AssertObjectResult<IList<GameViewModel>, OkObjectResult>();

            result.Should().BeSameAs(gameViewModels);

            await _gameService.Received(1).GetGames();

            _mapper.Received(1).Map<List<GameViewModel>>(gameDtos);
        }

        [Fact]
        public async Task GetGames_WhenNoGamesExist_ReturnsNoContent()
        {
            // Arrange            
            var controller = RetrieveController();

            // Act
            var actionResult = await controller.GetGames();

            // Assert
            actionResult.AssertResult<IList<GameViewModel>, NoContentResult>();
        }

        private GamesController RetrieveController()
        {
            return new GamesController(_logger, _gameService, _mapper);
        }
    }
}
