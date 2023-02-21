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
    public class PlatformControllerTests
    {
        private readonly HttpClient _httpClient;
        private readonly ITestOutputHelper _testOutputHelper;

        public PlatformControllerTests(ITestOutputHelper testOutputHelper, IntegrationClassFixture integrationClassFixture)
        {
            _httpClient = integrationClassFixture.Host.CreateClient();
            _testOutputHelper = testOutputHelper;            
        }

        [Fact]
        public async Task GetAll_WhenPlatformsPresent_ReturnsOk()
        {
            var response = await _httpClient.GetAsync("/platforms/");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var value = await response.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(value.VerifyDeSerialization<PlatformViewModel[]>());
        }

        [Fact]
        public async Task Create_WhenNewPlatformDetailsInvalid_ReturnsValidationErrors()
        {
            var newPlatform = new CreatePlatformViewModel();

            var response = await _httpClient.PostAsJsonAsync("/platforms/", newPlatform);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var value = await response.Content.ReadAsStringAsync();

            var result = value.VerifyDeSerialize<ValidationModel>();
            result.Errors.CheckIfErrorPresent("Name", "Name must not be null");

            _testOutputHelper.WriteLine(value);
        }

        [Fact]
        public async Task Update_WhenPlatformDetailsInvalid_ReturnsValidationErrors()
        {
            var updatePlatform = new UpdatePlatformViewModel();

            var response = await _httpClient.PostAsJsonAsync("/platforms/", updatePlatform);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var value = await response.Content.ReadAsStringAsync();

            var result = value.VerifyDeSerialize<ValidationModel>();
            result.Errors.CheckIfErrorPresent("Name", "Name must not be null");

            _testOutputHelper.WriteLine(value);
        }
    }
}












