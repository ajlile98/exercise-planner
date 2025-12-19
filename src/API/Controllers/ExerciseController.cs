
using WorkoutHub.DTOs;
using WorkoutHub.Models;
using Microsoft.AspNetCore.Mvc;
using WorkoutHub.Data;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace WorkoutHub.API.Controllers
{
    public class ExerciseController(AppDbContext context) : BaseApiController
    {
        // Create
        [HttpPost]
        public async Task<ActionResult<Exercise>> CreateExercise(CreateExerciseDTO exerciseDTO)
        {
            var exercise = exerciseDTO.Adapt<Exercise>();
            
            context.Exercises.Add(exercise);
            await context.SaveChangesAsync();
            return exercise;
        }
        // Read
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(string id)
        {
            var exercise = await context.Exercises
                                        .FirstOrDefaultAsync(o => o.Id == id);
            if (exercise == null)
            {
                return NotFound();
            }
            return exercise;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Exercise>>> GetExercises()
        {
            return await context.Exercises.ToListAsync();
        }
        // Update
        [HttpPut("{id}")]
        public async Task<ActionResult<Exercise>> UpdateExercise(UpdateExerciseDTO exerciseDTO)
        {
            var exercise = await context.Exercises.FirstOrDefaultAsync(o => o.Id == exerciseDTO.Id);
            if (exercise == null) return NotFound();
            exercise = exerciseDTO.Adapt(exercise);
            await context.SaveChangesAsync();
            return exercise;
        }
        // Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<Exercise>> DeleteExercise(string id)
        {
            var exercise = await context.Exercises.FirstOrDefaultAsync(o => o.Id == id);
            if (exercise == null) return NotFound();
            context.Exercises.Remove(exercise);
            await context.SaveChangesAsync();
            return exercise;
        }
    }
}
