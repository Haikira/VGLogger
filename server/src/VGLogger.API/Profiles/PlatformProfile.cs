using AutoMapper;
using VGLogger.API.ViewModels;
using VGLogger.Service.Dtos;

namespace VGLogger.API.Profiles
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            MapDtoToViewModel();
            MapViewModelToDto();
        }

        private void MapDtoToViewModel()
        {
            CreateMap<PlatformDto, PlatformViewModel>();
        }

        private void MapViewModelToDto()
        {
            CreateMap<CreatePlatformViewModel, PlatformDto>();
            CreateMap<UpdatePlatformViewModel, PlatformDto>();
        }
    }
}
