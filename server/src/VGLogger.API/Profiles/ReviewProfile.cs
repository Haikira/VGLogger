using AutoMapper;
using VGLogger.API.ViewModels;
using VGLogger.Service.Dtos;

namespace VGLogger.API.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            MapDtoToViewModel();
            MapViewModelToDto();
        }

        private void MapDtoToViewModel()
        {
            CreateMap<ReviewDto, ReviewViewModel>();
        }

        private void MapViewModelToDto()
        {
            CreateMap<UpdateReviewViewModel, ReviewDto>();
            CreateMap<CreateReviewViewModel, ReviewDto>();
        }
    }
}
