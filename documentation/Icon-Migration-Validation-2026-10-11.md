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

## Library environment resolved — 2026-10-11

The initial suite (50 pass / 16 fail) had no Ladybug Tools installation. HoneybeeSchema 2.6.0 falls back to creating its installation under Program Files. Its supported `HoneybeeSchema.Helper.SettingConfig.LBTRootFolder` setting resolves this without elevated library permissions or conversion/test changes.

Fresh complete unchanged suite: **66 passed / 0 failed / 0 skipped**. Full Release solution build: PASS. Source/resource guards: 7 swaps, 0 unrelated production C# changes, 7 resource references, 0 errors; embedded icons PASS in both icon-bearing assemblies. Local TRX: `.icon-migration/SAM_LadybugTools/environment/configured-escalated.trx` in the parent workspace.

To reproduce after building the test project, provision a writable library root and write `settings.txt` beside the copied `HoneybeeSchema.dll` (the test project outputs to the sibling `build_tests` directory):

```powershell
$libraryRoot = 'C:/your/writable/test-library/ladybug_tools'
$standards = Join-Path $libraryRoot 'resources/standards/honeybee_standards'
New-Item -ItemType Directory -Force $standards | Out-Null
foreach ($name in 'energy_default.json', 'radiance_default.json') {
    Invoke-WebRequest "https://raw.githubusercontent.com/ladybug-tools/honeybee-standards/master/honeybee_standards/$name" -OutFile (Join-Path $standards $name)
}
@{ LBTRootFolder = $libraryRoot } | ConvertTo-Json -Compress |
    Set-Content '../build_tests/settings.txt' -Encoding utf8
dotnet test SAM_LadybugTools.Tests/SAM.Core.LadybugTools.Tests.csproj -c Release
```

Preserve any existing test-output settings before writing. This configures only the test assembly copy; do not change a live Ladybug Tools installation. Verified standards SHA256: energy `06d0801814c42fcddd64a867fb87372bbc7546f56672a089507ee5904fccb1d9`, radiance `69bf6b9431b87e683a9aa328e6a3ecf4447a9cb5ddc64bf7bfe45e0cd6ddd84d`. The URLs track vendor master; record hashes when provisioning a fresh environment. Production libraries, tests, ACLs and approved icons are unchanged.

Next step: resolve any listed blockers, then verify final-head GitHub checks and merge only if green and safe under the owner authorization. No force-push or branch deletion. Hosted Rhino smoke is not claimed as a fresh pass; source and embedded-resource checks are the completed icon verification.
