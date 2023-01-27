using VGLogger.Service.DTOs;

namespace VGLogger.Service.Interfaces
{
    public interface IDeveloperService
    {
        Task<List<DeveloperDTO>> GetDevelopers();

        Task<DeveloperDTO> GetDeveloperById(int id);

        bool UpdateDeveloper(DeveloperDTO developerDTO);

        bool CreateDeveloper(DeveloperDTO developerDTO);

        bool DeleteDeveloper(int id);
    }
}
