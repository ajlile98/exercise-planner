using System;
using exercise_planner.Entities;

namespace exercise_planner.Models;

public class Workout
{
    public required string Id { get; set; } = Guid.NewGuid().ToString();
    public List<WorkoutExercise> Exercises { get; set; } = new();
}
