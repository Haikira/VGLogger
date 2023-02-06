using VGLogger.Service.Dtos;

namespace VGLogger.Service.Interfaces
{
    public interface IAuthenticateService
    {
        UserDto? Authenticate(string email, string password);
    }
}
