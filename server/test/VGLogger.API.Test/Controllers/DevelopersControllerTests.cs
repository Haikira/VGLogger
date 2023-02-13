using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Net;
using VGLogger.Api.Test.Extensions;
using VGLogger.API.Controllers;
using VGLogger.API.ViewModels;
using VGLogger.Service.Dtos;
using VGLogger.Service.Interfaces;

namespace VGLogger.API.Test.Controllers
{
    public class DevelopersControllerTests
    {
        private readonly IDeveloperService _developerService;
        private readonly ILogger<DevelopersController> _logger;
        private readonly IMapper _mapper;

        public DevelopersControllerTests()
        {
            _developerService = Substitute.For<IDeveloperService>();
            _logger = Substitute.For<ILogger<DevelopersController>>();
            _mapper = Substitute.For<IMapper>();
        }

        [Fact]
        public async Task GetDevelopers_WhenDevelopersExist_MapsAndReturns()
        {
            // Arrange
            var developerDTOs = new List<DeveloperDto> { new DeveloperDto() };
            var developerViewModels = new List<DeveloperViewModel> { new DeveloperViewModel() };
            var controller = RetrieveController();

            _developerService.GetDevelopers().Returns(developerDTOs);            
            _mapper.Map<List<DeveloperViewModel>>(developerDTOs).Returns(developerViewModels);
            
            // Act
            var actionResult = await controller.GetDevelopers();

            // Assert
            var result = actionResult.AssertObjectResult<IList<DeveloperViewModel>, OkObjectResult>();

            result.Should().BeSameAs(developerViewModels);

            await _developerService.Received(1).GetDevelopers();

            _mapper.Received(1).Map<List<DeveloperViewModel>>(developerDTOs);
        }

        [Fact]
        public async Task GetDevelopers_WhenNoDevelopersExist_ReturnsNoContent()
        {
            // Arrange            
            var controller = RetrieveController();
            
            // Act
            var actionResult = await controller.GetDevelopers();

            // Assert
            actionResult.AssertResult<IList<DeveloperViewModel>, NoContentResult>();            
        }

        [Theory]
        [InlineData("name")]
        public async Task CreateDeveloper_WhenValidDataEntered_MappedAndSaved(string name)
        {
            // Arrange
            var developer = new DeveloperDto { Name = name };
            var createDeveloperViewModel = new CreateDeveloperViewModel();

            _mapper.Map<DeveloperDto>(createDeveloperViewModel).Returns(developer);

            var controller = RetrieveController();

            // Act
            var actionResult = await controller.CreateDeveloper(createDeveloperViewModel);

            // Assert
            actionResult.AssertResult<StatusCodeResult>(HttpStatusCode.Created);

            await _developerService.Received(1).CreateDeveloper(developer);
            _mapper.Received(1).Map<DeveloperDto>(createDeveloperViewModel);
        }

        [Fact]
        public async Task DeleteDeveloper_WhenCalledWithValidId_DeletedAndSaved()
        {
            // Arrange
            const int id = 1;

            var controller = RetrieveController();

            // Act
            var actionResult = await controller.DeleteDeveloper(id);

            // Assert
            actionResult.AssertResult<NoContentResult>();

            await _developerService.Received(1).DeleteDeveloper(id);
        }

        private DevelopersController RetrieveController()
        {
            return new DevelopersController(_logger, _developerService, _mapper);
        }
    }
}
