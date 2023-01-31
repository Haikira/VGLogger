using AutoMapper;
using VGLogger.DAL.Models;
using VGLogger.Service.Dtos;

namespace VGLogger.Service.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            ConfigureDomainToDto();
            ConfigureDtoToDomain();
        }

        private void ConfigureDomainToDto()
        {
            CreateMap<Game, GameDto>();
        }

        private void ConfigureDtoToDomain()
        {
            CreateMap<GameDto, Game>();
        }
    }
}
