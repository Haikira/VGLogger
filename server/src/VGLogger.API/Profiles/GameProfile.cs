using AutoMapper;
using VGLogger.API.ViewModels;
using VGLogger.Service.Dtos;

namespace VGLogger.API.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            MapDtoToViewModel();
            MapViewModelToDto();
        }

        private void MapDtoToViewModel()
        {
            CreateMap<GameDto, GameViewModel>();            
        }

        private void MapViewModelToDto()
        {
            CreateMap<UpdateGameViewModel, GameDto>();
            CreateMap<CreateGameViewModel, GameDto>();
        }
    }
}
