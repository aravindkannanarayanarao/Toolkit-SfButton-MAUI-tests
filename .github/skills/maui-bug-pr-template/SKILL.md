````skill
---
name: maui-bug-pr-template
description: Generates a pull request description for bug fixes using the project's Bug PR template format. Use when creating or preparing a PR for a bug fix to ensure all required sections are filled correctly.
compatibility: Requires a completed bug fix with root cause analysis, fix description, and test results.
---

# Bug PR Template Skill

Generates a complete pull request description for bug fixes following the project's standardized Bug PR template (`.github/PULL_REQUEST_TEMPLATE/Bug.md`). Takes bug fix context (root cause, fix details, files changed, platforms tested) and produces a ready-to-use PR body.

## When to Use

- Creating a pull request for a bug fix
- Preparing a PR description after completing a bug fix
- Ensuring the PR body follows the required Bug template format
- Populating all mandatory sections of the Bug PR template

## Core Principles

1. **Complete every section** — The Bug PR template has mandatory sections. Every section must be filled; do not leave placeholders like `(fill later)` or `N/A` without a valid reason
2. **Be specific, not generic** — Use actual file names, actual root cause details, and actual test case information. Generic or vague descriptions reduce review quality
3. **Accuracy over brevity** — The root cause and solution sections are critical for reviewers. Provide enough detail for a reviewer to understand the fix without reading every line of code
4. **Match the template exactly** — Use the exact headings and structure from the Bug template. Do not add, remove, or rename sections
5. **Honest AI usage reporting** — Accurately report whether AI tools were used and in what capacity

## Inputs

| Input | Required | Description |
|-------|----------|-------------|
| Bug description | Yes | What was broken — the original bug report summary |
| Root cause | Yes | What caused the bug and why |
| Fix description | Yes | What was changed and why |
| Files changed | Yes | List of files modified with descriptions of changes |
| Platforms tested | Yes | Which platforms were verified (Android, iOS, WinUI, macOS) |
| Breaking issue info | No | If this was a breaking issue, the commit that caused the break |
| Test cases added | No | Details of new test cases, if any |
| Known issues | No | Any known issues remaining after the fix |
| AI usage | No | Whether AI tools (Code Studio) were used and how |
| Before/after screenshots | No | Screenshot descriptions for UI-affecting changes |

## Outputs

| Field | Description |
|-------|-------------|
| `pr_body` | Complete PR description in the Bug template format, ready to paste |

## Template Structure Reference

The Bug PR template (`.github/PULL_REQUEST_TEMPLATE/Bug.md`) contains these sections in order:

1. **AI Usage** — Whether Code Studio or AI tools were used, primary use, and outcome
2. **Bug Description** — Clear and concise description of the problem
3. **Root Cause** — Root cause analysis with reason for the bug and why it fails
4. **Reason for not identifying earlier** — Analysis of why the bug was missed (guidelines, specs, requirements)
5. **Is Breaking issue?** — Whether a previous commit caused this regression
6. **Solution description** — Detailed description of the code changes
7. **Output screenshots** — Before/after screenshots for UI changes
8. **Areas affected and ensured** — Areas impacted by the code changes
9. **New Test cases** — Test cases added for this bug
10. **Is automated against existing test cases and ensured zero breaking** — Automation link
11. **Does it have any known issues?** — Known issues remaining
12. **MR CheckList** — Final verification checklist

## Workflow

### Step 1: Gather Fix Context

Collect all required information from the completed bug fix. This information typically comes from:

- The bug report (Azure DevOps work item or user-provided description)
- The root cause analysis performed during the fix
- The code changes made
- The build and test results
- The state file (if using the issue-resolver agent: `CustomAgentLogsTmp/PRState/pr-XXXXX.md`)

**Required context checklist:**
- [ ] Original bug description and reproduction steps
- [ ] Root cause (what was wrong and why)
- [ ] Fix approach (what was changed and why)
- [ ] List of files changed with descriptions
- [ ] Build result (pass/fail)
- [ ] Test result (pass/fail, number of tests)
- [ ] Platforms verified

### Step 2: Determine AI Usage

Assess whether AI tools were used during the fix:

| Question | Answer |
|----------|--------|
| Was Code Studio used? | Yes / No |
| Primary use | Generate new code / Refactor / Tests / Bug fix / Docs / Review / Other |
| Outcome | Saved time / Neutral / Cost time |
| If "Cost time", why? | 1-line explanation |

### Step 3: Analyze "Reason for Not Identifying Earlier"

This section requires thoughtful analysis. Evaluate against these categories:

**Guidelines/documents not followed:**
- Common guidelines / Core team guidelines
- Specification document
- Requirement document

**Guidelines/documents not given:**
- Common guidelines / Core team guidelines
- Specification document
- Requirement document

Based on the root cause, determine:
- **Reason**: Which guideline or document gap contributed to the bug
- **Action taken**: What corrective action prevents recurrence
- **Related areas**: Other areas that may need the same fix or review

### Step 4: Generate the PR Body

Produce the complete PR description using the following template. Replace all `{placeholder}` values with actual content from the fix context.

```markdown
### AI Usage: ###

- Code Studio used in this PR/MR? {Yes / No}

- **If Yes: Primary use (choose one from the below)**

    - {Selected option: Generate new code / Refactor/improve existing code / Tests / Bug fix / debugging help / Docs / comments / Review assistance / Other}

- **Outcome ({Saved time / Neutral / Cost time})**

- **If "Cost time": 1-line explanation**

{Explanation if cost time, otherwise remove this line}

### Bug Description ###

{Clear and concise description of the problem. Include what was broken, when it occurs, and the expected vs actual behavior.}

### Root Cause ###

{Brief description of the root cause and analysis.}

**Reason for the bug:** {The specific wrong condition, wrong code, or missing logic that caused the bug}

**Why it fails because of the above reason:** {Explain the failure mechanism — how the wrong code leads to the observed bug}

### Reason for not identifying earlier ###

Find how it was missed in our earlier testing and development by analyzing the below checklist. This will help prevent similar mistakes in the future.

**Guidelines/documents are not followed**

{List which guidelines/documents were not followed, or "None" if all were followed}

**Guidelines/documents are not given**

{List which guidelines/documents were missing, or "None" if all existed}

**Reason:**
{One or more specific reasons from the above categories}

**Action taken:**
{What action was taken to prevent this in the future}

**Related areas:**
{Other areas that need the same fix or review, or "None identified"}

### Is Breaking issue? ###

{If yes: "Yes — introduced by commit [commit hash] in [description]." If no: "No"}

### Solution description ###

{Detailed description of the code changes for reviewers. Explain what was changed in each file and why.}

### Output screenshots ###

{If UI is affected:}

**Before changes:**
{Description of the before state or "N/A — no UI changes"}

**After changes:**
{Description of the after state or "N/A — no UI changes"}

### Areas affected and ensured ###

{List areas affected by the code changes. Note any existing behavior changes.}

### New Test cases ###

{List new test cases added, or "No new test cases added" if none.
Include count of new tests and links to test PRs if applicable.}

### Is automated against existing test cases and ensured zero breaking

{Link to centralized automation results, or "Existing unit tests pass with zero failures."}

### Does it have any known issues?

{Details of known issues, or "No known issues."}

### MR CheckList ###

- [{x or space}] Have you ensured in iOS, Android, WinUI, and macOS(if supported)?
- [{x or space}] If there is any API change, did you get approval from PLO through [JIRA Tasks](https://syncfusion.atlassian.net/issues/?filter=66496)?
- [{x or space}] Is there any existing behavior change of other features due to this code change?
```

### Step 5: Validate the PR Body

Before finalizing, verify:

- [ ] Every section heading matches the Bug template exactly
- [ ] No placeholder text remains (no `{…}`, `(fill after…)`, `TODO`)
- [ ] Root cause section has both sub-questions answered (reason + why it fails)
- [ ] "Reason for not identifying earlier" has all sub-sections filled
- [ ] Solution description is detailed enough for code review
- [ ] MR checklist items are checked/unchecked accurately based on actual verification
- [ ] If UI changes exist, screenshot sections describe before/after states

### Step 6: Output the PR Body

Present the generated PR body to the user. The output should be:
1. The complete markdown text ready to be used as a PR description
2. Written to the state file under a `## PR Description` section (if a state file exists)

## Common Mistakes to Avoid

| Mistake | Why It's Wrong | Correct Approach |
|---------|----------------|------------------|
| ❌ Leaving sections as "N/A" without justification | Reviewers need to know why it's not applicable | ✅ Explain why the section doesn't apply |
| ❌ Generic root cause like "wrong code" | Doesn't help reviewers understand the fix | ✅ Describe the specific logic error |
| ❌ Missing "Why it fails" explanation | Root cause section requires both parts | ✅ Explain the causal chain from wrong code to bug |
| ❌ Empty "Reason for not identifying earlier" | This is a mandatory retrospective section | ✅ Honestly assess why testing/review missed it |
| ❌ Unchecked MR checklist without verification | Misrepresents verification status | ✅ Only check items actually verified |
| ❌ Not matching template headings exactly | PR may not render correctly in the review tool | ✅ Copy headings from the template verbatim |

## Completion Criteria

The skill is complete when:
- [ ] All sections of the Bug PR template are filled with accurate, specific content
- [ ] No placeholder or `(fill after…)` text remains
- [ ] Root cause analysis is detailed with both reason and failure mechanism
- [ ] Solution description is reviewer-friendly
- [ ] MR checklist reflects actual verification status
- [ ] The PR body is presented to the user or written to the state file
````
