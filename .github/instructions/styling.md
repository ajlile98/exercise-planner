# Styling Guidelines

## Framework Choice: Tailwind CSS + daisyUI

This project uses **Tailwind CSS** with **daisyUI** for component styling.

- **Tailwind**: Utility-first CSS framework
- **daisyUI**: Pre-built component library on top of Tailwind
- **Why**: Language-agnostic, smaller bundle sizes, highly customizable

## CSS Class Organization

### 1. Utility Classes (Primary)
Use Tailwind utility classes directly in markup:

```razor
<div class="flex gap-4 p-4 rounded-lg bg-base-100 shadow-md">
    <h2 class="text-lg font-bold">Title</h2>
    <p class="text-sm text-base-content/70">Description</p>
</div>
```

### 2. Scoped Component Styles (Secondary)
For component-specific styles that can't be expressed with utilities:

```razor
@* MyComponent.razor *@
<div class="my-component">
    <button>Click me</button>
</div>

<style>
.my-component button {
    transition: transform 0.2s ease-in-out;
}

.my-component button:hover {
    transform: scale(1.05);
}
</style>
```

### 3. Global Styles (Minimal)
Only for truly global styles in `wwwroot/css/app.css`:

```css
/* Global app styles */
body {
    @apply bg-base-100 text-base-content;
}

/* Custom utility for app-specific needs */
@layer components {
    .btn-ghost-sm {
        @apply btn btn-ghost btn-sm;
    }
}
```

## daisyUI Component Usage

Use daisyUI's predefined components:

```razor
<!-- Card component -->
<div class="card bg-base-100 shadow-xl">
    <div class="card-body">
        <h2 class="card-title">Card Title</h2>
        <p>Card content</p>
    </div>
</div>

<!-- Button variations -->
<button class="btn btn-primary">Primary</button>
<button class="btn btn-secondary">Secondary</button>
<button class="btn btn-outline">Outline</button>

<!-- Input -->
<input type="text" placeholder="Enter text" class="input input-bordered w-full" />

<!-- Alert -->
<div class="alert alert-info">
    <span>Information message</span>
</div>
```

## Responsive Design

Use Tailwind breakpoints:

```razor
<div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
    <!-- Stacks on mobile, 2 cols on tablet, 3 cols on desktop -->
</div>
```

Breakpoints:
- `sm`: 640px
- `md`: 768px
- `lg`: 1024px
- `xl`: 1280px
- `2xl`: 1536px

## Color Palette (daisyUI)

daisyUI defines semantic color names:

- `base-100` - Background
- `base-200` - Secondary background
- `base-300` - Border/divider
- `base-content` - Text color
- `primary` - Primary action
- `secondary` - Secondary action
- `accent` - Accent color
- `info`, `success`, `warning`, `error` - Semantic colors

## Avoiding Style Duplication

**Don't**: Create CSS classes that duplicate utilities
```css
/* Bad */
.card-item {
    display: flex;
    gap: 1rem;
    padding: 1rem;
}
```

**Do**: Use `@apply` to compose utilities or stick with inline classes
```razor
<!-- Good -->
<div class="flex gap-4 p-4">
</div>
```

## Theme Customization

To customize daisyUI themes, edit `tailwind.config.js`:

```javascript
daisyui: {
    themes: ["light", "dark"],
}
```

Or add custom theme data attributes to components.

## Dark Mode

daisyUI handles dark mode automatically. Ensure `tailwind.config.js` includes dark theme in the themes array.

Components will respect system preference or theme switcher.
