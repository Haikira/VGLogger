using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.EFCore.Extensions;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.DAL.Specifications.Games;
using VGLogger.Service.Dtos;
using VGLogger.Service.Exceptions;
using VGLogger.Service.Interfaces;

namespace VGLogger.Service.Services
{
    public class GameService : IGameService
    {
        private readonly IVGLoggerDatabase _database;
        private readonly IMapper _mapper;

        public GameService(IVGLoggerDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }
        public async Task CreateGame(GameDto game)
        {
            var gameToCreate = _mapper.Map<Game>(game);
            _database.AddAsync(gameToCreate);
            await _database.SaveChangesAsync();
        }

        public async Task DeleteGame(int id)
        {
            var gameToDelete = await _database.Get<Game>().FirstOrDefaultAsync(new GameByIdSpec(id));

            if (gameToDelete == null) throw new NotFoundException($"Could not find game with id: {id}");

            _database.Delete(gameToDelete);
            await _database.SaveChangesAsync();
        }

        public async Task<GameDto> GetGameById(int id)
        {
            var game = await _mapper.ProjectTo<GameDto>(_database
                .Get<Game>()
                .Where(new GameByIdSpec(id))
                ).SingleOrDefaultAsync();

            return game ?? throw new NotFoundException($"Could not find game with ID: {id}");
        }

        public async Task<List<GameDto>> GetGames()
        {
            return await _mapper.ProjectTo<GameDto>(_database.Get<Game>()).ToListAsync();
        }

        public async Task UpdateGame(int id, GameDto game)
        {
            var existingGame = await _database.Get<Game>().FirstOrDefaultAsync(new GameByIdSpec(id));

            if (existingGame == null) throw new NotFoundException($"Could not find game with ID: {id}");

            _mapper.Map(game, existingGame);

            await _database.SaveChangesAsync();
        }
    }
}
