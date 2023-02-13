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
    public class GameServiceTests
    {
        private readonly IVGLoggerDatabase _database;
        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        public GameServiceTests()
        {
            _database = Substitute.For<IVGLoggerDatabase>();
            _mapper = GetMapper();
            _fixture = new Fixture();

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
        }

        [Fact]
        public void GetGame_WhenGameExists_ReturnsGame()
        {
            // Arrange
            const int id = 1;

            var game = new Game { Id = id };

            var games = new List<Game> { game };

            _database.Get<Game>().Returns(games.AsQueryable());

            var service = RetrieveService();

            // Act
            var result = service.GetGameById(id);

            // Assert
            result.Should().BeEquivalentTo(game, options => options.ExcludingMissingMembers());
        }

        [Fact]
        public void GetGames_WhenGamesExists_ReturnsGameList()
        {
            // Arrange
            var gameList = _fixture.Build<Game>().CreateMany();

            _database.Get<Game>().Returns(gameList.AsQueryable());

            var service = RetrieveService();

            // Act
            var result = service.GetGames();

            // Assert
            result.Should().BeEquivalentTo(gameList, options => options.ExcludingMissingMembers());
        }

        private IGameService RetrieveService()
        {
            return new GameService(_database, _mapper);
        }

        private static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<GameProfile>();
            });

            return new Mapper(config);
        }
    }
}
