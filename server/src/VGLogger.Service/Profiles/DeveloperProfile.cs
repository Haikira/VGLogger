using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
