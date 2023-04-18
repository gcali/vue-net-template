using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Persistence;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Services;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Core
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
            =>
                services
                    .AddTransient<IDbInitializer, DbInitializer>()
                    .AddTransient<IPasswordValidation, PasswordValidation>()
                    .AddTransient<IAuthService, AuthService>()
                    .AddTransient<IUserService, UserService>()
            ;
    }
}