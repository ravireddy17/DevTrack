using Microsoft.EntityFrameworkCore;
using DevTrack.Models;

namespace DevTrack.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed some sample data
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem
                {
                    Id = 1,
                    Title = "Review application performance system",
                    Description = "Analyze current task tracking application for bugs",
                    Priority = "High",
                    Status = "In Progress",
                    AssignedTo = "Dev Team",
                    CreatedAt = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(3)
                },
                new TaskItem
                {
                    Id = 2,
                    Title = "Update user rewards API",
                    Description = "Add new endpoints for rewards program",
                    Priority = "Medium",
                    Status = "Pending",
                    AssignedTo = "Dev Team",
                    CreatedAt = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7)
                },
                new TaskItem
                {
                    Id = 3,
                    Title = "Fix payment integration bug",
                    Description = "Resolve transaction sync issue",
                    Priority = "High",
                    Status = "Pending",
                    AssignedTo = "Team",
                    CreatedAt = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(1)
                }
            );
        }
    }
}
