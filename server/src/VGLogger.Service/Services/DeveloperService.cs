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

        public async Task CreateDeveloper(DeveloperDto developer)
        {
            var developerToCreate = _mapper.Map<Developer>(developer);
            _database.AddAsync(developerToCreate);
            await _database.SaveChangesAsync();
        }

        public async Task DeleteDeveloper(int id)
        {
            var developerToDelete = await _database.Get<Developer>().Where(new DeveloperByIdSpec(id)).SingleOrDefaultAsync();

            if (developerToDelete == null) throw new NotFoundException($"Could not find developer with id: {id}");

            _database.Delete(developerToDelete);
            await _database.SaveChangesAsync();
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

        public async Task UpdateDeveloper(int id, DeveloperDto developer)
        {
            var existingDeveloper = await _database.Get<Developer>().Where(new DeveloperByIdSpec(id)).FirstOrDefaultAsync();

            if (existingDeveloper == null) throw new NotFoundException($"Could not find developer with id: {id}");

            _mapper.Map(developer, existingDeveloper);

            await _database.SaveChangesAsync();
        }
    }
}
