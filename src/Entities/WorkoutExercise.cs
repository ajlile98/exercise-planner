using System;
using System.Text.Json.Serialization;
using WorkoutHub.Models;

namespace WorkoutHub.Entities;

public class WorkoutExercise
{
  public required string Id {get; set;} = Guid.NewGuid().ToString();
  public required string WorkoutId {get; set;}
  [JsonIgnore]
  public Workout Workout {get; set;} = null!;
  public required string ExerciseId {get; set;}
  public Exercise Exercise {get; set;} = null!;
  public required int Sets {get; set;}
  public required int Reps {get; set;}
  public decimal? Weight {get; set;}
}
