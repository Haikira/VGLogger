using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.Service.Interfaces;
using VGLogger.Service.DTOs;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using VGLogger.DAL.Specifications.Developers;
using Microsoft.EntityFrameworkCore;
using VGLogger.Service.Exceptions;
using System.Runtime.CompilerServices;
using AutoMapper;

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

        public bool CreateDeveloper(DeveloperDTO developerDTO)
        {
            var developerToCreate = _mapper.Map<Developer>(developerDTO);
            _database.Add(developerToCreate);
            _database.SaveChanges();
            return true;
        }

        public bool DeleteDeveloper(int id)
        {
            var developerToDelete = _database.Get<Developer>().Where(new DeveloperByIdSpec(id));
            _database.Delete(developerToDelete);
            _database.SaveChanges();
            return true;
        }

        public async Task<DeveloperDTO> GetDeveloperById(int id)
        {
            var developer = await _mapper.ProjectTo<DeveloperDTO>(_database
                .Get<Developer>()
                .Where(new DeveloperByIdSpec(id))
                ).SingleOrDefaultAsync();

            return developer ?? throw new NotFoundException($"Could not find developer with ID: {id}");
        }

        public Task<List<DeveloperDTO>> GetDevelopers()
        {
            return _mapper.ProjectTo<DeveloperDTO>(_database.Get<Developer>()).ToListAsync();
        }

        public bool UpdateDeveloper(DeveloperDTO developerDTO)
        {
            var developerToSave = _mapper.Map<Developer>(developerDTO);
            // Update
            _database.SaveChanges();
            return true;
        }
    }
}
