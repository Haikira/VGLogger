using VGLogger.Service.Services.DTOs;

namespace VGLogger.Service.Interfaces
{
    public interface IDeveloperService
    {
        IList<DeveloperDTO> GetDevelopers();

        DeveloperDTO GetDeveloperById(int id);

        bool UpdateDeveloper(DeveloperDTO developerDTO);

        bool CreateDeveloper(DeveloperDTO developerDTO);

        bool DeleteDeveloper(int id);
    }
}
