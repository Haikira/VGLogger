using AutoMapper;
using VGLogger.DAL.Models;
using VGLogger.Service.DTOs;

namespace VGLogger.Service.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            ConfigureDomainToDTO();
            ConfigureDTOToDomain();
        }

        private void ConfigureDomainToDTO()
        {
            CreateMap<User, UserDTO>();
        }

        private void ConfigureDTOToDomain()
        {
            CreateMap<UserDTO, User>();
        }
    }
}
