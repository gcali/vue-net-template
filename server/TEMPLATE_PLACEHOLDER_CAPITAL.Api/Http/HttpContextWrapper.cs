using System.Security.Claims;
using System.Threading.Tasks;
using TEMPLATE_PLACEHOLDER_CAPITAL.Api.Extensions;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Http;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.RequestExceptions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Api.Http
{
    internal class HttpContextWrapper : IHttpContext
    {
        private readonly HttpContext _httpContext;

        public HttpContextWrapper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }
        public ClaimsPrincipal User => _httpContext.User;
        public int? SafeUserId => _httpContext.UserId();
        public int UserId => _httpContext.UserId() ?? throw new UnauthorizedRequestException();

    }
}