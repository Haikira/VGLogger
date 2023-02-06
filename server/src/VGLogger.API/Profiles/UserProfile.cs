using AutoMapper;
using VGLogger.API.ViewModels;
using VGLogger.Service.Dtos;

namespace VGLogger.API.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            MapDtoToViewModel();
            MapViewModelToDto();
        }

        private void MapDtoToViewModel()
        {
            CreateMap<UserDto, UserViewModel>();
        }

        private void MapViewModelToDto()
        {
            CreateMap<UpdateUserViewModel, UserDto>();
            CreateMap<CreateUserViewModel, UserDto>();
        }
    }
}
