using Digichlist.Database.Configurations;
using Digichlist.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Digichlist.Database.Context
{
    public class DigichlistContext : DbContext
    {
        /// <summary>
        /// The db set that reflects the state of Users table.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// The db set that reflects the state of Roles table.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// The db set that reflects the state of Defects table.
        /// </summary>
        public DbSet<Defect> Defects { get; set; }

        /// <summary>
        /// The db set that reflects the state of DefectImages table.
        /// </summary>
        public DbSet<DefectImage> DefectImages { get; set; }

        /// <summary>
        /// The db set that reflects the state of CommandTask table.
        /// </summary>
        public DbSet<CommandTask> CommandTasks { get; set; }

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
