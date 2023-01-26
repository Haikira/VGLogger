using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGLogger.Service.Services.DTOs;

namespace VGLogger.Service.Interfaces
{
    public interface IPlatformService
    {
        IList<PlatformDTO> GetPlatforms();

        PlatformDTO GetPlatformById(int id);
    }
}
