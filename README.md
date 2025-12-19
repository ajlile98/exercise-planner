# Workout Hub

A full-stack exercise tracking application built with Blazor Web App (.NET 10), Tailwind CSS, and daisyUI. Features automated testing, semantic versioning, and CI/CD automation.

## Table of Contents

- [Quick Start](#quick-start)
- [Project Structure](#project-structure)
- [Tech Stack](#tech-stack)
- [Development](#development)
- [Testing](#testing)
- [Git Workflow](#git-workflow)
- [Deployment](#deployment)
- [Contributing](#contributing)

## Quick Start

### Prerequisites

- .NET 10 SDK
- Node.js 20+
- Git

### Installation

```bash
# Clone the repository
git clone https://github.com/ajlile98/workout-hub.git
cd workout-hub

# Install dependencies
npm install
cd src && npm install && cd ..
dotnet restore
```

### Running the Application

```bash
# Development with hot reload
dotnet watch --project src

# App runs at http://localhost:5000
```

## Project Structure

```
exercise-planner/
├── src/
│   ├── Components/              # Blazor components (UI)
│   ├── Properties/              # Project properties
│   ├── wwwroot/                 # Static assets
│   │   ├── css/                 # Compiled Tailwind CSS
│   │   ├── index.html           # Main entry point
│   │   └── app.css              # Generated styles
│   ├── Program.cs               # Application startup
│   ├── appsettings.json         # Configuration
│   ├── exercise-planner.csproj  # Project file
│   └── package.json             # CSS build tools
│
├── tests/
│   └── exercise-planner.Tests/
│       ├── BasicTests.cs        # Unit tests
│       └── exercise-planner.Tests.csproj
│
├── .github/
│   ├── workflows/
│   │   ├── release.yml          # CI/CD pipeline (push to main/develop)
│   │   └── nightly-release.yml  # Nightly prerelease (develop branch)
│   └── instructions/            # Best practices guides
│
├── exercise-planner.sln         # Solution file
├── .releaserc.json              # Semantic release config
├── commitlint.config.js         # Commit validation
├── tailwind.config.js           # Tailwind configuration
├── postcss.config.js            # PostCSS configuration
├── package.json                 # Release & commit tools
└── README.md
```

## Tech Stack

### Frontend & UI
- **Framework**: Blazor Web App (.NET 10)
  - Server-side rendering with interactive components
  - WebAssembly interop where needed
- **Styling**: Tailwind CSS v4.1.18 + daisyUI 5.5.14
- **Build**: PostCSS with Tailwind CLI

### Backend
- **Runtime**: ASP.NET Core (.NET 10)
- **Language**: C#

### Testing
- **Framework**: xUnit 2.7.0
- **SDK**: Microsoft.NET.Test.Sdk 17.10.0

### DevOps & Tooling
- **Version Control**: Git Flow (main/develop)
- **Commits**: Conventional Commits with Commitizen
- **Validation**: Commitlint
- **Hooks**: Husky
- **Versioning**: Semantic Release v24.2.9
- **CI/CD**: GitHub Actions

### PWA
- Service Workers for offline support
- Manifest file for installability

## Development

### Available Commands

```bash
# Start development server with hot reload
dotnet watch --project src

# Build CSS in watch mode
cd src && npm run dev && cd ..

# Build CSS once
cd src && npm run build && cd ..

# Build project (Release)
dotnet build -c Release

# Create a new conventional commit
npm run commit

# Manually trigger semantic release (dry-run locally)
npm run release
```

### Making Changes

1. Create a feature branch from `develop`:
   ```bash
   git checkout develop
   git pull origin develop
   git checkout -b feature/your-feature-name
   ```

2. Make your changes and commit with:
   ```bash
   npm run commit
   ```

3. Push and create a pull request:
   ```bash
   git push origin feature/your-feature-name
   ```

## Testing

### Running Tests

```bash
# Run all tests
dotnet test

# Run tests in Release mode
dotnet test --configuration Release

# Run specific test
dotnet test --filter "BasicMath"
```

### Writing Tests

Tests are located in `tests/exercise-planner.Tests/BasicTests.cs`. Use xUnit syntax:

```csharp
[Fact]
public void SampleTest()
{
    Assert.Equal(expected, actual);
}
```

## Git Workflow

### Branches

- **main**: Production-ready releases
  - ✅ Full semantic versioning (1.0.0, 1.0.1, 1.1.0, 2.0.0)
  - Triggered by push to main
  - Auto-tagged and released

- **develop**: Development and testing
  - 🔄 Prerelease versions (1.0.0-develop.1, 1.0.0-develop.2)
  - Nightly releases (scheduled daily at 2 AM UTC)
  - Base branch for feature development

### Commit Format

Uses Conventional Commits:
- `feat:` - New feature (triggers minor version bump)
- `fix:` - Bug fix (triggers patch version bump)
- `chore:` - Maintenance (no version bump)
- `docs:` - Documentation (no version bump)
- `test:` - Tests (no version bump)
- Breaking changes: Add `BREAKING CHANGE:` footer for major bump

Example:
```
feat(components): add exercise form component

- Added new form for exercise input
- Integrated validation
- Updated styling

Closes #42
```

### Commit Workflow

```bash
# Stage your changes
git add .

# Use interactive commit helper
npm run commit

# Push to your branch
git push origin feature/your-feature
```

The commit hook will validate your message automatically.

## Deployment

### Automatic Releases

Releases are fully automated via GitHub Actions:

1. **On Push to main**: Full release (v1.0.0, v1.1.0, etc.)
2. **On Push to develop**: Prerelease (v1.0.0-develop.1)
3. **Nightly (2 AM UTC)**: Prerelease on develop if changes exist

### Release Process

1. Changes merged to main/develop
2. GitHub Actions triggers build job
3. Tests run and must pass
4. Semantic Release analyzes commits
5. Version bumped automatically
6. Tag and release created
7. CHANGELOG.md updated

### Manual Release (Local)

For testing purposes:

```bash
# Dry-run (shows what would happen)
npm run release

# To actually release, push to main/develop and let GitHub Actions handle it
```

## Contributing

### Code Style

See `.github/instructions/code-style.md` for detailed guidelines.

### Best Practices

- Follow the guides in `.github/instructions/`
- Write tests for new features
- Use meaningful commit messages
- Keep components small and focused
- Document complex logic

## Project Guidelines

Detailed best practices for various aspects:

- 📋 [Code Style](/.github/instructions/code-style.md)
- 🏗️ [Component Architecture](/.github/instructions/component-architecture.md)
- 🎨 [Styling Guide](/.github/instructions/styling.md)
- 🌿 [Git Workflow](/.github/instructions/git-workflow.md)
- ✅ [Testing Guidelines](/.github/instructions/testing.md)
- 📚 [Documentation](/.github/instructions/documentation.md)
- 🤖 [AI Assistance](/.github/instructions/ai-assistance.md)

## License

MIT
