using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.Service.Dtos;
using VGLogger.Service.Interfaces;
using VGLogger.DAL.Specifications.Users;
using VGLogger.DAL.Specifications.Games;
using Unosquare.EntityFramework.Specification.Common.Extensions;

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
        public void CreateGame(GameDto game)
        {
            var newGame = _mapper.Map<Game>(game);
            _database.Add(newGame);
            _database.SaveChanges();
        }

        public void DeleteGame(int id)
        {
            var gameToDelete = _database.Get<Game>().Where(new GameByIdSpec(id));
            _database.Delete(gameToDelete);
            _database.SaveChanges();
        }

        public Task<GameDto> GetGameById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GameDto>> GetGames()
        {
            return _mapper.ProjectTo<GameDto>(_database.Get<Game>()).ToListAsync();
        }

        public void UpdateGame(int id, GameDto game)
        {
            throw new NotImplementedException();
        }
    }
}
