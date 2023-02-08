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
            CreateMap<Game, GameDto>()
                .ForMember(d => d.Platforms, s => s.MapFrom(x => x.GamePlatforms.Select(y => y.Platform)));
        }

        private void ConfigureDtoToDomain()
        {
            CreateMap<GameDto, Game>();
        }
    }
}
