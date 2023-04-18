using System.Threading.Tasks;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Core.Services.Auth
{
    public interface ILoginService
    {
        Task<string> CurrentUser { get; }
        Task SignIn(string user, int id);
        Task SignOut();
    }
}