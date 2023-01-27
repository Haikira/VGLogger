using AutoMapper;
using VGLogger.DAL.Models;
using VGLogger.Service.DTOs;

namespace VGLogger.Service.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            ConfigureDomainToDTO();
            ConfigureDTOToDomain();
        }

        private void ConfigureDomainToDTO()
        {
            CreateMap<Platform, PlatformDTO>();
        }

        private void ConfigureDTOToDomain()
        {
            CreateMap<PlatformDTO, Platform>();
        }
    }
}
