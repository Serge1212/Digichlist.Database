using Digichlist.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digichlist.Database.Configurations
{
    /// <summary>
    /// The defect's configuration.
    /// </summary>
    public class DefectConfiguration : IEntityTypeConfiguration<Defect>
    {
        public void Configure(EntityTypeBuilder<Defect> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasMany(d => d.DefectImages)
                .WithOne(d => d.Defect)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(d => d.CommandTasks)
                .WithOne(d => d.Defect)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.AssignedWorker)
                .WithMany(u => u.Defects);
        }
    }
}
