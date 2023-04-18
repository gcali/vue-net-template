using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.Persistence;
using TEMPLATE_PLACEHOLDER_CAPITAL.Core.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Infrastructure
{
    internal class TEMPLATE_PLACEHOLDER_CAPITALContext : DbContext, ITEMPLATE_PLACEHOLDER_CAPITALContext
    {
        public TEMPLATE_PLACEHOLDER_CAPITALContext(DbContextOptions<TEMPLATE_PLACEHOLDER_CAPITALContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(TEMPLATE_PLACEHOLDER_CAPITALContext)));
        }

        public DbSet<User> Users { get; set; }

        async Task ITEMPLATE_PLACEHOLDER_CAPITALContext.Add<T>(T item)
        {
            await this.AddAsync(item);
        }

        Task ITEMPLATE_PLACEHOLDER_CAPITALContext.Remove<T>(T item)
        {
            this.Remove(item);
            return Task.CompletedTask;
        }

        void ITEMPLATE_PLACEHOLDER_CAPITALContext.SaveChangesSync()
        {
            this.SaveChanges();
        }

        Task ITEMPLATE_PLACEHOLDER_CAPITALContext.SaveChanges()
        {
            return this.SaveChangesAsync();
        }

        public Task<IDbContextTransaction> BeginTransaction()
        {
            return this.Database.BeginTransactionAsync();
        }

        public void EnsureDatabase()
        {
            this.Database.EnsureCreated();
        }

        public void RecreateDb()
        {
            this.Database.EnsureDeleted();
            this.Database.EnsureCreated();
        }

        public void Migrate()
        {
            this.Database.Migrate();
        }
    }
}