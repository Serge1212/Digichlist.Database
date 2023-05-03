using Digichlist.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digichlist.Database.Configurations
{
    /// <summary>
    /// The defect's configuration.
    /// </summary>
    public class CommandTaskInfoConfiguration : IEntityTypeConfiguration<CommandTaskInfo>
    {
        public void Configure(EntityTypeBuilder<CommandTaskInfo> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Defect)
                .WithMany(d => d.CommandTasksInfo)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
