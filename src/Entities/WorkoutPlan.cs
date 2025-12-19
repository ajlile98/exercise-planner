using System;

namespace WorkoutHub.Models;

public class WorkoutPlan
{
    public required string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; }
    public required string UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public List<ScheduledWorkout> ScheduledWorkoutList { get; set; } = new();
}
