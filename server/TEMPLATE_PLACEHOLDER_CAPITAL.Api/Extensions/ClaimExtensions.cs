using System.Linq;
using TEMPLATE_PLACEHOLDER_CAPITAL.Api.Configuration;
using Microsoft.AspNetCore.Http;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Api.Extensions
{
    public static class ClaimExtensions
    {
        public static int? UserId(this HttpContext context) {
            var rawId = context?.User?.Claims?.SingleOrDefault(c => c.Type == Constants.IdClaim)?.Value;
            if (int.TryParse(rawId ?? "", out var id)) {
                return id;
            }
            return null;
        }
    }
}