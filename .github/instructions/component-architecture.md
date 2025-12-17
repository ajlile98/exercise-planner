# Component Architecture

## Component Types

### 1. Page Components
- Located in `/Pages` directory
- Marked with `@page` directive
- Handle routing and page-level logic
- Should be thin - delegate business logic to services

### 2. Reusable Components
- Located in `/Components` directory
- Receive data via `[Parameter]`
- Emit events via `EventCallback`
- Self-contained and testable

### 3. Layout Components
- Located in `/Layout` directory
- Define page structure and navigation
- Include shared UI elements

## Parameter Best Practices

```csharp
// Good: Clear, typed parameters
[Parameter]
public string Title { get; set; } = string.Empty;

[Parameter]
public int ItemCount { get; set; }

[Parameter]
public EventCallback<int> OnItemSelected { get; set; }
```

- **Always provide default values** for parameters
- **Use nullable reference types** appropriately
- **Document parameters** with XML comments

## Two-Way Binding

Prefer `@bind-Value` with `ValueChanged` callback:

```razor
<input @bind-Value="searchTerm" @bind-Value:event="oninput" />

@code {
    private string searchTerm = string.Empty;
}
```

For components, use:
```csharp
[Parameter]
public string Value { get; set; } = string.Empty;

[Parameter]
public EventCallback<string> ValueChanged { get; set; }

private async Task OnValueChange(string newValue)
{
    Value = newValue;
    await ValueChanged.InvokeAsync(newValue);
}
```

## State Management

- **Component state**: Use `@code` properties for local state
- **Shared state across components**: Use a service or scoped service
- **Global state**: Consider using Fluxor or CascadingParameters for small projects

## Lifecycle Methods

Use these in order:
1. `OnInitializedAsync()` - Load data once
2. `OnParametersSetAsync()` - React to parameter changes
3. `OnAfterRenderAsync()` - After DOM is rendered (JS interop)

```csharp
protected override async Task OnInitializedAsync()
{
    // Called once when component initializes
    await LoadData();
}

protected override async Task OnParametersSetAsync()
{
    // Called when parameters change
    await ValidateParameters();
}

protected override async Task OnAfterRenderAsync(bool firstRender)
{
    // Called after render, use for JS interop
    if (firstRender)
    {
        await JS.InvokeVoidAsync("initializeChart");
    }
}
```

## Event Handling

- Use `EventCallback<T>` for component events
- Keep event handlers focused and delegate to services
- Name handlers as `On[Event]`: `OnClick`, `OnSubmit`, `OnItemSelected`

```razor
<button @onclick="HandleDelete">Delete</button>

@code {
    [Parameter]
    public EventCallback<int> OnDelete { get; set; }

    private async Task HandleDelete()
    {
        await OnDelete.InvokeAsync(ItemId);
    }
}
```

## Code-Behind Pattern

For complex components, separate markup and logic:

**MyComponent.razor**
```razor
@inherits MyComponentBase

<div>@Title</div>
<button @onclick="HandleClick">Click Me</button>
```

**MyComponent.razor.cs**
```csharp
namespace YourApp.Components;

public partial class MyComponent : ComponentBase
{
    [Parameter]
    public string Title { get; set; } = string.Empty;

    private async Task HandleClick()
    {
        // Logic here
    }
}
```
