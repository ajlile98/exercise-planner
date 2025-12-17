# AI Assistance Guidelines

## When to Ask for Help

### ✅ Good Requests
- **Refactoring code**: "Can you refactor this component to be more testable?"
- **Code review**: "Does this follow our conventions? Any improvements?"
- **Implementation help**: "I need to add a feature to handle user authentication"
- **Explaining concepts**: "How do you structure a service in Blazor?"
- **Debugging**: "This code throws an exception when X happens, what could be wrong?"
- **Documentation**: "Help me write documentation for this service"
- **Architecture questions**: "Should this be a component or a service?"

### ❌ Avoid
- **Jump to implementation**: "Fix everything" - Too vague
- **Rush decisions**: Asking for complete features without discussion
- **Replacing thinking**: Use AI to augment, not replace your judgment
- **Automatic application**: Always review suggestions before applying

## How to Write Effective Requests

### 1. **Be Specific**
❌ "Can you help me with this component?"
✅ "I have a form component that validates emails. Should this validation be in the component or extracted to a service?"

### 2. **Provide Context**
Include relevant code snippets and explain what you've tried:
```
I'm trying to implement two-way binding for a custom select component.
Here's what I have so far:

@code {
    [Parameter]
    public string Value { get; set; }
    
    private void OnChange(string value) { }
}

The issue is that changes aren't propagating back to the parent.
```

### 3. **State Your Goals**
"I want to make this component more reusable" or "I need to improve performance"

### 4. **Mention Constraints**
- Target audience (.NET version, browser support)
- Project constraints (bundle size, dependencies)
- Timeline (quick spike vs. production-ready)

## Review & Critique

Never blindly accept AI suggestions:

### Before Applying Changes
- [ ] Do I understand why this change is being suggested?
- [ ] Does it follow our project conventions?
- [ ] Will this work with our current dependencies?
- [ ] Have I tested this locally?
- [ ] Does this align with our architecture?

### During Code Review
- [ ] Is the implementation clear and maintainable?
- [ ] Are edge cases handled?
- [ ] Does it have appropriate error handling?
- [ ] Is it properly documented?

## Communication Style Preferences

### Tone
- Be direct and practical
- Focus on actionable suggestions
- Explain the "why" behind recommendations

### Pace
- Don't rush to implement everything
- Ask clarifying questions when scope is unclear
- Break large tasks into smaller steps

### Detail Level
- For complex topics: detailed explanation with examples
- For simple tasks: concise and direct
- Always show code examples when relevant

## Red Flags

Watch for AI hallucinations:
- API methods that don't exist
- Incorrect property names
- Outdated patterns or syntax
- Missing error handling

**When in doubt, verify** with official documentation or test locally.

## Collaboration Pattern

### Step 1: Discussion
"I'm thinking about implementing this feature..."

### Step 2: Small Steps
"Let's start with just the service logic"

### Step 3: Review & Iterate
"This looks good, but can we handle this edge case differently?"

### Step 4: Documentation
"Help me document this for future maintainers"

## Rules of Thumb

1. **Ask for guidance first** when making architectural decisions
2. **Request refactoring help** to improve code quality
3. **Verify suggestions** before applying to production code
4. **Document decisions** in ADRs when AI helps with major changes
5. **Build understanding** - don't just accept solutions blindly
6. **Test thoroughly** - AI code needs the same scrutiny as human code
