using Digichlist.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digichlist.Database.Configurations
{
    public class AssignedDefectConfiguration : IEntityTypeConfiguration<AssignedDefect>
    {
        public void Configure(EntityTypeBuilder<AssignedDefect> builder)
        {
            builder.HasKey(d => d.Id);
        }
    }
}
