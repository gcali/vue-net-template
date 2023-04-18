using System.Linq;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Services.Auth;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.UserAggregate;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Core.Persistence
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ITEMPLATE_PLACEHOLDER_CAPITALContext _context;
        private readonly IPasswordValidation _passwordValidation;

        private const string MigrationKey = "Metadata";

        public DbInitializer(ITEMPLATE_PLACEHOLDER_CAPITALContext context, IPasswordValidation passwordValidation)
        {
            _context = context;
            _passwordValidation = passwordValidation;
        }

        public void Initialize()
        {
            _context.Migrate();

            var areThereUsers = _context.Users.Any();

            var mainUsername = "giovanni";

            if (!areThereUsers)
            {
                foreach (var user in new[] { mainUsername })
                {
                    var salt = _passwordValidation.GenerateSalt();
                    _context.Users.Add(new User
                    {
                        Username = user,
                    }.SetPassword(hashedPassword: _passwordValidation.HashPassword("TEMPLATE_PLACEHOLDER_LOWER-secret-password", salt), salt: salt));
                }
                _context.SaveChangesSync();
            }

            var mainUser = _context.Users.Where(u => u.Username == mainUsername).Single();

            _context.SaveChanges();

        }
    }
}