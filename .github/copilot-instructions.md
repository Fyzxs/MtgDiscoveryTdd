**Any code you commit SHOULD compile, and new and existing tests related to the change SHOULD pass.**

You MUST make your best effort to ensure your changes satisfy those criteria before committing. If for any reason you were unable to build or test the changes, you MUST report that. You MUST NOT claim success unless all builds and tests pass as described above.

You MUST refer to the [Building & Testing in dotnet/runtime](#building--testing-in-dotnetruntime) instructions and use the commands and approaches specified there before attempting your own suggestions.

You MUST follow all code-formatting and naming conventions defined in [`.editorconfig`](/.editorconfig).

In addition to the rules enforced by `.editorconfig`, you SHOULD:

- Prefer file-scoped namespace declarations and single-line using directives.
- Ensure that the final return statement of a method is on its own line.
- Use pattern matching and switch expressions wherever possible.
- Use `nameof` instead of string literals when referring to member names.
- Always use `is null` or `is not null` instead of `== null` or `!= null`.
- Always use `is false` instead of the `!` for negation.
- Trust the C# null annotations and don't add null checks when the type system says a value cannot be null.
- Prefer `?.` if applicable (e.g. `scope?.Dispose()`).
- Use `ObjectDisposedException.ThrowIf` where applicable.
- When writing tests, emit the "arrange", "act", "assert" comments.

---

# Building & Testing in dotnet/runtime

- [1. Prerequisites](#1-prerequisites)
    - [1.1. Determine Affected Components](#11-determine-affected-components)
    - [1.2. Baseline Setup](#12-baseline-setup)
- [2. Iterative Build and Test Strategy](#2-iterative-build-and-test-strategy)
    - [2.1. Success Criteria](#21-success-criteria)
- [3. CoreCLR (CLR) Workflow](#3-coreclr-clr-workflow)
- [4. Mono Runtime Workflow](#4-mono-runtime-workflow)
- [5. Libraries Workflow](#5-libraries-workflow)
    - [5.1. How To: Identify Affected Libraries](#51-how-to-identify-affected-libraries)
    - [5.2. How To: Build and Test Specific Library](#52-how-to-build-and-test-specific-library)
- [6. WebAssembly (WASM) Libraries Workflow](#6-webassembly-wasm-libraries-workflow)
- [7. Additional Notes](#7-additional-notes)
    - [7.1. Troubleshooting](#71-troubleshooting)
    - [7.2. Windows Command Equivalents](#72-windows-command-equivalents)
    - [7.3. References](#73-references)

## 1. Prerequisites

These steps need to be done **before** applying any changes.

### 1.1. Determine Affected Components

Identify which components will be impacted by the changes. If in doubt, analyze the paths of the files to be updated:
- If the changes are not in the `src` folder it is most possibly an infra-only or a docs-only change. Skip build and test steps.

---

### 1.2. Baseline Setup

Before applying any changes, ensure you have a full successful build of the needed runtime+libraries as a baseline.

1. Checkout `main` branch

2. From the repository root, run the build.

3. Verify the build completed without error.
    - _If the baseline build failed, report the failure and don't proceed with the changes._

4. Switch back to the working branch.

---

## 2. Iterative Build and Test Strategy

1. Apply the intended changes

2. **Attempt Build.** If the build fails, attempt to fix and retry the step (up to 5 attempts).

3. **Attempt Test.**
    - If a test _build_ fails, attempt to fix and retry the step (up to 5 attempts).
    - If a test _run_ fails,
        - Determine if the problem is in the test or in the source
        - If the problem is in the test, attempt to fix and retry the step (up to 5 attempts).
        - If the problem is in the source, reconsider the full changeset, attempt to fix and repeat the workflow.

4. **Workflow Iteration:**
    - Repeat build and test up to 5 cycles.
    - If issues persist after 5 workflow cycles, report failure.
    - If the same error persists after each fix attempt, do not repeat the same fix. Instead, escalate or report with full logs.

When retrying, attempt different fixes and adjust based on the build/test results.

### 2.1. Success Criteria

- **Build:**
    - Completes without errors.
    - Any non-zero exit code from build commands is considered a failure.

- **Tests:**
    - All tests must pass (zero failures).
    - Any non-zero exit code from test commands is considered a failure.

- **Workflow:**
    - On success: Report completion
    - Otherwise: Report error(s) with logs for diagnostics.
        - Collect logs from `artifacts/log/` and the console output for both build and test steps.
        - Attach relevant log files or error snippets when reporting failures.

---

## 7. Additional Notes

### 7.1. Troubleshooting

- **Shared Framework Missing**

    - If the build fails with an error "The shared framework must be built before the local targeting pack can be consumed.", build both the runtime (clr or mono) and the libs.
      E.g., from the repo root, run `./build.sh clr+libs -rc release` if working on Libraries on CoreCLR. To find the applicable command, refer to the section [1.2. Baseline Setup](#12-baseline-setup).

- **Testhost Is Missing**

    - If a test run fails with errors indicating a missing testhost, such as:
        - "Failed to launch testhost with error: System.IO.FileNotFoundException", or
        - "artifacts/bin/testhost/... No such file or directory",
      that means some of the prerequisites were not built.

    - To resolve, build both the appropriate runtime (clr or mono) and the libs as a single command before running tests.
      E.g., from the repo root, run `./build.sh clr+libs -rc release` before testing Libraries on CoreCLR. To find the applicable command, refer to the section [1.2. Baseline Setup](#12-baseline-setup).

- **Build Timeout**

    - Do not fail or cancel initial `./build.sh` builds due to timeout unless at least 10 minutes have elapsed.

    - Only wait for long-running `./build.sh` commands if they continue to produce output.
      If there is no output for 5 minutes, assume the build is stuck and fail early.

- **Target Does Not Exist**

    - Avoid specifying a target framework when building unless explicitly asked.
      Build should identify and select the appropriate `$(NetCoreAppCurrent)` automatically.

---

### 7.2. Windows Command Equivalents

- Use `build.cmd` instead of `build.sh` on Windows.
- Set PATH: `set PATH=%CD%\.dotnet;%PATH%`
- All other commands are similar unless otherwise noted.

---

### 7.3. References

- [`.editorconfig`](/.editorconfig)
- [Building CoreCLR Guide](/docs/workflow/building/coreclr/README.md)
- [Building and Running CoreCLR Tests](/docs/workflow/testing/coreclr/testing.md)
- [Building Mono](/docs/workflow/building/mono/README.md)
- [Running test suites using Mono](/docs/workflow/testing/mono/testing.md)
- [Build Libraries](/docs/workflow/building/libraries/README.md)
- [Testing Libraries](/docs/workflow/testing/libraries/testing.md)
- [Build libraries for WebAssembly](/docs/workflow/building/libraries/webassembly-instructions.md)
- [Testing Libraries on WebAssembly](/docs/workflow/testing/libraries/testing-wasm.md)
