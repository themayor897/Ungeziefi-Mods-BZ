# Better Scanner Blips Remake

Improves the scanner room's resource blips in Subnautica and Subnautica: Below Zero: blips scale and fade with distance,
off-screen blips are shown at the edge of the screen, nearby resources of the same type are grouped, fragments show
their specific names and whether you already know them, and you can recolor blips and text and toggle them with a key.

One source, two builds: `src/` is shared, and `SN/` and `BZ/` are thin projects that compile it for each game.

| Game                   | Status                                                                                      |
|------------------------|---------------------------------------------------------------------------------------------|
| Subnautica: Below Zero | Builds. Not yet run in-game. See the notes below on what has not been verified.             |
| Subnautica             | Builds. Not yet run in-game by this fork. Incompatible with the original mod (see below).   |

## Credit

This is a derivative work of **Better Scanner Blips Remake by Ungeziefi**
([Nexus Mods](https://www.nexusmods.com/subnautica/mods/2281),
[source](https://github.com/Ungeziefi/Subnautica-Mods)), used under the GNU General Public License v3.
The original commit history is preserved in this repository: every commit up to "Import Better Scanner Blips Remake with
its original history" is Ungeziefi's work. I am not the original author, and this is not the original author's release.
Please send feedback about the original Subnautica mod to its page.

The original is itself a remake of other scanner blip mods, which are marked incompatible: `BetterScannerBlips` and
`com.whotnt.subnautica.dynamicscannerblips.mod`.

## Changes from the original

The commits after the import are the full list of changes, each as its own diff:

- Sources moved to a shared `src/` folder with one project per game, using the repository's shared build settings.
- Added a Below Zero build. The game-specific code is limited to:
    - **Toggle key:** Subnautica keeps its rebindable input (default B). Below Zero's older input system can't register
      one, so it gets a keybind option in the options menu (default B).
    - **Resource tracker field:** the patched `uGUI_ResourceTracker.UpdateBlips` is given the tracker's visibility
      flag, called `visible` in Subnautica and `showGUI` in Below Zero.
    - **Vehicle option:** "Hide blips inside Cyclops" exists on Subnautica only. Below Zero has no Cyclops, so it gets
      "Hide blips inside Sea Truck" instead, off by default.
- Plugin GUID and namespace changed to `themayor897.Better_Scanner_Blips_Remake` / `Better_Scanner_Blips_Remake`. The
  Subnautica build is marked incompatible with the original (`Ungeziefi.Better_Scanner_Blips_Remake`) because both would
  patch the same methods. The DLL name is unchanged.

## Building

Requires the .NET SDK. NuGet restores the game libraries and Nautilus. Run from this folder:

```bash
dotnet build SN/"Better Scanner Blips Remake SN.csproj" -c Release
dotnet build BZ/"Better Scanner Blips Remake BZ.csproj" -c Release
```

Output goes to `Release/SN/` and `Release/BZ/` in the repository root, as a ready-to-copy `BepInEx/plugins/...` folder.
To also copy builds into your game folders, copy `Directory.Build.local.props.example` (repository root) to
`Directory.Build.local.props` and set the paths (that file is not committed).

## How it works

A Harmony postfix on `uGUI_ResourceTracker.UpdateBlips` (`src/Core.cs`) takes the tracker's list of resources and its
pool of blip UI objects, optionally groups nearby resources (`src/ResourceGrouping.cs`), then positions, scales, colors
and labels each blip (`src/BlipUpdating.cs`, `src/EdgePositioning.cs`, `src/ColorManagement.cs`). A second patch on
`ResourceTracker.Register` (`src/KnownFragmentFilter.cs`) remembers which specific blueprint each fragment belongs to,
so fragments can be named and marked as known. The mod only changes how the existing blips are drawn: it makes no network
connections, writes no save data, and touches no files other than its config.

## AI disclosure

The Below Zero port and the shared-source restructure were written with Claude Code (Anthropic). The original mod is
Ungeziefi's. See [COC-CHECKLIST.md](COC-CHECKLIST.md) for the Subnautica Modding AI Code of Conduct checklist.

## License

GPLv3, see [LICENSE](../LICENSE). The source for every release is this repository, at the tag named in the release notes.
