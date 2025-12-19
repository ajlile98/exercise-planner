
using exercise_planner.DTOs;
using exercise_planner.Models;
using Microsoft.AspNetCore.Mvc;

namespace exercise_planner.API.Controllers
{
    public class ExerciseController : BaseApiController
    {
        // Create
        [HttpPost]
        public async Task<ActionResult<Exercise>> CreateExercise(ExerciseDTO exerciseDTO)
        {
            return new Exercise
            {
                Id = "test",
                Name = "Test",
                Description = "",
            };
        }
        // Read
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            return new Exercise
            {
                Id = $"{id}",
                Name = "Test",
                Description = "",
            };
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Exercise>>> GetExercises()
        {
            List<Exercise> list = new();
            list.Add(new Exercise 
            {
                Id = "test",
                Name = "Test",
                Description = "",
            });
            return list.AsReadOnly();
        }
        // Update
        // Delete
    }
}
