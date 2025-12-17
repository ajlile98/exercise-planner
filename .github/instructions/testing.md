# Testing Standards

## Testing Framework

- **Unit Tests**: xUnit
- **Mocking**: Moq
- **Test Structure**: Arrange-Act-Assert (AAA)

## Unit Testing

### Naming Convention
Test method names follow: `MethodName_Scenario_ExpectedResult`

```csharp
[Fact]
public void CalculateTotal_WithValidPrices_ReturnsCorrectSum()
{
    // Arrange
    var calculator = new PriceCalculator();
    decimal basePrice = 100m;
    decimal taxRate = 0.1m;
    
    // Act
    decimal result = calculator.CalculateTotal(basePrice, taxRate);
    
    // Assert
    Assert.Equal(110m, result);
}
```

### Test Categories

**Happy Path** (positive tests):
```csharp
[Fact]
public void GetUser_WithValidId_ReturnsUser()
{
    // Test successful scenario
}
```

**Error Cases** (negative tests):
```csharp
[Fact]
public void GetUser_WithInvalidId_ThrowsException()
{
    // Test error handling
}
```

**Edge Cases**:
```csharp
[Theory]
[InlineData(0)]
[InlineData(-1)]
[InlineData(null)]
public void GetUser_WithInvalidInput_ThrowsArgumentException(int? id)
{
    // Test boundary conditions
}
```

## Component Testing

For Blazor component testing, use `bUnit`:

```csharp
[Fact]
public void Counter_RendersWithInitialValue()
{
    // Arrange
    using var ctx = new TestContext();
    
    // Act
    var component = ctx.RenderComponent<Counter>();
    
    // Assert
    component.Find("p").TextContent.Should().Contain("Current count: 0");
}

[Fact]
public void Counter_IncrementButtonWorks()
{
    // Arrange
    using var ctx = new TestContext();
    var component = ctx.RenderComponent<Counter>();
    
    // Act
    component.Find("button").Click();
    
    // Assert
    component.Find("p").TextContent.Should().Contain("Current count: 1");
}
```

## Integration Testing

Test service interactions and data flow:

```csharp
[Fact]
public async Task UserService_CreateUser_PersistsToDatabase()
{
    // Arrange
    var dbContext = new TestDbContext();
    var userService = new UserService(dbContext);
    
    // Act
    await userService.CreateUserAsync(new User { Name = "John" });
    
    // Assert
    var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Name == "John");
    user.Should().NotBeNull();
}
```

## Test Organization

```
/Tests
  /Unit
    UserServiceTests.cs
    CalculatorTests.cs
  /Integration
    UserRepositoryTests.cs
    AuthServiceTests.cs
  /Components
    CounterTests.cs
    NavMenuTests.cs
```

## Test Coverage Goals

- **Minimum**: 70% code coverage
- **Target**: 80% code coverage
- **Critical paths**: 100% coverage (authentication, data validation, payments)

Run coverage:
```bash
dotnet test /p:CollectCoverage=true /p:CoverageFormat=opencover
```

## Mocking Best Practices

```csharp
[Fact]
public async Task GetUser_CallsRepositoryOnce()
{
    // Arrange
    var mockRepo = new Mock<IUserRepository>();
    mockRepo
        .Setup(r => r.GetUserAsync(1))
        .ReturnsAsync(new User { Id = 1, Name = "John" });
    
    var service = new UserService(mockRepo.Object);
    
    // Act
    var user = await service.GetUserAsync(1);
    
    // Assert
    mockRepo.Verify(r => r.GetUserAsync(1), Times.Once);
    user.Name.Should().Be("John");
}
```

## Running Tests

```bash
# Run all tests
dotnet test

# Run specific test file
dotnet test --filter "FullyQualifiedName~UserServiceTests"

# Run with verbose output
dotnet test --verbosity detailed

# Run in watch mode
dotnet watch test
```

## CI/CD Integration

Tests run automatically on:
- **Every commit** to feature branches
- **Every PR** against develop/main
- **Before merge** to main

Tests must pass before merging to protected branches.
