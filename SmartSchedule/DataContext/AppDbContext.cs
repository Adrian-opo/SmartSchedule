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
        public DbSet<Assigned> Assigned { get; set; }

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
            
            modelBuilder.Entity<Assigned>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Assigned>()
                .HasOne(a => a.Member)
                .WithMany(m => m.Assigneds)
                .HasForeignKey(a => a.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Assigned>()
                .HasOne(a => a.Assignment)
                .WithMany(asg => asg.Assigneds)
                .HasForeignKey(a => a.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);
            
            
            modelBuilder.Entity<Assigned>()
                .HasOne(a => a.Scheduled)
                .WithMany(s => s.Assigneds)
                .HasForeignKey(a => a.ScheduledId)
                .OnDelete(DeleteBehavior.Cascade);       
        }
    }
}