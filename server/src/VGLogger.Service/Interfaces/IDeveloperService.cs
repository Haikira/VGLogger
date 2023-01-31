using VGLogger.Service.Dtos;

namespace VGLogger.Service.Interfaces
{
    public interface IDeveloperService
    {
        Task<List<DeveloperDto>> GetDevelopers();
        Task<DeveloperDto> GetDeveloperById(int id);
        void CreateDeveloper(DeveloperDto developerDto);
        void DeleteDeveloper(int id);                
        void UpdateDeveloper(int id, DeveloperDto developerDto);
    }
}
