using Digichlist.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Digichlist.Database.Configurations
{
    /// <summary>
    /// The CommandTask configuration.
    /// </summary>
    public class CommandTaskConfiguration : IEntityTypeConfiguration<CommandTask>
    {
        public void Configure(EntityTypeBuilder<CommandTask> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Defect)
                .WithMany(d => d.CommandTasksInfo)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
