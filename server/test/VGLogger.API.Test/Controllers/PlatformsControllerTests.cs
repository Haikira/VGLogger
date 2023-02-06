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
    public class PlatformsControllerTests
    {
        private readonly ILogger<PlatformsController> _logger;
        private readonly IMapper _mapper;
        private readonly IPlatformService _platformService;

        public PlatformsControllerTests()
        {
            _logger = Substitute.For<ILogger<PlatformsController>>();
            _mapper = Substitute.For<IMapper>();
            _platformService = Substitute.For<IPlatformService>();
        }

        [Fact]
        public async Task GetPlatforms_WhenPlatformsExist_MapsAndReturns()
        {
            // Arrange
            var platformDTOs = new List<PlatformDto> { new PlatformDto() };
            var platformViewModels = new List<PlatformViewModel> { new PlatformViewModel() };
            var controller = RetrieveController();

            _platformService.GetPlatforms().Returns(platformDTOs);
            _mapper.Map<List<PlatformViewModel>>(platformDTOs).Returns(platformViewModels);

            // Act
            var actionResult = await controller.GetPlatforms();

            // Assert
            var result = actionResult.AssertObjectResult<IList<PlatformViewModel>, OkObjectResult>();

            result.Should().BeSameAs(platformViewModels);

            await _platformService.Received(1).GetPlatforms();

            _mapper.Received(1).Map<List<GameViewModel>>(platformDTOs);
        }

        [Fact]
        public async Task GetPlatforms_WhenNoPlatformsExist_ReturnsNoContent()
        {
            // Arrange            
            var controller = RetrieveController();

            // Act
            var actionResult = await controller.GetPlatforms();

            // Assert
            actionResult.AssertResult<IList<PlatformViewModel>, NoContentResult>();
        }

        private PlatformsController RetrieveController()
        {
            return new PlatformsController(_logger, _platformService, _mapper);
        }
    }
}
