````skill
---
name: maui-feature-pr-template
description: Generates a pull request description for new features using the project's Feature PR template format. Use when creating or preparing a PR for a feature implementation to ensure all required sections are filled correctly.
compatibility: Requires a completed feature implementation with design details, API changes, test results, and platform verification.
---

# Feature PR Template Skill

Generates a complete pull request description for feature implementations following the project's standardized Feature PR template (`.github/PULL_REQUEST_TEMPLATE/Feature.md`). Takes feature context (description, design, API changes, files changed, platforms tested) and produces a ready-to-use PR body.

## When to Use

- Creating a pull request for a new feature
- Preparing a PR description after completing a feature implementation
- Ensuring the PR body follows the required Feature template format
- Populating all mandatory sections of the Feature PR template

## Core Principles

1. **Complete every section** — The Feature PR template has mandatory sections. Every section must be filled; do not leave placeholders like `(fill later)` or `N/A` without a valid reason
2. **Be specific, not generic** — Use actual API signatures, actual file names, and actual design details. Generic or vague descriptions reduce review quality
3. **Accuracy over brevity** — The solution description, API changes, and behavioral changes sections are critical for reviewers. Provide enough detail for a reviewer to understand the implementation without reading every line of code
4. **Match the template exactly** — Use the exact headings and structure from the Feature template. Do not add, remove, or rename sections
5. **Honest AI usage reporting** — Accurately report whether AI tools were used and in what capacity
6. **API changes must be precise** — List exact type signatures for added, changed, and removed APIs. Reviewers and PLO need accurate API surface documentation

## Inputs

| Input | Required | Description |
|-------|----------|-------------|
| Feature description | Yes | What the feature does — purpose, benefits, use cases |
| Design / analysis | Yes | Design approach, architecture decisions, links to design docs |
| Solution description | Yes | Detailed description of code changes |
| API changes | Yes | Added, changed, or removed public APIs with full signatures (or "None") |
| Behavioral changes | Yes | Non-bug behavioral changes affecting existing users (or "None") |
| Files changed | Yes | List of files modified with descriptions of changes |
| Platforms tested | Yes | Which platforms were verified (iOS, Android, WinUI, macOS) |
| Unit test cases | Yes | Unit test file details and use cases covered |
| New test cases | No | Count and links to new test cases and testbed sample PRs |
| Known issues | No | Any known issues remaining after the implementation |
| AI usage | No | Whether AI tools (Code Studio) were used and how |
| Output screenshots | No | Screenshots for UI-affecting features |

## Outputs

| Field | Description |
|-------|-------------|
| `pr_body` | Complete PR description in the Feature template format, ready to paste |

## Template Structure Reference

The Feature PR template (`.github/PULL_REQUEST_TEMPLATE/Feature.md`) contains these sections in order:

1. **AI Usage** — Whether Code Studio or AI tools were used, primary use, and outcome
2. **Feature description** — Purpose, benefits, use cases, problem solved, competitor comparison
3. **Analysis and design** — External design docs, internal discussion links
4. **Solution description** — Detailed description of code changes
5. **Output screenshots** — Screenshots for UI-affecting features
6. **Areas affected and ensured** — Areas impacted by the code changes
7. **API Changes** — Added, changed, or removed APIs with full signatures
8. **Behavioral Changes** — Non-bug behavioral changes affecting existing users
9. **Unit Test cases** — Unit test file details and use cases covered
10. **New Test cases** — Count of new test cases, testbed sample links
11. **Is automated against existing test cases and ensured zero breaking** — Automation link
12. **Does it have any known issues?** — Known issues remaining
13. **MR CheckList** — Comprehensive verification checklist (19 items)

## Workflow

### Step 1: Gather Feature Context

Collect all required information from the completed feature implementation. This information typically comes from:

- The feature requirement (Azure DevOps work item, spec doc, or user-provided description)
- The design documentation or architecture decisions
- The code changes made
- The build and test results
- The state file (if using a feature agent)

**Required context checklist:**
- [ ] Feature description with purpose, benefits, and use cases
- [ ] Design approach and any linked design documents
- [ ] Detailed solution description
- [ ] Complete list of API changes (added/changed/removed) with exact signatures
- [ ] Behavioral changes for existing users
- [ ] List of files changed with descriptions
- [ ] Unit test details
- [ ] Build result (pass/fail)
- [ ] Test result (pass/fail, number of tests)
- [ ] Platforms verified

### Step 2: Determine AI Usage

Assess whether AI tools were used during the implementation:

| Question | Answer |
|----------|--------|
| Was Code Studio used? | Yes / No |
| Primary use | Generate new code / Refactor / Tests / Bug fix / Docs / Review / Other |
| Outcome | Saved time / Neutral / Cost time |
| If "Cost time", why? | 1-line explanation |

### Step 3: Document API Changes

This section requires precise documentation. For each API change, provide the full type signature:

**Added APIs:**
```
- ReturnType ControlName.PropertyName { get; set; } // Bindable Property
- ReturnType ControlName.MethodName(ParamType param);
- event EventHandler<EventArgsType> ControlName.EventName;
```

**Changed APIs:**
```
- OldSignature => NewSignature
```

**Removed APIs (if any):**
```
- ReturnType ControlName.RemovedMember
```

If no API changes, write "None".

### Step 4: Generate the PR Body

Produce the complete PR description using the following template. Replace all `{placeholder}` values with actual content from the feature context.

```markdown
### AI Usage: ###

- Code Studio used in this PR/MR? {Yes / No}

- **If Yes: Primary use (choose one from the below)**

    - {Selected option: Generate new code / Refactor/improve existing code / Tests / Bug fix / debugging help / Docs / comments / Review assistance / Other}

- **Outcome ({Saved time / Neutral / Cost time})**

- **If "Cost time": 1-line explanation**

{Explanation if cost time, otherwise remove this line}

### Feature description ###

{Clear and concise description of the feature.}

**Purpose/benefits of the feature**

{Describe the purpose and benefits.}

**Use cases**

{List the primary use cases.}

**What problem it solves?**

{Describe the problem this feature addresses.}

**Do competitors have this feature? If possible, add comparison and also share relevant links. Anyhow, this should be available in requirements doc which you can link**

{Competitor analysis or link to requirements doc.}

### Analysis and design ###

{Link to external design docs, internal forum discussions, or describe the design approach.}

### Solution description ###

{Detailed description of the code changes for reviewers. Explain what was changed in each file and why. Describe the architecture and patterns used.}

### Output screenshots ###

{If UI is affected:}

{Screenshots or descriptions of the feature's visual output. Or "N/A — no UI changes"}

### Areas affected and ensured ###

{List areas affected by the code changes. Note any existing behavior changes.}

### API Changes ###

{List all API changes with full signatures, or "None":}

Added:
{- ReturnType ControlName.PropertyName { get; set; } // description}

Changed:
{- old => new}

### Behavioral Changes ###

{Describe any non-bug related behavioral changes that may change how users' apps behave when upgrading to this version. Or "None — no behavioral changes."}

### Unit Test cases ###

{Provide unit test file details and the use cases considered in the implementation.}

### New Test cases ###

{List new test cases added. Include count and links to test PRs and testbed sample changes. Or "No new test cases added."}

### Is automated against existing test cases and ensured zero breaking ###

{Link to centralized automation results, or "Existing unit tests pass with zero failures."}

### Does it have any known issues?

{Details of known issues, or "No known issues."}

### MR CheckList ###

- [{x or space}] Have you ensured in iOS, Android, WinUI, and macOS(if supported)?
- [{x or space}] If there is any API change, did you get approval from PLO through [JIRA Tasks](https://syncfusion.atlassian.net/issues/?filter=66496)?
- [{x or space}] Is there any existing behavior change of other features due to this code change?
- [{x or space}] Have you enabled the necessary [settings](https://syncfusion.sharepoint.com/sites/MAUI/SitePages/Project-Settings.aspx) in your project, if you have created any new project?
- [{x or space}] Have you suppressed any warning or binding errors?
- [{x or space}] Did you add a sample in the testbed for your feature?
- [{x or space}] Did you record this case in the unit test or UI test?
- [{x or space}] Whether the new APIs and its comments are added as per [standard](https://syncfusion.sharepoint.com/sites/MAUI/SitePages/Coding.aspx)?
- [{x or space}] Does it contain code that reflects any internal framework API?
- [{x or space}] Have you included license for your control(If it is stable)?
- [{x or space}] Did you ensure the cases mentioned in [this](https://syncfusion.sharepoint.com/sites/MAUI/SitePages/Testing-Scenarios.aspx) link?
- [{x or space}] Did you test the [memory](https://syncfusion.sharepoint.com/sites/MAUI/SitePages/Memory.aspx) leak with your feature?
- [{x or space}] Did you ensure the performance? Check [this](https://syncfusion.sharepoint.com/sites/MAUI/SitePages/Performance.aspx) link to know more about performance optimization and how to automate?
- [{x or space}] Does it need localization? If so, did you ensure the cases mentioned in [this](https://syncfusion.sharepoint.com/sites/MAUI/SitePages/Localization.aspx) link?
- [{x or space}] Does it follow the [design system](https://syncfusion.sharepoint.com/sites/MAUI/SitePages/Design-System.aspx) guidelines and support light and dark themes?
- [{x or space}] Did you ensure the new control / feature met [accessibility](https://syncfusion.sharepoint.com/sites/MAUI/SitePages/Accessibility-in-.NET-MAUI.aspx) requirements?
- [{x or space}] Did you ensure [RTL](https://syncfusion.sharepoint.com/sites/MAUI/SitePages/RTL%20(Flow%20Direction).aspx)?
- [{x or space}] If you added any interaction related code, have you used touch and gesture APIs from core project?
- [{x or space}] If you use a third-party package, did you get approval to use it? If not, please get approval before merging.
```

### Step 5: Validate the PR Body

Before finalizing, verify:

- [ ] Every section heading matches the Feature template exactly
- [ ] No placeholder text remains (no `{…}`, `(fill after…)`, `TODO`)
- [ ] Feature description covers purpose, benefits, use cases, and problem solved
- [ ] API changes list exact type signatures for every added/changed/removed API
- [ ] Behavioral changes are documented or explicitly stated as "None"
- [ ] Solution description is detailed enough for code review
- [ ] Unit test cases section documents test files and use cases covered
- [ ] MR checklist items are checked/unchecked accurately based on actual verification
- [ ] All 19 MR checklist items are present (do not omit any)
- [ ] If UI changes exist, screenshot sections have content

### Step 6: Output the PR Body

Present the generated PR body to the user. The output should be:
1. The complete markdown text ready to be used as a PR description
2. Written to the state file under a `## PR Description` section (if a state file exists)

## Common Mistakes to Avoid

| Mistake | Why It's Wrong | Correct Approach |
|---------|----------------|------------------|
| ❌ Leaving API Changes as "None" when APIs were added | PLO review requires accurate API surface documentation | ✅ List every added/changed API with full type signature |
| ❌ Omitting MR checklist items | The Feature template has 19 items; all must be present | ✅ Include all 19 checklist items from the template |
| ❌ Generic solution description | Doesn't help reviewers understand the implementation | ✅ Describe per-file changes, patterns used, and architecture |
| ❌ Missing behavioral changes section | Users upgrading need to know about behavior differences | ✅ Document behavioral changes or explicitly state "None" |
| ❌ Skipping competitor comparison in feature description | Template requires it; links to requirements doc are acceptable | ✅ Provide comparison or link to the requirements document |
| ❌ Unchecked MR checklist without verification | Misrepresents verification status | ✅ Only check items actually verified |
| ❌ Not matching template headings exactly | PR may not render correctly in the review tool | ✅ Copy headings from the template verbatim |
| ❌ Empty unit test section | Reviewers need to know what test coverage exists | ✅ List test files, use cases, and coverage details |

## Completion Criteria

The skill is complete when:
- [ ] All sections of the Feature PR template are filled with accurate, specific content
- [ ] No placeholder or `(fill after…)` text remains
- [ ] Feature description covers all four sub-sections (purpose, use cases, problem, competitors)
- [ ] API changes list exact signatures for all public API surface changes
- [ ] Behavioral changes are documented or explicitly "None"
- [ ] Solution description is reviewer-friendly with per-file change details
- [ ] All 19 MR checklist items are present and reflect actual verification status
- [ ] The PR body is presented to the user or written to the state file
````
