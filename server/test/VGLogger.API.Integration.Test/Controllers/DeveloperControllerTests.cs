using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
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

        public DeveloperControllerTests(ITestOutputHelper testOutputHelper, HttpClient httpClient)
        {
            _httpClient = httpClient;
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
            CreateDeveloperViewModel newDeveloper = new CreateDeveloperViewModel();

            var response = await _httpClient.PostAsJsonAsync("/developers/", newDeveloper);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var value = await response.Content.ReadAsStringAsync();

            var result = value.VerifyDeSerialize<ValidationModel>();
            result.Errors.CheckIfErrorPresent("Name", "Name must be not null");

            _testOutputHelper.WriteLine(value);
        }
    }
}
