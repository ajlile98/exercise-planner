using Xunit;

namespace ExercisePlanner.Tests;

public class BasicTests
{
    [Fact]
    public void BasicMath_ShouldWork()
    {
        // Arrange
        var a = 2;
        var b = 3;

        // Act
        var result = a + b;

        // Assert
        Assert.Equal(5, result);
    }

    [Fact]
    public void String_ShouldConcatenate()
    {
        // Arrange
        var greeting = "Hello";
        var name = "World";

        // Act
        var result = $"{greeting} {name}";

        // Assert
        Assert.Equal("Hello World", result);
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 3, 5)]
    [InlineData(5, 5, 10)]
    public void Add_WithVariousInputs_ShouldReturnCorrectSum(int a, int b, int expected)
    {
        // Arrange & Act
        var result = a + b;

        // Assert
        Assert.Equal(expected, result);
    }
}
