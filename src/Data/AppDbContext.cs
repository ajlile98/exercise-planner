using WorkoutHub.Entities;
using WorkoutHub.Models;
using Microsoft.EntityFrameworkCore;
using Ical.Net.DataTypes;
using Ical.Net;

namespace WorkoutHub.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<Exercise> Exercises {get; set;}
  public DbSet<Workout> Workouts {get;set;}
  public DbSet<WorkoutExercise> WorkoutExercises {get; set;}
  public DbSet<ScheduledWorkout> ScheduledWorkouts {get;set;}
  public DbSet<WorkoutPlan> WorkoutPlans {get; set;}

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    
    // Seed default exercises
    modelBuilder.Entity<Exercise>()
      .HasData(Seed.GetDefaultExercises());
    
    // RecurrencePattern Serialization/Deserialization
    modelBuilder.Entity<ScheduledWorkout>()
      .Property(s => s.RecurrenceRule)
      .HasConversion(
        v => v.ToString(),
        v => v == null ? new RecurrencePattern(frequency: FrequencyType.Weekly) : new RecurrencePattern(v)
      );
  }
}
