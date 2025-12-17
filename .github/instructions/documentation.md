# Documentation Requirements

## XML Documentation (Code)

All public APIs must have XML documentation:

```csharp
/// <summary>
/// Calculates the total price including tax.
/// </summary>
/// <param name="basePrice">The base price before tax is applied</param>
/// <param name="taxRate">The tax rate as a decimal (e.g., 0.1 for 10%)</param>
/// <returns>The total price after tax is applied</returns>
/// <exception cref="ArgumentException">Thrown when prices are negative</exception>
public decimal CalculateTotal(decimal basePrice, decimal taxRate)
{
    ArgumentException.ThrowIfNegative(basePrice);
    return basePrice * (1 + taxRate);
}
```

### Tags to Use
- `<summary>` - Brief description (1-2 sentences)
- `<param>` - Parameter documentation
- `<returns>` - Return value documentation
- `<exception>` - Exceptions that can be thrown
- `<example>` - Usage examples
- `<remarks>` - Additional details
- `<c>` - Inline code reference
- `<see>` - Reference to another type

## README Standards

Every module/feature should have a README explaining:

1. **Overview** - What does this do?
2. **Features** - Key capabilities
3. **Installation/Setup** - How to use it
4. **Examples** - Code samples
5. **API Reference** - Public methods/properties
6. **Testing** - How to run tests

## In-Code Comments

### When to Comment
✅ **Why** - Explain non-obvious business logic
```csharp
// Calculate tax based on location to comply with state regulations
decimal stateTax = GetStateTax(user.Location);
```

✅ **Edge cases** - Document special handling
```csharp
// If user hasn't updated profile in 6+ months, reset preferences
if ((DateTime.UtcNow - user.LastUpdated).TotalDays > 180)
{
    user.ResetPreferences();
}
```

✅ **Workarounds** - Explain temporary solutions
```csharp
// TODO: Replace with native API when .NET 9 support is added
var result = ThirdPartyLib.Convert(data);
```

### When NOT to Comment
❌ **Obvious code**
```csharp
// Bad - the code is self-explanatory
int count = 0; // Initialize count to zero
count++; // Increment count
```

❌ **Repeating code**
```csharp
// Bad - just restates the code
decimal total = price * (1 + taxRate); // Multiply price by 1 plus tax rate
```

## TODO & FIXME Comments

Use consistently:

```csharp
// TODO: Add caching for performance improvement
// FIXME: This will fail if user is null
// NOTE: This behavior changed in v2.0, see issue #123
// HACK: Temporary solution until backend API is ready
```

## Commit Message Documentation

Write clear, descriptive commit messages (see git-workflow.md):

```
feat(pricing): add tax calculation service

- Implement ITaxCalculator interface
- Add support for multiple tax regions
- Validate negative prices

Closes #789
```

## PR Description Template

```markdown
## What does this PR do?
Clear explanation of changes

## Why are these changes needed?
Context and business justification

## How were these tested?
Testing approach and results

## Related issues
Closes #123

## Checklist
- [ ] Code reviewed
- [ ] Tests added/updated
- [ ] Documentation updated
- [ ] No breaking changes (or documented)
```

## Architecture Decision Records (ADR)

For significant architectural decisions, create an ADR:

**Location**: `.github/decisions/adr-NNNN-title.md`

**Template**:
```markdown
# ADR-001: Use Tailwind CSS + daisyUI

## Context
Why did we need to make this decision?

## Decision
What did we decide?

## Consequences
What are the positive and negative effects?

## Alternatives Considered
Other options we evaluated
```

## API Documentation

For public APIs, document endpoints:

```markdown
### GET /api/users/:id

Get a user by ID

**Parameters**:
- `id` (integer, required) - User ID

**Response** (200 OK):
```json
{
  "id": 1,
  "name": "John Doe",
  "email": "john@example.com"
}
```

**Errors**:
- `404 Not Found` - User does not exist
- `401 Unauthorized` - Not authenticated
```

## Documentation Tools

- **Code documentation**: XML comments + IntelliSense
- **Architecture**: ADRs in `.github/decisions/`
- **Features**: README in feature folder
- **API**: OpenAPI/Swagger specifications
- **Deployment**: Instructions in `.github/instructions/`
