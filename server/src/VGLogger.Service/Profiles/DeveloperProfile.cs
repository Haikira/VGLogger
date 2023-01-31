using AutoMapper;
using VGLogger.DAL.Models;
using VGLogger.Service.Dtos;

namespace VGLogger.Service.Profiles
{
    public class DeveloperProfile : Profile
    {
        public DeveloperProfile()
        {
            ConfigureDomainToDto();
            ConfigureDtoToDomain();
        }

        private void ConfigureDomainToDto()
        {
            CreateMap<Developer, DeveloperDto>();
        }

        private void ConfigureDtoToDomain()
        {
            CreateMap<DeveloperDto, Developer>();
        }
    }
}
