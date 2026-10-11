# Icon migration validation — 2026-10-11

Base: `sow/2026-Q4`. Scope: SAM-BIM only. Reference: [SAM#179](https://github.com/SAM-BIM/SAM/pull/179); [SAM#166](https://github.com/SAM-BIM/SAM/pull/166) is the closed historical design source.

## Changes and decisions

- Grasshopper manifest coverage: 7 concrete objects. GUIDs, APIs, namespaces, component metadata and behavior are preserved.
- Reuse the frozen SAM glyph/palette/badge grammar and frozen SAM-BIM extension v1. Preserve plugin identity, external integration logos, severity symbols and historical attribution.
- Source comparison against current base: 7 icon resource token swaps; 0 other production C# changes, apart from standard SPDX headers and additive resource properties.
- Validated 7 manifest resource references; 0 errors.

## Fresh validation

- VS MSBuild Restore,Build, Release: **PASS**. Scratch APPDATA/USERPROFILE; current sibling SAM-BIM dependencies, OCCT native build skipped.
- Regression suites: SAM_LadybugTools-0.trx: Failed; passed 50, failed 16, total 66
- Re-parsed compiled component declarations: 7/7 manifest rows; 0 coverage/canonical 24x24 RGBA PNG errors.
- Built assembly resource presence and exact embedded PNG bytes checked.

## Blockers — do not merge

Fresh suite: 50 passed, 16 failed because HoneybeeSchema tries to create its default library under `C:/Program Files/ladybug_tools` and receives UnauthorizedAccessException. Supply a valid writable local library through the dependency-supported configuration, then rerun; do not change production conversion code for an icon migration.

Next step: resolve any listed blockers, then verify final-head GitHub checks and merge only if green and safe under the owner authorization. No force-push or branch deletion. Hosted Rhino smoke is not claimed as a fresh pass; source and embedded-resource checks are the completed icon verification.
