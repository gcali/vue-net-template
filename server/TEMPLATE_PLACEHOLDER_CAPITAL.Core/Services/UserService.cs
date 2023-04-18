using System;
using System.Linq;
using System.Threading.Tasks;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Persistence;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.RequestExceptions;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Services.Auth;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Core.Services
{
    public interface IUserService 
    {
        Task<int> CreateUser(string username, string password);
    }

    internal class UserService : IUserService
    {
        private readonly ITEMPLATE_PLACEHOLDER_CAPITALContext _context;
        private readonly IPasswordValidation _passwordValidation;

        public UserService(ITEMPLATE_PLACEHOLDER_CAPITALContext context, IPasswordValidation passwordValidation)
        {
            _context = context;
            _passwordValidation = passwordValidation;
        }
        public async Task<int> CreateUser(string username, string password)
        {
            if (username == null || username.Length < 3) {
                throw new BadRequestException("Invalid username");
            }
            if (password == null || password.Length < 8) {
                throw new BadRequestException("Invalid password");
            }
            var existingUser = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (existingUser != null) 
            {
                throw new BadRequestException("User already exists");
            }
            var salt = _passwordValidation.GenerateSalt();
            var newUser = new User
            {
                Username = username,
            }.SetPassword(
                salt: salt,
                hashedPassword: _passwordValidation.HashPassword(password, salt)
            );

            await _context.Add(newUser);
            await _context.SaveChanges();

            return newUser.Id;
        }
    }
}