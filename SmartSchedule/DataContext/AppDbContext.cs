using Microsoft.EntityFrameworkCore;
using SmartSchedule.Models;

namespace SmartSchedule.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Functionary> Functionaries { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Team> Teams { get; set; }
    }
}
