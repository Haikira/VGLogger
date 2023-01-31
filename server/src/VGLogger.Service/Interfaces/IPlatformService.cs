using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGLogger.Service.Dtos;

namespace VGLogger.Service.Interfaces
{
    public interface IPlatformService
    {
        Task<List<PlatformDto>> GetPlatforms();
        Task<PlatformDto> GetPlatformById(int id);
        void CreatePlatform(PlatformDto platform);
        void DeletePlatform(int id);
        void UpdatePlatform(int id, PlatformDto platform);
    }
}
