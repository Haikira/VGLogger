using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.DAL.Specifications.Platforms;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Services.DTOs;
using Unosquare.EntityFramework.Specification.Common.Extensions;

namespace VGLogger.Service.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IVGLoggerDatabase _database;

        public PlatformService(IVGLoggerDatabase database)
        {
            _database = database;
        }

        public IList<PlatformDTO> GetPlatforms()
        {
            var platforms = _database.Get<Platform>().ToList();

            return platforms.Select(x => new PlatformDTO { Id = x.Id, Name = x.Name }).ToList();
        }

        public PlatformDTO GetPlatformById(int id)
        {
            var platform = _database.Get<Platform>().Where(new PlatformByIdSpec(id)).SingleOrDefault();

            return new PlatformDTO { Id = platform.Id, Name = platform.Name };
        }
    }
}
