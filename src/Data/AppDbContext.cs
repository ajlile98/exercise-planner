using exercise_planner.Entities;
using exercise_planner.Models;
using Microsoft.EntityFrameworkCore;

namespace exercise_planner.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
  public DbSet<Exercise> Exercises {get; set;}
  public DbSet<Workout> Workouts {get;set;}
  public DbSet<WorkoutExercise> WorkoutExercises {get; set;}
  public DbSet<ScheduledWorkout> ScheduledWorkouts {get;set;}
  public DbSet<WorkoutPlan> WorkoutPlans {get; set;}
}
