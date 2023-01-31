using VGLogger.Service.Dtos;

namespace VGLogger.Service.Interfaces
{
    public interface IGameService
    {
        Task<List<GameDto>> GetGames();
        Task<GameDto> GetGameById(int id);
        void CreateGame(GameDto game);
        void DeleteGame(int id);
        void UpdateGame(int id, GameDto game);
    }
}
