# Exercise Planner

A full-stack exercise tracking application with separated frontend and backend architectures.

## Project Structure

```
exercise-planner/
├── src/                     # ASP.NET Core Blazor Web App
│   ├── Program.cs
│   ├── exercise-planner.csproj
│   ├── appsettings.json
│   ├── Components/          # Blazor components
│   ├── Properties/
│   ├── wwwroot/             # Static assets, styles
│   └── exercise-planner.Tests/  # Unit tests
├── .github/
│   ├── workflows/           # CI/CD automation
│   └── instructions/        # Project guidelines
└── README.md
```

## Getting Started

### Application

```bash
cd src
dotnet watch
```

The app will open at `http://localhost:5000`

### Development Commands

```bash
cd src

# Run with hot reload
dotnet watch

# Run tests
dotnet test

# Build for production
dotnet build -c Release
```

## Technology Stack

### Frontend
- **Framework**: Blazor WebAssembly (.NET 10)
- **Styling**: Tailwind CSS v4 + daisyUI
- **Build**: npm scripts for Tailwind
- **PWA**: Service workers for offline support
- **Testing**: xUnit

### CI/CD
- **Git Workflow**: Git Flow (main/develop branches)
- **Commit Format**: Conventional Commits
- **Automation**: GitHub Actions
- **Release**: Semantic Release with automated versioning

## Architecture

- **Framework**: Blazor Web App (.NET 10) - Full-stack with server and client components
- **Styling**: Tailwind CSS v4 + daisyUI
- **Testing**: xUnit
- **PWA**: Service workers for offline support
- **Deployment**: Single deployment unit (integrated frontend + backend)

## Features

- ✅ Responsive UI with Tailwind + daisyUI
- ✅ Progressive Web App (PWA) support
- ✅ Automated testing
- ✅ Semantic versioning with automated releases
- ✅ Conventional commits with validation
- 🔄 Backend API integration (coming soon)
