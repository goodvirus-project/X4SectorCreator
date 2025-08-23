# Changelog

All notable changes to this project are documented in this file.

## [Unreleased] – 2025-08-23

- __Fix__: Resolved compiler errors from ambiguous `Graphics.FillPolygon(...)` calls.
  - In `X4SectorCreator/Forms/Galaxy/ProceduralGeneration/Algorithms/FactionAlgorithms/FactionIconGen.cs`, `Point[]` arrays (via collection expressions) are now passed explicitly to `FillPolygon` to avoid overload ambiguity between `Point` and `PointF`.
  - Examples: `diamond`, `tri1`, `tri2`, `tri`, `overlay` as `Point[]` variables, then `g.FillPolygon(..., variable)`.

- __Fix__: Addressed unused variable warnings (CS0168).
  - `X4SectorCreator/Forms/Galaxy/Sectors/SectorMapForm.cs`: In DEBUG builds, `ex` is logged using `Debug.WriteLine(ex);` before rethrowing. RELEASE behavior unchanged (MessageBox).
  - `X4SectorCreator/Forms/General/MainForm.cs`: Same approach—log `ex` in DEBUG before `throw;`.

- __Fix__: Contextual keyword warning (CS9258) in property accessor.
  - `X4SectorCreator/Forms/Galaxy/Regions/RegionDefinitionForm.cs`: Renamed loop variable `field` to `fieldObj`.

- __Code Quality__: Modernized/simplified initializations (IDE0300/IDE0028/IDE0305/IDE0090).
  - `FactionIconGen.cs`: Use collection expressions `[]` and target-typed `new(...)` for `Point[]` initializations while retaining unambiguous `FillPolygon` calls.
  - `MainForm.cs`: Initialize empty collections with `[]` (`Dictionary<(int,int), Cluster>`, `HashSet<(int,int)>`).
  - `MainForm.cs`: Create `List<SectorPlacement>` via `[.. Enum.GetValues<>().OrderBy(...)]`.

- __Feature__: Live updates for the sector map after changes.
  - Automatic `SectorMapForm.Reset()` after creating/updating clusters, sectors, and gate connections.
  - Affected files: `ClusterForm.cs`, `SectorForm.cs`, `GateForm.cs`, `SectorMapForm.cs`.

## Notes
- DEBUG/RELEASE behavior preserved (DEBUG logs and rethrows; RELEASE shows user dialogs).
- No functional changes to rendering logic; only removal of overload ambiguity and code cleanup.

