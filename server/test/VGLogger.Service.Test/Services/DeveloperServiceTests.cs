using AutoFixture;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
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
        public void GetDeveloper_WhenDeveloperExists_ReturnsDeveloper()
        {
            // Arrange
            const int id = 1;

            var developer = new Developer { Id = id };

            var developers = new List<Developer> { developer };

            _database.Get<Developer>().Returns(developers.AsQueryable());

            var service = RetrieveService();

            // Act
            var result = service.GetDeveloperById(id);

            // Assert
            result.Should().BeEquivalentTo(developer, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void GetDevelopers_WhenDevelopersExist_ReturnsDeveloperList()
        {
            // Arrange
            var developerList = _fixture.Build<Developer>().CreateMany();

            _database.Get<Developer>().Returns(developerList.AsQueryable());

            var service = RetrieveService();

            // Act
            var result = service.GetDevelopers();

            // Assert
            result.Should().BeEquivalentTo(developerList, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void UpdateDeveloper_DevelopersDoesNotExist_ThrowNotFoundException()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public void DeleteDeveloper_DevelopersDoesNotExist_ThrowNotFoundException()
        {
            // Arrange

            // Act

            // Assert
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
