using VGLogger.Service.Dtos;

namespace VGLogger.Service.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsers();
        Task<UserDto> GetUserById(int id);
        void CreateUser(UserDto user);
        void DeleteUser(int id);
        void UpdateUser(int id, UserDto user);
    }
}
