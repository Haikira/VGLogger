using AutoMapper;
using VGLogger.API.ViewModels;
using VGLogger.Service.Dtos;

namespace VGLogger.API.Profiles
{
    public class DeveloperProfile : Profile
    {
        public DeveloperProfile()
        {
            ConfigureViewModelToDto();
            ConfigureDtoToViewModel();
        }

        private void ConfigureViewModelToDto()
        {
            CreateMap<UpdateDeveloperViewModel, DeveloperDto>();
            CreateMap<CreateDeveloperViewModel, DeveloperDto>();
        }

        private void ConfigureDtoToViewModel()
        {
            CreateMap<DeveloperDto, DeveloperViewModel>();
        }
    }
}
