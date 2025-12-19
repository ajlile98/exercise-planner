using System;
using WorkoutHub.Entities;

namespace WorkoutHub.Models;

public class Workout
{
    public required string Id { get; set; } = Guid.NewGuid().ToString();
    public List<WorkoutExercise> Exercises { get; set; } = new();
}
