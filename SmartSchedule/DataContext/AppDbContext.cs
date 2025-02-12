using Microsoft.EntityFrameworkCore;
using SmartSchedule.Models;

namespace SmartSchedule.DataContext
{
    public class SmartScheduleContext : DbContext
    {
        public SmartScheduleContext(DbContextOptions<SmartScheduleContext> options) 
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Scheduled> Scheduleds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>()
                .HasKey(m => m.Id);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.User)
                .WithMany(u => u.Members)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.Team)
                .WithMany(t => t.Members)
                .HasForeignKey(m => m.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.Role)
                .WithMany(r => r.Members)
                .HasForeignKey(m => m.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}