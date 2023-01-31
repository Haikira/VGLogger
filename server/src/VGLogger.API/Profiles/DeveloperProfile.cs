using AutoMapper;
using VGLogger.API.ViewModels;
using VGLogger.Service.Dtos;

namespace VGLogger.API.Profiles
{
    public class DeveloperProfile : Profile
    {
        public DeveloperProfile()
        {
            ConfigureModelToDto();
            ConfigureDtoToModel();
        }

        private void ConfigureModelToDto()
        {
            CreateMap<UpdateDeveloperViewModel, DeveloperDto>();
            CreateMap<CreateDeveloperViewModel, DeveloperDto>();
        }

        private void ConfigureDtoToModel()
        {
            CreateMap<DeveloperDto, DeveloperViewModel>();
        }
    }
}
