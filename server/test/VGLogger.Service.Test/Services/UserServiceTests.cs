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
    public class UserServiceTests
    {
        private readonly IVGLoggerDatabase _database;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        public UserServiceTests()
        {
            _database = Substitute.For<IVGLoggerDatabase>();
            _mapper = GetMapper();
            _fixture = new Fixture();

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
        }

        [Fact]
        public async Task GetUser_WhenUserExists_ReturnsUser()
        {
            // Arrange
            const int id = 1;

            var user = new User { Id = id };
            var users = new List<User> { user };

            _database.Get<User>().Returns(users.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = await service.GetUserById(id);

            // Assert
            result.Should().BeEquivalentTo(user, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public async Task GetUsers_WhenUsersExists_ReturnsUserList()
        {
            // Arrange
            var users = _fixture.Build<User>().CreateMany();

            _database.Get<User>().Returns(users.AsQueryable().BuildMock());

            var service = RetrieveService();

            // Act
            var result = await service.GetUsers();

            // Assert
            result.Should().BeEquivalentTo(users, options => options.ExcludingMissingMembers());
        }

        private IUserService RetrieveService()
        {
            return new UserService(_database, _mapper);
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<UserProfile>();
            });

            return new Mapper(config);
        }
    }
}
