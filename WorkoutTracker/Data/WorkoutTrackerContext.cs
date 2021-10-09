using Microsoft.EntityFrameworkCore;
using WorkoutTracker.Data.Models;

namespace WorkoutTracker.Data
{
  public class WorkoutTrackerContext : DbContext
  {
    public WorkoutTrackerContext(DbContextOptions<WorkoutTrackerContext> options) : base(options)
    {
    }

    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WorkoutProgress> WorkoutProgresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Exercise>().ToTable("Exercise");
      modelBuilder.Entity<User>().ToTable("User");
      modelBuilder.Entity<WorkoutProgress>().ToTable("WorkoutProgress");
    }
  }
}
