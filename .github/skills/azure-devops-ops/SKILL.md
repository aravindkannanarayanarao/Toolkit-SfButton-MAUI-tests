---
name: azure-devops-ops
description: Runs Azure DevOps CRUD-style operations from chat by securely prompting for an Azure DevOps Personal Access Token (PAT) and executing a PowerShell script. Use when you need read, retrieve-all, create, update, or delete operations similar to MCP behavior.
metadata:
  author: maui-custom-controls
  version: "1.0"
compatibility: Requires PowerShell 7+ (pwsh) and network access to dev.azure.com.
---

# Azure DevOps Ops Skill

This skill provides an MCP-like workflow using a PowerShell script that calls Azure DevOps REST APIs.

## What This Skill Does

- Prompts for context values (organization, project, operation)
- Uses a secure PAT input flow (environment variable preferred)
- Runs a PowerShell script for CRUD-style work item operations
- Returns structured JSON output suitable for agent summarization

## Supported Operations

| Operation | Behavior |
|-----------|----------|
| `list` | Retrieve all work items from a query (default: top 50) |
| `get` | Retrieve one work item by ID |
| `create` | Create a work item with title and optional description |
| `update` | Update title and/or description of a work item |
| `delete` | Delete a work item by ID |

## Security Rules

1. Never echo the PAT to output
2. Prefer PAT in env var `AZDO_PAT`
3. Do not store PAT in files or commit history
4. Require explicit confirmation before `delete`

## Inputs

| Input | Required | Notes |
|------|----------|-------|
| Organization | Conditionally | Example: `contoso` (from `https://dev.azure.com/contoso`). Default: `EssentialStudio` |
| Project | Conditionally | Azure DevOps project name. Default: `Mobile and Desktop` |
| OrganizationUrl | Optional | Can resolve org/project from URL like `https://dev.azure.com/contoso/MyProject` |
| Operation | Yes | `list`, `get`, `create`, `update`, `delete` |
| Work Item Type | list/create | Default `Bug` |
| Work Item ID | get/update/delete | Numeric ID (must be > 0) |
| Title | create/update | Required for create |
| Description | Optional | HTML/plain text accepted |
| AreaPath | list | Filter by area path (e.g., `Mobile and Desktop` or a sub-path like `Mobile and Desktop\\Controls\\TabView`) |
| State | list | Filter by state (e.g., `Active`, `New`, `Resolved`) |
| Top | list | Default `50` |
| Destroy | delete | Switch flag; if omitted, delete is soft (recycle bin). If set, permanent destruction |

## Execution Steps

1. Ask the user for organization, project, operation, and required fields.
2. If PAT is missing, check whether the environment variable is set:

```bash
# Check if the variable is set
printenv AZDO_PAT
```

If the variable is **not set**, do NOT ask the user to paste the token in the chat or terminal. Instead, instruct them to add it as a **persistent machine environment variable**:

**macOS / Linux:**
1. Open your shell profile (`~/.zshrc` for zsh or `~/.bashrc` for bash)
2. Add the line: `export AZDO_PAT='<your-azure-devops-pat>'`
3. Save the file and run `source ~/.zshrc` (or `source ~/.bashrc`)
4. Restart VS Code to pick up the new variable

**Windows (Environment Variables UI):**
1. Open **Settings → System → About → Advanced system settings → Environment Variables**
2. Under **User variables**, click **New**
3. Set Variable name: `AZDO_PAT` and Variable value: `<your-azure-devops-pat>`
4. Click OK and restart VS Code to pick up the new variable

**Windows (PowerShell — persistent):**
```powershell
[System.Environment]::SetEnvironmentVariable('AZDO_PAT', '<your-azure-devops-pat>', 'User')
```
Then restart VS Code.

> ⚠️ **Security**: Never pass tokens directly in chat messages, agent prompts, or inline terminal commands — they may be logged or accidentally committed.

Optionally set reusable context values:

```bash
export AZDO_ORGANIZATION='EssentialStudio'
export AZDO_PROJECT='Mobile and Desktop'
```

3. Run the script with `pwsh`.
4. For `delete`, ask for explicit confirmation before execution.
5. Summarize result from JSON output.

## Command Templates

```bash
# List bugs (default WorkItemType is Bug)
pwsh .github/skills/azure-devops-ops/scripts/ado.ps1 -Organization EssentialStudio -Project "Mobile and Desktop" -Operation list -Top 50

# List bugs filtered by area path and state
pwsh .github/skills/azure-devops-ops/scripts/ado.ps1 -Organization EssentialStudio -Project "Mobile and Desktop" -Operation list -AreaPath "Mobile and Desktop" -State Active -Top 20

# List using URL details (org + project inferred)
pwsh .github/skills/azure-devops-ops/scripts/ado.ps1 -OrganizationUrl "https://dev.azure.com/EssentialStudio/Mobile%20and%20Desktop" -Operation list -Top 50

# Read one work item
pwsh .github/skills/azure-devops-ops/scripts/ado.ps1 -Organization EssentialStudio -Project "Mobile and Desktop" -Operation get -WorkItemId 123

# Create a bug
pwsh .github/skills/azure-devops-ops/scripts/ado.ps1 -Organization EssentialStudio -Project "Mobile and Desktop" -Operation create -WorkItemType Bug -Title "New bug" -Description "Created from skill"

# Create a task
pwsh .github/skills/azure-devops-ops/scripts/ado.ps1 -Organization EssentialStudio -Project "Mobile and Desktop" -Operation create -WorkItemType Task -Title "New task"

# Update
pwsh .github/skills/azure-devops-ops/scripts/ado.ps1 -Organization EssentialStudio -Project "Mobile and Desktop" -Operation update -WorkItemId 123 -Title "Updated title"

# Delete (soft — moves to recycle bin)
pwsh .github/skills/azure-devops-ops/scripts/ado.ps1 -Organization EssentialStudio -Project "Mobile and Desktop" -Operation delete -WorkItemId 123

# Delete (permanent — use with caution)
pwsh .github/skills/azure-devops-ops/scripts/ado.ps1 -Organization EssentialStudio -Project "Mobile and Desktop" -Operation delete -WorkItemId 123 -Destroy
```

## Notes

- This skill is script-driven and not a true typed MCP tool.
- Delete is soft by default (recycle bin). Use `-Destroy` for permanent deletion.
- For broad API coverage (pipelines, repos, PR comments, etc.), extend the script with additional resource routes.
- The script path from the repo root is `.github/skills/azure-devops-ops/scripts/ado.ps1`.
