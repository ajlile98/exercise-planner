using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutHub.API.Controllers;
using WorkoutHub.Data;
using WorkoutHub.DTOs;
using WorkoutHub.Models;

namespace ExercisePlanner.Tests;

public class ExerciseControllerTests : IAsyncLifetime
{
    private AppDbContext _context = null!;
    private ExerciseController _controller = null!;

    public async Task InitializeAsync()
    {
        // Create in-memory database
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _context = new AppDbContext(options);
        _controller = new ExerciseController(_context);

        // Create database schema without seeding (seed data would interfere with tests)
        // Using Migrate() instead of EnsureCreatedAsync() so migrations run, but no seed data loads
        await _context.Database.EnsureCreatedAsync();
        
        // Remove all seeded data for a clean test slate
        _context.Exercises.RemoveRange(_context.Exercises);
        await _context.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await _context.Database.EnsureDeletedAsync();
        await _context.DisposeAsync();
    }

    #region CreateExercise Tests

    [Fact]
    public async Task CreateExercise_WithValidDTO_ReturnsCreatedExercise()
    {
        // Arrange
        var createDto = new CreateExerciseDTO
        {
            Name = "Push-ups",
            Description = "Upper body exercise",
            UserId = "user123"
        };

        // Act
        var result = await _controller.CreateExercise(createDto);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Exercise>>(result);
        var exercise = Assert.IsType<Exercise>(actionResult.Value);
        Assert.Equal("Push-ups", exercise.Name);
        Assert.Equal("Upper body exercise", exercise.Description);
        Assert.Equal("user123", exercise.UserId);

        // Verify it's in the database
        var savedExercise = await _context.Exercises.FindAsync(exercise.Id);
        Assert.NotNull(savedExercise);
    }

    #endregion

    #region GetExercise Tests

    [Fact]
    public async Task GetExercise_WithValidId_ReturnsExercise()
    {
        // Arrange
        var exercise = new Exercise
        {
            Id = "1",
            Name = "Squats",
            Description = "Lower body exercise",
            UserId = null
        };
        await _context.Exercises.AddAsync(exercise);
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.GetExercise("1");

        // Assert
        var actionResult = Assert.IsType<ActionResult<Exercise>>(result);
        var returnedExercise = Assert.IsType<Exercise>(actionResult.Value);
        Assert.Equal("1", returnedExercise.Id);
        Assert.Equal("Squats", returnedExercise.Name);
    }

    [Fact]
    public async Task GetExercise_WithInvalidId_ReturnsNotFound()
    {
        // Act
        var result = await _controller.GetExercise("999");

        // Assert
        var actionResult = Assert.IsType<ActionResult<Exercise>>(result);
        Assert.IsType<NotFoundResult>(actionResult.Result);
    }

    #endregion

    #region GetExercises Tests

    [Fact]
    public async Task GetExercises_ReturnsAllExercises()
    {
        // Arrange
        var exercises = new List<Exercise>
        {
            new Exercise { Id = "1", Name = "Push-ups", Description = "Chest exercise", UserId = null },
            new Exercise { Id = "2", Name = "Squats", Description = "Leg exercise", UserId = null },
            new Exercise { Id = "3", Name = "Deadlifts", Description = "Back exercise", UserId = null }
        };
        await _context.Exercises.AddRangeAsync(exercises);
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.GetExercises();

        // Assert
        var actionResult = Assert.IsType<ActionResult<IReadOnlyList<Exercise>>>(result);
        var exerciseList = Assert.IsType<List<Exercise>>(actionResult.Value);
        Assert.Equal(3, exerciseList.Count);
    }

    [Fact]
    public async Task GetExercises_WithEmptyDatabase_ReturnsEmptyList()
    {
        // Act
        var result = await _controller.GetExercises();

        // Assert
        var actionResult = Assert.IsType<ActionResult<IReadOnlyList<Exercise>>>(result);
        var exerciseList = Assert.IsType<List<Exercise>>(actionResult.Value);
        Assert.Empty(exerciseList);
    }

    #endregion

    #region UpdateExercise Tests

    [Fact]
    public async Task UpdateExercise_WithValidData_UpdatesExercise()
    {
        // Arrange
        var exercise = new Exercise
        {
            Id = "1",
            Name = "Push-ups",
            Description = "Original description",
            UserId = "user123"
        };
        await _context.Exercises.AddAsync(exercise);
        await _context.SaveChangesAsync();

        var updateDto = new UpdateExerciseDTO
        {
            Id = "1",
            Name = "Modified Push-ups",
            Description = "Updated description"
        };

        // Act
        var result = await _controller.UpdateExercise(updateDto);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Exercise>>(result);
        var updatedExercise = Assert.IsType<Exercise>(actionResult.Value);
        Assert.Equal("Modified Push-ups", updatedExercise.Name);
        Assert.Equal("Updated description", updatedExercise.Description);

        // Verify in database
        var dbExercise = await _context.Exercises.FindAsync("1");
        Assert.NotNull(dbExercise);
        Assert.Equal("Modified Push-ups", dbExercise.Name);
    }

    [Fact]
    public async Task UpdateExercise_WithNonExistentId_ReturnsNotFound()
    {
        // Arrange
        var updateDto = new UpdateExerciseDTO
        {
            Id = "999",
            Name = "Non-existent",
            Description = "Does not exist"
        };

        // Act
        var result = await _controller.UpdateExercise(updateDto);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Exercise>>(result);
        Assert.IsType<NotFoundResult>(actionResult.Result);
    }

    #endregion

    #region DeleteExercise Tests

    [Fact]
    public async Task DeleteExercise_WithValidId_DeletesExercise()
    {
        // Arrange
        var exercise = new Exercise
        {
            Id = "1",
            Name = "Push-ups",
            Description = "To be deleted",
            UserId = null
        };
        await _context.Exercises.AddAsync(exercise);
        await _context.SaveChangesAsync();

        // Act
        var result = await _controller.DeleteExercise("1");

        // Assert
        var actionResult = Assert.IsType<ActionResult<Exercise>>(result);
        var deletedExercise = Assert.IsType<Exercise>(actionResult.Value);
        Assert.Equal("1", deletedExercise.Id);
        Assert.Equal("Push-ups", deletedExercise.Name);

        // Verify it's deleted from database
        var exerciseInDb = await _context.Exercises.FindAsync("1");
        Assert.Null(exerciseInDb);
    }

    [Fact]
    public async Task DeleteExercise_WithNonExistentId_ReturnsNotFound()
    {
        // Act
        var result = await _controller.DeleteExercise("999");

        // Assert
        var actionResult = Assert.IsType<ActionResult<Exercise>>(result);
        Assert.IsType<NotFoundResult>(actionResult.Result);
    }

    #endregion
}
