using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString) 
        {
            return services.AddDbContext<ITEMPLATE_PLACEHOLDER_CAPITALContext, TEMPLATE_PLACEHOLDER_CAPITALContext>(options => options.UseSqlite(connectionString));
        }
    }
}