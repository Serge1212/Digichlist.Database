using Digichlist.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digichlist.Database.Configurations
{
    /// <summary>
    /// The role's configuration.
    /// </summary>
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasIndex(r => r.Name)
                .IsUnique();
        }
    }
}
