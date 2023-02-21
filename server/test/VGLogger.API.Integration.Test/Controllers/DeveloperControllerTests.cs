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
    public class DeveloperControllerTests
    {
        private readonly HttpClient _httpClient;
        private readonly ITestOutputHelper _testOutputHelper;

        public DeveloperControllerTests(ITestOutputHelper testOutputHelper, IntegrationClassFixture integrationClassFixture)
        {
            _httpClient = integrationClassFixture.Host.CreateClient();
            _testOutputHelper = testOutputHelper;            
        }

        [Fact]
        public async Task GetAll_WhenDevelopersPresent_ReturnsOk()
        {
            var response = await _httpClient.GetAsync("/developers/");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var value = await response.Content.ReadAsStringAsync();
            _testOutputHelper.WriteLine(value.VerifyDeSerialization<DeveloperViewModel[]>());
        }

        [Fact]
        public async Task Create_WhenNewDeveloperDetailsInvalid_ReturnsValidationErrors()
        {
            var newDeveloper = new CreateDeveloperViewModel();

            var response = await _httpClient.PostAsJsonAsync("/developers/", newDeveloper);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var value = await response.Content.ReadAsStringAsync();

            var result = value.VerifyDeSerialize<ValidationModel>();
            result.Errors.CheckIfErrorPresent("Name", "The Name field is required.");

            _testOutputHelper.WriteLine(value);
        }

        [Fact]
        public async Task Update_WhenDeveloperDetailsInvalid_ReturnsValidationErrors()
        {
            var updateDeveloper = new UpdateDeveloperViewModel();

            var response = await _httpClient.PostAsJsonAsync("/developers/", updateDeveloper);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var value = await response.Content.ReadAsStringAsync();

            var result = value.VerifyDeSerialize<ValidationModel>();
            result.Errors.CheckIfErrorPresent("Name", "The Name field is required.");

            _testOutputHelper.WriteLine(value);
        }
    }
}
