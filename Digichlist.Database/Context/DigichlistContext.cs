using Digichlist.Database.Configurations;
using Digichlist.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Digichlist.Database.Context
{
    public class DigichlistContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Defect> Defects { get; set; }
        public DbSet<DefectImage> DefectImages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Get all connection info.
            var server = Environment.GetEnvironmentVariable("DIGICHLIST_SERVER", EnvironmentVariableTarget.User);
            var database = Environment.GetEnvironmentVariable("DIGICHLIST_DATABASE", EnvironmentVariableTarget.User);
            var username = Environment.GetEnvironmentVariable("DIGICHLIST_DB_USERNAME", EnvironmentVariableTarget.User);
            var password = Environment.GetEnvironmentVariable("DIGICHLIST_DB_PASSWORD", EnvironmentVariableTarget.User);
            var template = Environment.GetEnvironmentVariable("DIGICHLIST_DB_CONNECTION_TEMPLATE", EnvironmentVariableTarget.User);

            // Configure connection.
            var conString = string.Format(template!,
                server,
                database,
                username,
                password);

            // Connect.
            optionsBuilder.UseSqlServer(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DefectConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DefectImageConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
