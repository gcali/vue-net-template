using System.Threading.Tasks;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.RequestExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Api.Filters
{
    public class UnauthorizedFilter : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            await base.OnExceptionAsync(context);
            if (context.Exception is UnauthorizedRequestException exception) {
                context.ExceptionHandled = true;
                context.Result = new UnauthorizedObjectResult("Unauthorized");
            }
        }
    }
}