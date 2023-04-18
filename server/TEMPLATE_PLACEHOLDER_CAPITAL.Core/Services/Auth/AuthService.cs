using System.Threading.Tasks;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Persistence;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.RequestExceptions;
using Microsoft.EntityFrameworkCore;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Core.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly ITEMPLATE_PLACEHOLDER_CAPITALContext _context;
        private readonly IPasswordValidation _passwordValidation;

        public AuthService(ITEMPLATE_PLACEHOLDER_CAPITALContext context, IPasswordValidation passwordValidation)
        {
            _context = context;
            _passwordValidation = passwordValidation;
        }

        public async Task ChangePassword(int userId, string currentPassword, string newPassword)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new BadRequestException("User doesn't exist");
            }
            if (newPassword == null || newPassword.Length < 8)
            {
                throw new BadRequestException("Invalid password");
            }
            var isSame = _passwordValidation.IsSamePassword(currentPassword, user.HashedPassword, user.Salt);
            if (!isSame)
            {
                throw new BadRequestException("Wrong password");
            }
            var newSalt = _passwordValidation.GenerateSalt();
            user.SetPassword(
                hashedPassword: _passwordValidation.HashPassword(newPassword, newSalt),
                salt: newSalt
            );
            await _context.SaveChanges();
        }

        public async Task<int?> Check(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                return null;
            }
            if (_passwordValidation.IsSamePassword(password, user.HashedPassword, user.Salt))
            {
                return user.Id;
            }
            return null;
        }
    }
}