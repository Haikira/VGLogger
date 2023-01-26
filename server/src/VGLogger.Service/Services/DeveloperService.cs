using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.Service.Interfaces;
using VGLogger.Service.Services.DTOs;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using VGLogger.DAL.Specifications.Developers;

namespace VGLogger.Service.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IVGLoggerDatabase _database;

        public DeveloperService(IVGLoggerDatabase database)
        {
            _database = database;
        }

        public DeveloperDTO GetDeveloperById(int id)
        {
            var platform = _database.Get<Developer>().Where(new DeveloperByIdSpec(id)).SingleOrDefault();

            return new DeveloperDTO { Id = platform.Id, Name = platform.Name };
        }

        public IList<DeveloperDTO> GetDevelopers()
        {
            var developers = _database.Get<Developer>().ToList();

            return developers.Select(x => new DeveloperDTO { Id = x.Id, Name = x.Name }).ToList();
        }
    }
}
