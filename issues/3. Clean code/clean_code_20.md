### What is the purpose of CI/CD?
Continuous integration/continuous deployment automates and accelerates building, testing, and validating code. CI focuses on frequently merging and testing code changes to catch issues early, and CD focuses on automatically building and deploying updates reliably and frequently.

### How does automating style checks improve project quality?
Automatic checks help in maintaining a certain standard for code formatting and project doucmentation by catching small issues early and enforcing a specified style across the project without relying on manual review. This helps especially with projects that are very documentation-heavy.

### What are some challenges with enforcing checks in CI/CD?
One challenge is the setup and configuration of CI/CD workflows, as misconfigured workflows may fail for reasons unrelated to any actual errors found. Another challenge is having too strict of checks that can block commits/pull requests for the most minor of errors, which may slow down development and lower productivity.

### How do CI/CD pipelines differ between small projects and large teams?
For small projects, that pipeline is usually small, focusing on basic checks like syntax or typos. However, for larger teams, the pipeline expands to include unit tests, UI tests, security scanning, and a whole host of other complex checks.

## Implementing a CI/CD workflow in my repo
I used GitHub Actions to implement a markdown linter (markdownlint-cli) and spell checker (typos) workflow on the "sandbox" directory of my workflow. When a pull request into main is made, checks are made on every markdown file within "sandbox". Custom configurations have also been made to tailor these checks.

**File Locations:**
- **Workflow file**: .github/workflows/markdown_quality_checks.yml
- **markdownlint-cli Config**: .markdownlint.json
- **typo Config**: .typos.toml

**Images**

*Pull request failed to pass checks:*
![Test1](/issues/_images/CICD_001.jpg)

*Annotations list:*
![Test2](/issues/_images/CICD_002.jpg)