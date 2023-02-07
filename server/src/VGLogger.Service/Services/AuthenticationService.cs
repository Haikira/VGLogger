using AutoMapper;
using Unosquare.EntityFramework.Specification.Common.Extensions;
using VGLogger.DAL.Interfaces;
using VGLogger.DAL.Models;
using VGLogger.DAL.Specifications.Users;
using VGLogger.Service.Dtos;
using VGLogger.Service.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace VGLogger.Service.Services
{
    public class AuthenticationService : IAuthenticateService
    {
        private readonly IVGLoggerDatabase _database;
        private readonly IMapper _mapper;

        public AuthenticationService(IVGLoggerDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        public UserDto? Authenticate(string email, string password)
        {
            var user = _database.Get<User>().Where(new UserByEmailSpec(email)).SingleOrDefault();

            if (user is null || !BC.Verify(password, user.Password))
                return null;

            return _mapper.Map<UserDto>(user);
        }


    }
}
