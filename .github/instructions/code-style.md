# Code Style & Conventions

## C# Naming Conventions

- **Classes & Methods**: `PascalCase` - `CalculateTotal()`, `UserService`
- **Properties**: `PascalCase` - `FirstName`, `IsActive`
- **Private fields**: `_camelCase` - `_userName`, `_configuration`
- **Local variables**: `camelCase` - `itemCount`, `isValid`
- **Constants**: `UPPER_SNAKE_CASE` - `MAX_RETRY_COUNT`, `DEFAULT_TIMEOUT`
- **Interfaces**: `IPascalCase` - `IUserService`, `IRepository`

## File Organization

- **One component per file**: Each `.razor` component in its own file
- **Code-behind pattern**: Use `ComponentName.razor.cs` for logic-heavy components
- **Folder structure**:
  - `/Pages` - Routable components
  - `/Components` - Reusable components
  - `/Services` - Business logic and API calls
  - `/Models` - Data transfer objects and domain models
  - `/Layout` - Layout components

## Component Structure

Razor components should follow this order:

```razor
@page "/route"
@using YourNamespace
@inject IService Service

<MarkupHere />

@code {
    // Properties and fields
    private string? propertyName;
    
    // Lifecycle methods (OnInitialized, OnParametersSet, etc.)
    protected override async Task OnInitializedAsync()
    {
        // initialization
    }
    
    // Event handlers
    private void HandleClick()
    {
    }
    
    // Helper methods
    private void HelperMethod()
    {
    }
}
```

## Documentation & Comments

- **Use XML documentation** for public methods and properties:
  ```csharp
  /// <summary>
  /// Calculates the total price with tax.
  /// </summary>
  /// <param name="basePrice">The base price before tax</param>
  /// <returns>The total price including tax</returns>
  public decimal CalculateTotal(decimal basePrice)
  ```

- **Avoid obvious comments**: Don't comment what the code clearly states
- **Comment the why, not the what**: Explain business logic or non-obvious decisions
- **Keep comments up-to-date**: Outdated comments are worse than no comments

## Async/Await Patterns

- **Always use async/await** for I/O operations (HTTP, database, file access)
- **Avoid `.Result` or `.Wait()`**: Can cause deadlocks in some contexts
- **Name async methods with `Async` suffix**: `GetUserAsync()`, `SaveDataAsync()`
- **Prefer `Task` over `void`** for async methods (except event handlers where void is acceptable)

## Dependency Injection

- **Inject at component level** using `@inject`:
  ```razor
  @inject IUserService UserService
  ```

- **Constructor injection for code-behind files**:
  ```csharp
  [Inject]
  public IUserService UserService { get; set; }
  ```

## Null Safety

- **Enable nullable reference types** in `.csproj`: Already enabled in this project
- **Use null-conditional operators**: `user?.Name` instead of null checks
- **Validate null in parameters**: Throw `ArgumentNullException` for public APIs
  ```csharp
  public void ProcessUser(User user)
  {
      ArgumentNullException.ThrowIfNull(user);
  }
  ```
