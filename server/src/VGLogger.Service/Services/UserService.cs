using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using Unosquare.EntityFramework.Specification.EFCore.Extensions;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.DAL.Specifications.Users;
using VGLogger.Service.Dtos;
using VGLogger.Service.Exceptions;
using VGLogger.Service.Interfaces;

namespace VGLogger.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IVGLoggerDatabase _database;
        private readonly IMapper _mapper;

        public UserService(IVGLoggerDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public async Task CreateUser(UserDto user)
        {
            var newUser = _mapper.Map<User>(user);
            _database.AddAsync(newUser);
            await _database.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var userToDelete = await _database.Get<User>().Where(new UserByIdSpec(id)).FirstOrDefaultAsync();

            if (userToDelete == null) throw new NotFoundException($"Could not find user with id: {id}");

            _database.Delete(userToDelete);
            await _database.SaveChangesAsync();
        }

        public async Task<UserDto> GetUserById(int id)
        {
            var user = await _mapper.ProjectTo<UserDto>(_database
                .Get<User>()
                .Where(new UserByIdSpec(id))
                ).SingleOrDefaultAsync();

            return user ?? throw new NotFoundException($"Could not find user with ID: {id}");
        }

        public Task<List<UserDto>> GetUsers()
        {
            return _mapper.ProjectTo<UserDto>(_database.Get<User>()).ToListAsync();
        }

        public async Task UpdateUser(int id, UserDto user)
        {
            var existingUser = await _database.Get<User>().FirstOrDefaultAsync(new UserByIdSpec(id));

            if (existingUser == null) throw new NotFoundException($"Could not find user with ID: {id}");

            _mapper.Map(user, existingUser);
            await _database.SaveChangesAsync();
        }
    }
}