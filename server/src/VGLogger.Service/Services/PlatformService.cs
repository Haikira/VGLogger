using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.DAL.Specifications.Platforms;
using VGLogger.Service.Dtos;
using VGLogger.Service.Exceptions;
using VGLogger.Service.Interfaces;

namespace VGLogger.Service.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IVGLoggerDatabase _database;
        private readonly IMapper _mapper;

        public PlatformService(IVGLoggerDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task CreatePlatform(PlatformDto platform)
        {
            var platformToCreate = _mapper.Map<Platform>(platform);
            _database.AddAsync(platformToCreate);
            await _database.SaveChangesAsync();
        }

        public async Task DeletePlatform(int id)
        {
            var platformToDelete = _database.Get<Platform>().Where(new PlatformByIdSpec(id));

            if (platformToDelete == null) throw new NotFoundException($"Could not find platform with id: {id}");

            _database.Delete(platformToDelete);
            await _database.SaveChangesAsync();
        }

        public async Task<PlatformDto> GetPlatformById(int id)
        {
            var platform = await _mapper.ProjectTo<PlatformDto>(
                    _database.Get<Platform>().Where(new PlatformByIdSpec(id))
                ).SingleOrDefaultAsync();

            return platform ?? throw new NotFoundException($"Could not find platform with ID: {id}");
        }

        public Task<List<PlatformDto>> GetPlatforms()
        {
            return _mapper.ProjectTo<PlatformDto>(_database.Get<Platform>()).ToListAsync();
        }
        public async Task UpdatePlatform(int id, PlatformDto platform)
        {
            var existingPlatform = await _database.Get<Platform>().Where(new PlatformByIdSpec(id)).FirstOrDefaultAsync();

            if (existingPlatform == null) throw new NotFoundException($"Could not find platform with ID: {id}");

            _mapper.Map(platform, existingPlatform);

            await _database.SaveChangesAsync();
        }
    }
}
