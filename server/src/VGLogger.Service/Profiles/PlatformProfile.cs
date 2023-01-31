using AutoMapper;
using VGLogger.DAL.Models;
using VGLogger.Service.Dtos;

namespace VGLogger.Service.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            ConfigureDomainToDto();
            ConfigureDtoToDomain();
        }

        private void ConfigureDomainToDto()
        {
            CreateMap<Platform, PlatformDto>();
        }

        private void ConfigureDtoToDomain()
        {
            CreateMap<PlatformDto, Platform>();
        }
    }
}
