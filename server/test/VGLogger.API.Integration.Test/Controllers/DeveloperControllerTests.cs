using FluentAssertions;
using System.Net;
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
    }
}
