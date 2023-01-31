using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.DAL.Specifications.Platforms;
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

        public void CreateUser(UserDto user)
        {
            var newUser = _mapper.Map<User>(user);
            _database.Add(newUser);
            _database.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var userToDelete = _database.Get<User>().Where(new UserByIdSpec(id));
            _database.Delete(userToDelete);
            _database.SaveChanges();
        }

        public Task<UserDto> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetUsers()
        {
            return _mapper.ProjectTo<UserDto>(_database.Get<User>()).ToListAsync();
        }

        public void UpdateUser(int id, UserDto user)
        {
            var existingUser = _database.Get<User>().FirstOrDefault(new UserByIdSpec(id));

            if (existingUser == null) throw new NotFoundException($"Could not find user with ID: {id}");

            _mapper.Map(user, existingUser);
            _database.SaveChanges();
        }
    }
}
