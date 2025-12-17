# Git Workflow

## Branching Strategy: Git Flow

### Branch Types

1. **`main`** - Production-ready code
   - Always deployable
   - Protected branch (requires PR review)
   - Tagged with version numbers

2. **`develop`** - Development/staging branch
   - Integration branch for features
   - Should be stable
   - Base for feature branches

3. **Feature branches** - `feature/description`
   - Created from: `develop`
   - Merged back into: `develop` via PR
   - Example: `feature/user-authentication`, `feature/exercise-dashboard`

4. **Bugfix branches** - `bugfix/description`
   - Created from: `develop`
   - Merged back into: `develop` via PR
   - Example: `bugfix/navigation-menu-crash`

5. **Hotfix branches** - `hotfix/description`
   - Created from: `main`
   - Merged into: `main` AND `develop`
   - Example: `hotfix/critical-security-patch`

## Commit Messages

Follow conventional commits format:

```
<type>(<scope>): <subject>

<body>

<footer>
```

### Types
- `feat`: A new feature
- `fix`: A bug fix
- `docs`: Documentation changes
- `style`: Code style changes (formatting, semicolons, etc.)
- `refactor`: Code refactoring without feature or bug changes
- `perf`: Performance improvements
- `test`: Adding or updating tests
- `chore`: Build process, dependencies, tooling

### Examples

```
feat(authentication): add login component

- Implement login form with validation
- Add user authentication service
- Connect to backend API

Closes #123
```

```
fix(navigation): resolve mobile menu overflow issue

The navigation menu was overflowing on small screens.
Added max-height and overflow-y: auto to fix.

Closes #456
```

```
docs: update installation instructions
```

## Pull Requests

### Process
1. Create feature branch from `develop`
2. Make focused commits
3. Push to remote
4. Open PR against `develop` (or `main` for hotfixes)
5. Request review
6. Address feedback
7. Squash and merge

### PR Title Format
Follow commit message format:

```
feat(scope): description
```

### PR Description Template

```markdown
## Description
Brief description of changes

## Type of Change
- [ ] Bug fix
- [ ] New feature
- [ ] Breaking change
- [ ] Documentation update

## Testing
Describe how to test these changes

## Checklist
- [ ] Code follows style guidelines
- [ ] Comments added for complex logic
- [ ] Tests added/updated
- [ ] No new warnings generated
```

## Commit Best Practices

- **Atomic commits**: One logical change per commit
- **Frequent commits**: Push regularly (at least once per session)
- **Clear messages**: Future you will thank current you
- **No merge commits**: Use rebase or squash merge
- **Never force push** to shared branches (develop, main)

## Merging Strategy

- **Feature → develop**: Squash merge (keeps history clean)
- **develop → main**: Create merge commit (preserves integration point)
- **Hotfix → main & develop**: Merge commits (both branches need the commit)

## Protected Branch Rules (Main)

- Require PR review (at least 1 approval)
- Require status checks to pass
- Dismiss stale PR approvals
- Require branches to be up to date before merging
- Require linear history (no merge commits)
