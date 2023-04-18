using System.Linq;
using System.Threading.Tasks;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Core.Persistence
{
    public interface ITEMPLATE_PLACEHOLDER_CAPITALContext
    {
        Task Add<T>(T item) where T : IEntity;
        Task Remove<T>(T item) where T : IEntity;
        DbSet<User> Users { get; }
        Task SaveChanges();
        void SaveChangesSync();
        Task<IDbContextTransaction> BeginTransaction();

        void EnsureDatabase();
        void RecreateDb();
        void Migrate();
    }
}