using Digichlist.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digichlist.Database.Configurations
{
    /// <summary>
    /// The user's configuration.
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasMany(d => d.Defects)
                .WithOne(u => u.AssignedWorker)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
