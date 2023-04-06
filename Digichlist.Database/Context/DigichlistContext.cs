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
        public DbSet<AssignedDefect> AssignedDefects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var server = Environment.GetEnvironmentVariable("DIGICHLIST_SERVER", EnvironmentVariableTarget.User);
            var database = Environment.GetEnvironmentVariable("DIGICHLIST_DATABASE", EnvironmentVariableTarget.User);
            var username = Environment.GetEnvironmentVariable("DIGICHLIST_DB_USERNAME", EnvironmentVariableTarget.User);
            var password = Environment.GetEnvironmentVariable("DIGICHLIST_DB_PASSWORD", EnvironmentVariableTarget.User);

            var conString = $"Server={server};Database={database};User Id={username};Password={password};pooling=true;Max Pool Size=100;";
            optionsBuilder.UseSqlServer(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DefectConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DefectImageConfiguration());
            modelBuilder.ApplyConfiguration(new AssignedDefectConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
