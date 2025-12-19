using WorkoutHub.Models;

namespace WorkoutHub.Data;

public static class Seed
{
    public static List<Exercise> GetDefaultExercises()
    {
        return new List<Exercise>
        {
            new Exercise
            {
                Id = "1",
                Name = "Push-ups",
                Description = "Upper body pushing exercise targeting chest, shoulders, and triceps",
                UserId = null
            },
            new Exercise
            {
                Id = "2",
                Name = "Squats",
                Description = "Lower body compound exercise targeting quads, hamstrings, and glutes",
                UserId = null
            },
            new Exercise
            {
                Id = "3",
                Name = "Deadlifts",
                Description = "Full body compound exercise targeting back, glutes, and hamstrings",
                UserId = null
            },
            new Exercise
            {
                Id = "4",
                Name = "Bench Press",
                Description = "Upper body pressing exercise targeting chest, shoulders, and triceps",
                UserId = null
            },
            new Exercise
            {
                Id = "5",
                Name = "Pull-ups",
                Description = "Upper body pulling exercise targeting back and biceps",
                UserId = null
            },
            new Exercise
            {
                Id = "6",
                Name = "Rows",
                Description = "Upper back and bicep exercise",
                UserId = null
            },
            new Exercise
            {
                Id = "7",
                Name = "Plank",
                Description = "Core stability exercise",
                UserId = null
            },
            new Exercise
            {
                Id = "8",
                Name = "Lunges",
                Description = "Lower body exercise targeting quads, glutes, and hamstrings",
                UserId = null
            }
        };
    }
}
