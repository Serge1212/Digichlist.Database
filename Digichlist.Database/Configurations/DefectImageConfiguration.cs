using Digichlist.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digichlist.Database.Configurations
{
    /// <summary>
    /// The defect image configuration.
    /// </summary>
    public class DefectImageConfiguration : IEntityTypeConfiguration<DefectImage>
    {
        public void Configure(EntityTypeBuilder<DefectImage> builder)
        {
            builder.HasKey(d => d.Id);

            builder.HasOne(d => d.Defect)
                .WithMany(d => d.DefectImages);
        }
    }
}
