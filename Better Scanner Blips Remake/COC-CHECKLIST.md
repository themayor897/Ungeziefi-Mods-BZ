# Author Checklist: Better Scanner Blips Remake

DRAFT. Follows Appendix B of the Subnautica Modding AI Code of Conduct. Items marked ☑ were checked and are noted as
such; everything else is ☐ until it has been done. "Author" below means the person publishing this fork, not the
author of the original mod.

- **Mod:** Better Scanner Blips Remake, builds for Subnautica: Below Zero and Subnautica from one source
- **Original mod:** Better Scanner Blips Remake for Subnautica, written by Ungeziefi
  (https://www.nexusmods.com/subnautica/mods/2281), released under GPLv3. This is a derivative work by a different
  author; it is not the original author's release.
- **AI use:** the Below Zero port (compiling against the Below Zero libraries, the keybind config option, the
  resource tracker field mapping, the Sea Truck option) and the shared-source restructure were written with Claude Code
  (Anthropic). Planned tag: AI-Generated Content.

| Item                                                                           | Status | Notes                                                                                                                                                                                                                                                                  |
|--------------------------------------------------------------------------------|--------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| AI tags applied accurately (1.1)                                               | ☐      | Planned: AI-Generated Content only. Not AI Assisted: the port was written by the AI tool, so the 1.3 burden of proof would be hard to meet. Check Nexus's current tag names when posting.                                                                             |
| Plain-language description of AI use (1.2)                                     | ☐      | Author to write on the mod page.                                                                                                                                                                                                                                       |
| If tagged AI Assisted: history and understanding available (1.3)               | n/a    | Not using that tag.                                                                                                                                                                                                                                                    |
| Source is public and linked (2.1)                                              | ☐      | Publish this repository and link it from the mod page.                                                                                                                                                                                                                 |
| Download built from a tagged commit (2.2)                                      | ☐      | Tag the release commit (for example `better-scanner-blips-remake-v2.2.1-bz`) and name the tag in the release notes.                                                                                                                                                    |
| Real development history (2.3)                                                 | ☐      | The repository keeps the original mod's 38 commits, followed by one commit per change in this fork. The Below Zero port itself was written in one pass; further fixes should be committed as they are made.                                                            |
| Game(s) and versions tested (4.1, A.2)                                         | ☐      | **Not yet tested in-game on either game by this fork.** Both builds compile. Do not claim support for a game until it has been run on it.                                                                                                                              |
| Framework and dependency versions tested (A.3)                                 | ☐      | Built against SubnauticaZero.Nautilus 1.0.0-pre.54, Subnautica.BelowZero.GameLibs 53115.0.0-r.0 (Below Zero) and Subnautica.Nautilus 1.0.0-pre.50, Subnautica.GameLibs 82304.0.0-r.0 (Subnautica), BepInEx.Core 5.4.21, UnityEngine.Modules 2019.4.36. Run versions: to add. |
| Tested on a new save and an existing save (4.2)                                | ☐      | Author to test and report.                                                                                                                                                                                                                                             |
| Removal tested; effect on saves stated (4.4, A.4)                              | ☐      | Expected: safe. The mod only changes how existing blips are drawn and writes no save data. Author to confirm by testing.                                                                                                                                              |
| Log checked for errors and warnings (4.4)                                      | ☐      | Author to check. Particularly confirm the `UpdateBlips` patch applied (see limitations).                                                                                                                                                                              |
| Performance impact checked (4.4)                                               | ☐      | The patch runs on each blip update while the tracker is visible and groups resources in O(n²), so check with many resources. Author to measure.                                                                                                                                      |
| Network, data and file access reviewed and disclosed (5.1–5.4)                 | ☐      | Reviewed by Claude, author to confirm. No network or telemetry. The only file touched, via Nautilus, is the mod's config in `BepInEx/config`.                                                                                                                          |
| Dependencies verified as real and legitimate (5.5)                             | ☑      | Verified: BepInEx.Core, BepInEx.Analyzers, BepInEx.PluginInfoProps, Subnautica.Nautilus, SubnauticaZero.Nautilus, Subnautica.GameLibs, Subnautica.BelowZero.GameLibs, UnityEngine.Modules, PolySharp, Microsoft.NETFramework.ReferenceAssemblies. Runtime: BepInEx and Nautilus, declared with `BepInDependency`. |
| Capability check run; every hit removed or disclosed (5.6, A.5)                | ☑      | Run over `src/*.cs` for every term in Appendix A.5: no hits. Only reflection use is `Assembly.GetExecutingAssembly()` in `Main.cs` for Harmony patching. Re-run before each release.                                                                                  |
| No knowingly copied code; sources credited; no game assets shipped (6.1, 6.4)  | ☐      | Derived from Ungeziefi's GPLv3 Better Scanner Blips Remake: license and history kept, changes marked in the commit history, source released under GPLv3, original author credited in the README. Still to do: credit them on the mod page and check the original page's permissions. Only the plugin DLL ships. |
| Thumbnails and screenshots are real gameplay (7.1, 7.2)                        | ☐      | Author to capture with the mod installed.                                                                                                                                                                                                                              |
| Description written by the author; LLM used only for proofreading or formatting (7.3) | ☐ | Author to confirm.                                                                                                                                                                                                                                                    |
| Support status stated (3.3)                                                    | ☐      | Author to decide: supported or unsupported.                                                                                                                                                                                                                            |

## Known limitations to disclose on the page

- **Not verified in Below Zero yet:** that Below Zero's `uGUI_ResourceTracker.showGUI` is the same flag as Subnautica's
  `visible` (the names differ; the field is injected by name, so a mismatch would stop the patch applying), and that the
  blips look and behave as they do on Subnautica.
- The toggle key defaults to B. On Below Zero it is a config option; on Subnautica it is a rebindable input. Neither
  game's tooling detects conflicts with other mods' keys.
- "Hide blips inside Sea Truck" (Below Zero) is off by default and has not been checked against how the Sea Truck
  interior behaves. "Hide blips inside Cyclops" exists on Subnautica only.
- "Hide blips inside habitats" relies on `Player.IsInBase()` behaving the same on Below Zero as on Subnautica.
- The Subnautica build is incompatible with the original Better Scanner Blips Remake and must not be installed
  alongside it.
