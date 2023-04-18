using System.Threading.Tasks;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Core.Services.Auth
{
    public interface IAuthService
    {
        Task<int?> Check(string username, string password);
        Task ChangePassword(int userId, string currentPassword, string newPassword);
    }
}