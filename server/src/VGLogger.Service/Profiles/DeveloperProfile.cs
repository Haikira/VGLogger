﻿using AutoMapper;
using VGLogger.DAL.Models;
using VGLogger.Service.DTOs;

namespace VGLogger.Service.Profiles
{
    public class DeveloperProfile : Profile
    {
        public DeveloperProfile()
        {
            ConfigureDomainToDTO();
            ConfigureDTOToDomain();
        }

        private void ConfigureDomainToDTO()
        {
            CreateMap<Developer, DeveloperDTO>();
        }

        private void ConfigureDTOToDomain()
        {
            CreateMap<DeveloperDTO, Developer>();
        }
    }
}
