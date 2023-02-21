using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using VGLogger.API.Integration.Test.Base;
using VGLogger.API.Integration.Test.Models;
using VGLogger.API.Integration.Test.TestUtilities;
using VGLogger.API.ViewModels;
using Xunit.Abstractions;

namespace VGLogger.API.Integration.Test.Controllers
{
    [Collection("Integration")]
    public class GameControllerTests
    {
        private readonly HttpClient _httpClient;
        private readonly ITestOutputHelper _testOutputHelper;

        public GameControllerTests(ITestOutputHelper testOutputHelper, IntegrationClassFixture integrationClassFixture)
        {
            _httpClient = integrationClassFixture.Host.CreateClient();
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task GetAll_WhenGamesExist_ReturnsOk()
        {
            var response = await _httpClient.GetAsync("/games/");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var value = await response.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(value);
        }

        [Fact]
        public async Task GetById_WhenGameExists_ReturnsOk()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async Task Create_WhenNewGameDetailsInvalid_ReturnsValidationErrors()
        {
            var newGame = new CreateGameViewModel();

            var response = await _httpClient.PostAsJsonAsync("/games/", newGame);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var value = await response.Content.ReadAsStringAsync();

            var result = value.VerifyDeSerialize<ValidationModel>();
            result.Errors.CheckIfErrorPresent("Name", "Name must not be null");
            result.Errors.CheckIfErrorPresent("Description", "Description must not be null");

            _testOutputHelper.WriteLine(value);
        }

        [Fact]
        public async Task Update_WhenNewGameDetailsInvalid_ReturnsValidationErrors()
        {
            throw new NotImplementedException();
        }
    }
}
