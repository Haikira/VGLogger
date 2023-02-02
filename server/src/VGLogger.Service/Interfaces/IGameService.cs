using VGLogger.Service.Dtos;

namespace VGLogger.Service.Interfaces
{
    public interface IGameService
    {
        Task<List<GameDto>> GetGames();
        Task<GameDto> GetGameById(int id);
        Task CreateGame(GameDto game);
        Task DeleteGame(int id);
        Task UpdateGame(int id, GameDto game);
    }
}
