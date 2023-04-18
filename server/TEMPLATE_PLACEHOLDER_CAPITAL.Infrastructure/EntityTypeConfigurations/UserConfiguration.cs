using TEMPLATE_PLACEHOLDER_CAPITAL.Core.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TEMPLATE_PLACEHOLDER_CAPITAL.Infrastructure.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Username).IsRequired();
            builder.Property(u => u.HashedPassword).IsRequired();
            builder.Property(u => u.Salt).IsRequired();
        }
    }
}