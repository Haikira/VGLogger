using AutoFixture;
using AutoMapper;
using FluentAssertions;
using MockQueryable.NSubstitute;
using NSubstitute;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Profiles;
using VGLogger.Service.Services;

namespace VGLogger.Service.Test.Services
{
    public class PlatformServiceTests
    {
        private readonly IVGLoggerDatabase _database;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        public PlatformServiceTests()
        {
            _database = Substitute.For<IVGLoggerDatabase>();
            _mapper = GetMapper();
            _fixture = new Fixture();

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
        }

        [Fact]
        public async Task GetPlatform_WhenPlatformExists_ReturnsPlatform()
        {
            // Arrange
            const int id = 1;

            var platform = new Platform { Id = id };
            var platforms = new List<Platform> { platform };

            _database.Get<Platform>().Returns(platforms.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = await service.GetPlatformById(id);

            // Assert
            result.Should().BeEquivalentTo(platform, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public async Task GetPlatforms_WhenPlatformsExists_ReturnsPlatformList()
        {
            // Arrange
            var platforms = _fixture.Build<Platform>().CreateMany();

            _database.Get<Platform>().Returns(platforms.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = await service.GetPlatforms();

            // Assert
            result.Should().BeEquivalentTo(platforms, options => options.ExcludingMissingMembers());
        }

        private IPlatformService RetrieveService()
        {
            return new PlatformService(_database, _mapper);
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<PlatformProfile>();
            });

            return new Mapper(config);
        }
    }
}
