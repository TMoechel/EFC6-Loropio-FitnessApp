using EFC6.Ch2.FitnessApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace EfC6.Ch2.FitnessApp.Data
{
    public class FitnessAppContext : DbContext
    {
        public DbSet<RunActivity> RunActivities { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server = localhost\\SQLEXPRESS; Database=FitnessDb; Trusted_Connection = True;"
                );
        }
    }
}