# Exercise Planner

A full-stack exercise tracking application with separated frontend and backend architectures.

## Project Structure

```
exercise-planner/
├── frontend-blazorwasm/     # Blazor WebAssembly frontend
│   ├── App.razor
│   ├── Program.cs
│   ├── exercise-planner.csproj
│   ├── exercise-planner.sln
│   ├── package.json         # npm dependencies (Tailwind, PostCSS)
│   ├── Layout/              # Blazor layouts
│   ├── Pages/               # Blazor pages/components
│   ├── wwwroot/             # Static assets, styles, service worker
│   └── exercise-planner.Tests/  # Unit tests
├── backend-api/             # ASP.NET Core API (coming soon)
└── .github/
    ├── workflows/           # CI/CD automation
    └── instructions/        # Project guidelines
```

## Getting Started

### Frontend (Blazor WASM)

```bash
cd frontend-blazorwasm
dotnet watch
```

The app will open at `http://localhost:5154`

### Development Commands

```bash
cd frontend-blazorwasm

# Watch Tailwind CSS while developing
npm run dev

# Build Tailwind CSS
npm run build

# Make a conventional commit (interactive)
npm run commit

# Run tests
dotnet test

# Local release simulation
npm run release
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

- **Frontend**: Client-side Blazor WebAssembly with Tailwind CSS + daisyUI
- **Backend**: ASP.NET Core API (planned)
- **Database**: (planned)
- **Deployment**: Separate frontend/backend deployment pipelines

## Features

- ✅ Responsive UI with Tailwind + daisyUI
- ✅ Progressive Web App (PWA) support
- ✅ Automated testing
- ✅ Semantic versioning with automated releases
- ✅ Conventional commits with validation
- 🔄 Backend API integration (coming soon)
