using AutoMapper;
using VGLogger.DAL.Models;
using VGLogger.Service.Dtos;

namespace VGLogger.Service.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            ConfigureDomainToDto();
            ConfigureDtoToDomain();
        }

        private void ConfigureDomainToDto()
        {
            CreateMap<Review, ReviewDto>();
        }

        private void ConfigureDtoToDomain()
        {
            CreateMap<ReviewDto, Review>();
        }
    }
}
