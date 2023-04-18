using TEMPLATE_PLACEHOLDER_CAPITAL.Api.Http;
using TEMPLATE_PLACEHOLDER_CAPITAL.Api.Services;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Http;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Services.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Api.Configuration
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IHttpContext, HttpContextWrapper>()
                .AddTransient<ILoginService, CookieLoginService>()
            ;
        }
    }
}