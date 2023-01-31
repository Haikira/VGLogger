using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.DAL.Specifications.Developers;
using VGLogger.Service.Dtos;
using VGLogger.Service.Exceptions;
using VGLogger.Service.Interfaces;

namespace VGLogger.Service.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IVGLoggerDatabase _database;
        private readonly IMapper _mapper;

        public DeveloperService(IVGLoggerDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public void CreateDeveloper(DeveloperDto developer)
        {
            var developerToCreate = _mapper.Map<Developer>(developer);
            _database.Add(developerToCreate);
            _database.SaveChanges();
        }

        public void DeleteDeveloper(int id)
        {
            var developerToDelete = _database.Get<Developer>().Where(new DeveloperByIdSpec(id));
            _database.Delete(developerToDelete);
            _database.SaveChanges();
        }

        public async Task<DeveloperDto> GetDeveloperById(int id)
        {
            var developer = await _mapper.ProjectTo<DeveloperDto>(_database
                .Get<Developer>()
                .Where(new DeveloperByIdSpec(id))
                ).SingleOrDefaultAsync();

            return developer ?? throw new NotFoundException($"Could not find developer with ID: {id}");
        }

        public Task<List<DeveloperDto>> GetDevelopers()
        {
            return _mapper.ProjectTo<DeveloperDto>(_database.Get<Developer>()).ToListAsync();
        }

        public void UpdateDeveloper(int id, DeveloperDto developer)
        {
            var existingDeveloper = _database.Get<Developer>().FirstOrDefault(new DeveloperByIdSpec(id));

            if (existingDeveloper == null) throw new NotFoundException($"Could not find developer with id: {id}");

            _mapper.Map(developer, existingDeveloper);

            _database.SaveChanges();
        }
    }
}
