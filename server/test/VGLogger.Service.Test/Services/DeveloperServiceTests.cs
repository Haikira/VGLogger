using AutoFixture;
using AutoMapper;
using FluentAssertions;
using MockQueryable.NSubstitute;
using NSubstitute;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.Service.Exceptions;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Profiles;
using VGLogger.Service.Services;

namespace VGLogger.Service.Test.Services
{
    public class DeveloperServiceTests
    {
        private readonly IVGLoggerDatabase _database;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        public DeveloperServiceTests()
        {
            _database = Substitute.For<IVGLoggerDatabase>();
            _mapper = GetMapper();
            _fixture = new Fixture();

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
        }

        [Fact]
        public async Task DeleteDeveloper_DeveloperDoesNotExist_ThrowNotFoundException()
        {
            // Arrange 
            const int correctId = 1;
            const int incorrectId = 2;

            var correctDeveloper = _fixture.Build<Developer>().With(x => x.Id, correctId).Create();
            var incorrectDeveloper = _fixture.Build<Developer>().With(x => x.Id, incorrectId).Create();

            _database.Get<Developer>().Returns(new List<Developer> { incorrectDeveloper }.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => service.DeleteDeveloper(correctId));
            _database.Received(1).Get<Developer>();
        }

        [Fact]
        public async Task GetDeveloper_WhenDeveloperExists_ReturnsDeveloper()
        {
            // Arrange
            const int id = 1;

            var developer = new Developer { Id = id };
            var developers = new List<Developer> { developer };

            _database.Get<Developer>().Returns(developers.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = await service.GetDeveloperById(id);

            // Assert
            result.Should().BeEquivalentTo(developer, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public async Task GetDevelopers_WhenDevelopersExist_ReturnsDeveloperListAsync()
        {
            // Arrange
            var developers = _fixture.Build<Developer>().CreateMany();

            _database.Get<Developer>().Returns(developers.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = await service.GetDevelopers();

            // Assert
            result.Should().BeEquivalentTo(developers, options => options.ExcludingMissingMembers());
        }

        private IDeveloperService RetrieveService()
        {
            return new DeveloperService(_database, _mapper);
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<DeveloperProfile>();
            });

            return new Mapper(config);
        }
    }
}
