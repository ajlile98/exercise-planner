using WorkoutHub.Entities;
using WorkoutHub.Models;
using Microsoft.EntityFrameworkCore;

namespace WorkoutHub.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<Exercise> Exercises {get; set;}
  public DbSet<Workout> Workouts {get;set;}
  public DbSet<WorkoutExercise> WorkoutExercises {get; set;}
  public DbSet<ScheduledWorkout> ScheduledWorkouts {get;set;}
  public DbSet<WorkoutPlan> WorkoutPlans {get; set;}
}
