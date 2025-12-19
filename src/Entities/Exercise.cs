using System;

namespace exercise_planner.Models;

public class Exercise
{
    public required string Id { get; set; } = Guid.NewGuid().ToString();
    public required string Name { get; set; } = "";
    public string Description { get; set; } = "";
    // public string? VideoLink {get; set;}
}
