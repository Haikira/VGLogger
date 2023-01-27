using AutoMapper;
using VGLogger.DAL.Models;
using VGLogger.Service.DTOs;

namespace VGLogger.Service.Profiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            ConfigureDomainToDTO();
            ConfigureDTOToDomain();
        }

        private void ConfigureDomainToDTO()
        {
            CreateMap<Review, ReviewDTO>();
        }

        private void ConfigureDTOToDomain()
        {
            CreateMap<ReviewDTO, Review>();
        }
    }
}
