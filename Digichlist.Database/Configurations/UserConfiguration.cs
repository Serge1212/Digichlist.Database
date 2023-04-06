using Digichlist.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digichlist.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasMany(d => d.Defects)
                .WithOne(u => u.Publisher)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
