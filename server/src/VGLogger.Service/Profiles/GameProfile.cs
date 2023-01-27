using AutoMapper;
using VGLogger.DAL.Models;
using VGLogger.Service.DTOs;

namespace VGLogger.Service.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            ConfigureDomainToDTO();
            ConfigureDTOToDomain();
        }

        private void ConfigureDomainToDTO()
        {
            CreateMap<Game, GameDTO>();
        }

        private void ConfigureDTOToDomain()
        {
            CreateMap<GameDTO, Game>();
        }
    }
}
