using VGLogger.Service.Dtos;

namespace VGLogger.Service.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers();
        Task<UserDto> GetUserById(int id);
        Task CreateUser(UserDto user);
        Task DeleteUser(int id);
        Task UpdateUser(int id, UserDto user);
        Task<List<GameDto>> GetUserGames(int userId);
        Task UpdateUserGames();
        Task CreateUserGames();
    }
}
