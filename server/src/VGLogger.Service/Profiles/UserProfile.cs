using AutoMapper;
using VGLogger.DAL.Models;
using VGLogger.Service.Dtos;

namespace VGLogger.Service.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            ConfigureDomainToDto();
            ConfigureDtoToDomain();
        }

        private void ConfigureDomainToDto()
        {
            CreateMap<User, UserDto>();
        }

        private void ConfigureDtoToDomain()
        {
            CreateMap<UserDto, User>();
        }
    }
}
