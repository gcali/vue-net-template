using System.Security.Claims;
using System.Threading.Tasks;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Core.Http
{
    public interface IHttpContext
    {
        ClaimsPrincipal User { get; }
        int? SafeUserId { get; }
        int UserId { get; }
    }
}