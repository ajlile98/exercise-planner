using System;

namespace WorkoutHub.DTOs;

public class CreateExerciseDTO
{
    public required string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string? UserId {get; set;}
 
}

public class UpdateExerciseDTO
{
    public required string Id {get; set;}
    public string? Name { get; set; }
    public string? Description { get; set; }
}
