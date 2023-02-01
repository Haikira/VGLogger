using VGLogger.Service.Dtos;

namespace VGLogger.Service.Interfaces
{
    public interface IDeveloperService
    {
        Task<List<DeveloperDto>> GetDevelopers();
        Task<DeveloperDto> GetDeveloperById(int id);
        Task CreateDeveloper(DeveloperDto developerDto);
        Task DeleteDeveloper(int id);
        Task UpdateDeveloper(int id, DeveloperDto developerDto);
    }
}
