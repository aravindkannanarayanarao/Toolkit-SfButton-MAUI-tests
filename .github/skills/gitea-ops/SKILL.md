---
name: gitea-ops
description: Runs Gitea CRUD-style operations from chat by securely using a Gitea token and executing a PowerShell script. Use when you need read, retrieve-all, create, update, close, or delete operations similar to MCP behavior.
metadata:
  author: maui-custom-controls
  version: "1.0"
compatibility: Requires PowerShell 7+ (pwsh) and network access to your Gitea instance.
---

# Gitea Ops Skill

This skill provides an MCP-like workflow using a PowerShell script that calls Gitea REST APIs.

## What This Skill Does

- Prompts for context values (base URL, owner, repository, operation)
- Uses a secure token input flow (environment variable preferred)
- Runs a PowerShell script for issue CRUD-style operations
- Returns structured JSON output suitable for agent summarization

## Supported Operations

### Issue Operations

| Operation | Behavior |
|-----------|----------|
| `list` | Retrieve all issues from a repository (default: top 50) |
| `get` | Retrieve one issue by number |
| `create` | Create an issue with title and optional body |
| `update` | Update issue title/body/state |
| `close` | Close an issue |
| `delete` | Delete an issue by number |

### Pull Request Operations

| Operation | Behavior |
|-----------|----------|
| `get-pr` | Retrieve PR metadata (title, description, author, branches, status) |
| `list-pr-files` | List changed files in a PR |
| `pr-diff` | Get the raw unified diff for a PR |
| `create-pr` | Create a new pull request from a head branch to a base branch |
| `create-review-comment` | Post an inline review comment on a PR file/line |
| `post-pr-comment` | Post a general comment on a PR |

## Security Rules

1. Never echo the token to output
2. Prefer token in env var `GITEA_TOKEN`
3. Do not store tokens in files or commit history
4. Require explicit confirmation before `delete`

## Inputs

| Input | Required | Notes |
|------|----------|-------|
| GiteaBaseUrl | Conditionally | Default: `https://gitea.syncfusion.com` |
| Owner | Conditionally | Default: `essential-studio` |
| Repository | Conditionally | Repository name. Default: `maui-tabview` |
| Operation | Yes | `list`, `get`, `create`, `update`, `close`, `delete`, `get-pr`, `list-pr-files`, `pr-diff`, `create-pr`, `create-review-comment`, `post-pr-comment` |
| IssueNumber | get/update/close/delete | Numeric issue number (must be > 0) |
| PullNumber | PR operations | Numeric PR number (must be > 0) |
| Title | create/update | Required for create |
| Body | Optional | Issue/comment description text |
| State | update | `open` or `closed` |
| FilePath | create-review-comment | File path for inline review comment |
| Line | create-review-comment | Line number for inline review comment |
| ReviewAction | create-review-comment | `APPROVED`, `REQUEST_CHANGES`, or `COMMENT` (default: `COMMENT`) |
| HeadBranch | create-pr | Source branch name (e.g., `fix/12345-null-crash`) |
| BaseBranch | create-pr | Target branch name (default: `development`) |
| Top | list/list-pr-files | Default `50` |

## Execution Steps

1. Ask for base URL, owner, repo, operation, and required fields.
2. If token is missing, check whether the environment variable is set:

```bash
# Check if the variable is set
printenv GITEA_TOKEN
```

If the variable is **not set**, do NOT ask the user to paste the token in the chat or terminal. Instead, instruct them to add it as a **persistent machine environment variable**:

**macOS / Linux:**
1. Open your shell profile (`~/.zshrc` for zsh or `~/.bashrc` for bash)
2. Add the line: `export GITEA_TOKEN='<your-gitea-token>'`
3. Save the file and run `source ~/.zshrc` (or `source ~/.bashrc`)
4. Restart VS Code to pick up the new variable

**Windows (Environment Variables UI):**
1. Open **Settings → System → About → Advanced system settings → Environment Variables**
2. Under **User variables**, click **New**
3. Set Variable name: `GITEA_TOKEN` and Variable value: `<your-gitea-token>`
4. Click OK and restart VS Code to pick up the new variable

**Windows (PowerShell — persistent):**
```powershell
[System.Environment]::SetEnvironmentVariable('GITEA_TOKEN', '<your-gitea-token>', 'User')
```
Then restart VS Code.

> ⚠️ **Security**: Never pass tokens directly in chat messages, agent prompts, or inline terminal commands — they may be logged or accidentally committed.

3. Optionally set reusable defaults:

```bash
export GITEA_BASE_URL='https://gitea.syncfusion.com'
export GITEA_OWNER='essential-studio'
export GITEA_REPO='maui-tabview'
```

4. Run the script with `pwsh`.
5. For `delete`, ask for explicit confirmation before execution.
6. Summarize result from JSON output.

## Command Templates

### Issue Operations

```bash
# List issues
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 -Operation list -Top 50

# Read one issue
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 -Operation get -IssueNumber 123

# Create an issue
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 -Operation create -Title "New issue" -Body "Created from skill"

# Update an issue
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 -Operation update -IssueNumber 123 -Title "Updated title" -Body "Updated body"

# Close an issue
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 -Operation close -IssueNumber 123

# Delete an issue
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 -Operation delete -IssueNumber 123
```

### Pull Request Operations

```bash
# Get PR metadata
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 -Operation get-pr -PullNumber 42

# List changed files in a PR
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 -Operation list-pr-files -PullNumber 42

# Get raw diff for a PR
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 -Operation pr-diff -PullNumber 42

# Post an inline review comment on a specific file and line
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 -Operation create-review-comment -PullNumber 42 -FilePath "maui/src/tabview/TabView/Control/SfTabView.cs" -Line 150 -Body "Consider using a guard clause here."

# Post a general comment on a PR
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 -Operation post-pr-comment -PullNumber 42 -Body "Overall the changes look good. See inline comments."

# Submit a review with APPROVED / REQUEST_CHANGES
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 -Operation create-review-comment -PullNumber 42 -Body "Approved with minor suggestions." -ReviewAction APPROVED

# Create a new pull request
pwsh .github/skills/gitea-ops/scripts/gitea.ps1 -Operation create-pr -Title "Fix: Null crash on tab selection" -Body "Fixes bug #12345" -HeadBranch "fix/12345-null-crash" -BaseBranch "development"
```

## Notes

- This skill is script-driven and not a true typed MCP tool.
- Supports both issue and pull request operations.
- The script path from the repo root is `.github/skills/gitea-ops/scripts/gitea.ps1`.
- Default repository is `maui-tabview` under `essential-studio` on `gitea.syncfusion.com`.
- You can extend it to releases, branches, and users with additional routes.
