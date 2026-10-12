# Project Progress - SAM_LadybugTools (2026-Q4)

## Q4 agent instructions rollout closeout - 2026-10-12

- SAM-BIM/SAM_LadybugTools#14 merged as `d6223ed2b5e60f46cd1949d3ee88f4a6802394b2` (merge commit pinned to approved head `addae8aa9fe27443d4b02ee6a5aa2489e98a1d15`; base `sow/2026-Q4` `223ef21f406f633b1b2c60f512eace658e003b00`; validated content `e54fae4f33413e3190d433ef3172d999e3e98da8`). Owner-authorized 2026-10-12 after an independent review (`AGENT_ROLLOUT_REVIEW_2026-10-12.md`, local to the owner's workspace, not committed).
- Docs only: AGENTS.md, CLAUDE.md, plus the rollout record `documentation/Agent-Continuity-Rollout-Q4.md`. No product code, build, workflow, dependency pin or tool changed; this closeout is the only `PROJECT_PROGRESS.md` change.
- Validation: local documentation checks and commands are in `documentation/Agent-Continuity-Rollout-Q4.md` (`git diff --check`, file scope, UTF-8/LF/no BOM, import). Hosted checks at the approved head: build success (run 38257963692); spdx success (run 38257963633). Dependency selection: dependency clones in the build log: SAM @ sow/2026-Q4.
- Cleanup: remote docs/agent-instructions-rollout-q4 deleted with an expected-SHA lease on addae8aa9fe27443d4b02ee6a5aa2489e98a1d15 after confirming it is contained in sow/2026-Q4 and no open PR uses it as head or base; the local branch and its worktree are preserved (worktree in use). Other branches, worktrees and the frozen quarters were not touched.
- Remaining gaps: no agent-client behaviour or token benchmark has been run.
- Exact next step: Continue from the shared `AGENTS.md`. Open item carried from the pilots: verify on each installed agent client, in a fresh Q4 session, that it follows the instructions without loading the full progress history, and record the result.

## Q4 Grasshopper icon migration closeout — 2026-10-11

- SAM-BIM/SAM_LadybugTools#13 merged as `9b674bc08cb44e7a00e8f26660809f19360c6105`, reviewed head `fb51c50e47c85ebfbd20c8773dd57bf435ac77ba`. Merge commit; branches preserved. Approved frozen icon design applied to 7 concrete objects; GUIDs/APIs/namespaces/behaviour preserved.
- Resolved the missing Honeybee library through dependency-supported `settings.txt` `LBTRootFolder` pointing to a workspace-local library, with official default energy/radiance standards. No converter/test expectation, system installation or ACL change. Portable reproduction instructions committed in `documentation/Icon-Migration-Validation-2026-10-11.md`; local runtime files must be provisioned on another machine.
- Files: Grasshopper icon getters/resources/design kit, validation record. Full unchanged suite **66 passed / 0 failed / 0 skipped**; full Release solution build PASS. Fresh guards: 7 icon-token swaps, 0 unrelated production C# changes, 7 resource references, 0 errors; both icon-bearing assemblies pass embedded PNG verification. No fresh Rhino-hosted smoke claimed.
- Final-head pull-request build/SPDX runs `38140105177` / `38140105217` and dispatch build/SPDX `38140103175` / `38140104817` all PASS before merge. No approval/security rule bypass.
- Remaining: none for this icon PR. Next: owner visual review in installed host; no installer/submodule repin included. This docs-only Q4 `[skip ci]` closeout follows the known merge SHA.

## Branch

`sow/2026-Q4` - bootstrapped 2026-10-06 from `master` `abf0d215`. Frozen Q3 record: `sow/2026-Q3` @ `25953987` (not modified).

## Last updated

2026-10-06 (Q4 icon-redesign migration).

## Current status

Q4 branch cut from `master` `abf0d215`, which is the exact commit pinned in SAM_Deploy's frozen Q3 baseline (`v20261006.1`). Bootstrap added only internal docs (this file, `AGENTS.md`). No product source changed. No Q4 product work has started.

## Q4 priorities

Not yet set by the owner. Record them here at the first Q4 planning pass. Known carry-over work is listed below.

## Known carry-over work

- **SAM Grasshopper icon redesign - PR #11** (`feature/sam-gh-icon-redesign` @ `aa9d835c`, open, base `sow/2026-Q3`, not merged). Analysed 2026-10-06: the branch carries only its own 4 icon-only commits (`9ac7ea0`, `b79afa6`, `cc3eb07`, `aa9d835`) on top of Q3 commit `17775e3a`. Those commits are not reachable from `sow/2026-Q4` (Q4 is built on the promoted `master` line), so a plain retarget would list 11 commits. Replaying exactly those commits onto `sow/2026-Q4` @ `b941616c` is conflict-free (verified commit-by-commit with `git merge-tree`; identical to the net-diff merge). Planned action: rebase-onto Q4 as a new branch + PR, then close this one; owner-approved controlled task, not yet executed. **Update:** migrated; replacement Q4 PR SAM_LadybugTools#13 (see the icon-redesign migration section); this old PR stays open for now.

## Repository-specific next steps

- Await Q4 planning. Open PRs for Q4 work against `sow/2026-Q4`.
- Follow the continuity convention in `AGENTS.md` for every PR and closeout.

## Decisions / assumptions

- Q4 base is `master` `abf0d215`; the internal files were recovered from `sow/2026-Q3` into this branch only, never onto `master`.
- Q4 history intentionally does not contain the Q3 branch history (the maintained `master` is the promoted Q3 line, which is not a descendant of `sow/2026-Q3`); the frozen `sow/2026-Q3` branch is the permanent record.
- Historical Q2/Q3 content below is kept as evidence; its branch names, SHAs and next steps describe Q3 and are not current instructions.

## Validation

- Bootstrap verified 2026-10-06: `sow/2026-Q4` was created at exactly `abf0d215` and the push was a normal (non-forced) branch creation.

## Issues / blockers

- None at bootstrap.

## Next step

- Owner to set Q4 priorities; then start the first Q4 task from this branch.

## Q4 operational cleanup (2026-10-06)

- Reviewed every active Q2/Q3 reference in this repository on `sow/2026-Q4` (workflow branch filters, dependency-branch resolution, `.gitmodules`/validation, docs). Historical Q2/Q3 mentions (feature documentation records, the frozen Q3 section below) are intentionally unchanged.
- Changed (`b941616`): removed the dead `$candidates += 'sow/2026-Q2'` fallback from the dependency-branch resolution in `.github/workflows/build.yml`. No dependency repository has a `sow/2026-Q2` branch, so the entry never matched and resolution already fell through to the default branch; behaviour is unchanged (PR head ref, current sow ref, then the dependency's default branch) and no per-quarter edit is needed.
- Checked, no action: the `github.repository_owner == 'SAM-BIM'` build guard (intentional; its comment names HoareLea only to explain why the guard exists), CODEOWNERS (SAM-BIM owners), and workflow secrets (no HoareLea-named secret). The local `upstream` (HoareLea) remote is preserved.
- Carry-over: **SAM Grasshopper icon redesign - PR #11** (`feature/sam-gh-icon-redesign` @ `aa9d835c`, open, base `sow/2026-Q3`, not merged). Analysed 2026-10-06: the branch carries only its own 4 icon-only commits (`9ac7ea0`, `b79afa6`, `cc3eb07`, `aa9d835`) on top of Q3 commit `17775e3a`. Those commits are not reachable from `sow/2026-Q4` (Q4 is built on the promoted `master` line), so a plain retarget would list 11 commits. Replaying exactly those commits onto `sow/2026-Q4` @ `b941616c` is conflict-free (verified commit-by-commit with `git merge-tree`; identical to the net-diff merge). Planned action: rebase-onto Q4 as a new branch + PR, then close this one; owner-approved controlled task, not yet executed.
- Full cross-repository record, migration table and owner decisions: `SAM_Deploy:sow/2026-Q4` `PROJECT_PROGRESS.md`.

## Q4 icon-redesign migration (2026-10-06)

- Old PR: SAM-BIM/SAM_LadybugTools#11 (`feature/sam-gh-icon-redesign` @ `aa9d835c`, base `sow/2026-Q3`) - **preserved, open, untouched**.
- New branch `feature/sam-gh-icon-redesign-q4` cut from `sow/2026-Q4` @ `28815034`; new PR **SAM-BIM/SAM_LadybugTools#13** (base `sow/2026-Q4`), feature head `408b4104`. **Not merged.**
- Replayed (old -> new, `cherry-pick -x`; commit set taken from the GitHub PR metadata): `9ac7ea0`->`d578d58`, `b79afa6`->`e1ce061`, `cc3eb07`->`fa970dc`, `aa9d835`->`8e3006c`; replay-only tip `8e3006c1`; plus one new docs commit `408b410` pointing the PR record at the new PR. No Q3 history imported.
- Verified at the replay-only tip, before the record commit: result tree identical to the net-diff merge of the old feature onto Q4 (`1144a87a23`); same aggregate and per-commit `git patch-id`, file set (57 files), numstat and blobs as the old PR; no workflow/`.gitmodules`/`AGENTS.md`/`PROJECT_PROGRESS.md`/solution changes. The final PR head is not tree-identical to the old feature by design (extra documentation-only commit).
- Validation: `check_source.py origin/sow/2026-Q4` OK, `check_assemblies.py` OK, local build 0 errors, relevant tests green (see the PR body); PR CI `build` success, `spdx` success; mergeable: mergeable.
- Next: owner decides whether/when to close the old PR; merge remains the maintainer's call.

---

# Historical record - 2026-Q3 (frozen)

Source: last revision of the file on `sow/2026-Q3`, commit `4deff98` (the file was removed from the Q3 tip by `2595398`; `sow/2026-Q3` tip is `25953987`). Preserved verbatim except that heading levels are shifted down one. Everything below describes Q3 and is not a current instruction.

## Project Progress

### Branch
`sow/2026-Q3`

### Last updated
2026-09-22 - app.config cleanup merged

### Current status
Part of the repo-family .NET Framework `app.config` cleanup: base [SAM#126](https://github.com/SAM-BIM/SAM/pull/126) plus 17 sibling PRs, all merged into `sow/2026-Q3` on 2026-09-22 (SAM first), with their branches deleted.

### Completed
- [SAM_LadybugTools#9](https://github.com/SAM-BIM/SAM_LadybugTools/pull/9) merged as `050a5fac`: removed dead .NET Framework `app.config` files.

### Decisions / assumptions
- Every project here targets `netstandard2.0` or `net8.0(-windows)` and is an `OutputType Library`. Library `.dll.config` files are never read at runtime (only the host `Rhino.exe`/`Revit.exe` config is), so the net472-era binding redirects, `<supportedRuntime>` and `loadFromRemoteSources` were inert. They only emitted stale `.dll.config` files into `build/` and `%APPDATA%\SAM`.
- No `ConfigurationManager`/`AppSettings` use in the repo; deleted files held binding/runtime config only.

### Files changed
- `Grasshopper/SAM_LadybugTools.Analytical.Grasshopper/app.config` (deleted)
- `Grasshopper/SAM_LadybugTools.Core.Grasshopper/app.config` (deleted)
- `Grasshopper/SAM_LadybugTools.Geometry.Grasshopper/app.config` (deleted)
- `SAM_LadybugTools/SAM_LadybugTools.Analytical/app.config` (deleted)
- `SAM_LadybugTools/SAM_LadybugTools.Core/app.config` (deleted)
- `SAM_LadybugTools/SAM_LadybugTools.Geometry/app.config` (deleted)

### Validation
- Before merge, full `BuildAlls_v4.bat` (Debug Restore;Clean;Rebuild of every repo, starting from an emptied `%APPDATA%\SAM`): exit 0, 0 errors. The redeployed `%APPDATA%\SAM` has no `SAM.*.dll.config`.
- CI on the PR: build + spdx pass.

### Issues / blockers
- None known for this cleanup.

### Next step
- None for this cleanup. Continue with the next planned task on `sow/2026-Q3`.
