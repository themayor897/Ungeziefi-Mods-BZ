# Rotatable Ladders

Rotate base ladders in Subnautica and Subnautica: Below Zero. Look at a ladder, press the rotate key (default R), and it
turns a quarter turn. Rotations are saved per save file.

One source, two builds: `src/` is shared, and `SN/` and `BZ/` are thin projects that compile it for each game.

| Game                   | Status                                                               |
|------------------------|----------------------------------------------------------------------|
| Subnautica: Below Zero | Tested in-game.                                                      |
| Subnautica             | Builds. Not yet run in-game by this fork. Incompatible with the original mod (see below). |

## Credit

This is a derivative work of **Rotatable Ladders by Ungeziefi**
([Nexus Mods](https://www.nexusmods.com/subnautica/mods/2015),
[source](https://github.com/Ungeziefi/Subnautica-Mods)), used under the GNU General Public License v3.
The original commit history is preserved in this repository: every commit before the "Add license and README" commit is
Ungeziefi's work. I am not the original author, and this is not the original author's release. Please send feedback
about the original Subnautica mod to its page.

Built on [BepInEx](https://github.com/BepInEx/BepInEx), [Harmony](https://github.com/pardeike/Harmony) and
[Nautilus](https://github.com/SubnauticaModding/Nautilus).

## Changes from the original

The commits after "Add license and README" are the full list of changes, each as its own diff:

- Sources moved to a shared `src/` folder with one project per game.
- DOTween replaced by a coroutine for the smooth rotation. Below Zero doesn't ship DOTween, and this removes the bundled
  DLL for Subnautica too.
- Added a Below Zero build. The only game-specific code is the rotate input: Subnautica keeps its rebindable input
  (keyboard R, controller D-pad up), while Below Zero's older input system gets a keybind option in the options menu
  (default R, no controller binding).
- Plugin GUID and namespace changed to `themayor897.Rotatable_Ladders` / `Rotatable_Ladders`. The Subnautica build is
  marked incompatible with the original (`Ungeziefi.Rotatable_Ladders`) because both would patch the same methods. The
  DLL name (`Rotatable_Ladders.dll`) and save data file name are unchanged.

## Building

Requires the .NET SDK. NuGet restores the game libraries and Nautilus.

```bash
dotnet build SN/"Rotatable Ladders SN.csproj" -c Release
dotnet build BZ/"Rotatable Ladders BZ.csproj" -c Release
```

Output goes to `Release/SN/` and `Release/BZ/` as a ready-to-copy `BepInEx/plugins/...` folder. To also copy builds into
your game folders, copy `Directory.Build.local.props.example` to `Directory.Build.local.props` and set the paths
(that file is not committed).

## How it works

Three Harmony patches in `src/Core.cs`: show the prompt and handle the key while looking at a ladder
(`BaseLadder.OnHandHover`), re-apply saved rotations when a ladder loads (`BaseLadder.Start`), and clear saved data when
a ladder is deconstructed (`BaseDeconstructable.Deconstruct`). Rotations are stored in the mod's own save file
(`Rotatable_Ladders.json` in the save slot) and applied at runtime, so removing the mod resets ladders to default. The
mod makes no network connections and touches no files other than its config and that save file.

## AI disclosure

The Below Zero port and the shared-source restructure were written with Claude Code (Anthropic). The original mod is
Ungeziefi's. See [COC-CHECKLIST.md](COC-CHECKLIST.md) for the Subnautica Modding AI Code of Conduct checklist.

## License

GPLv3, see [LICENSE](LICENSE). The source for every release is this repository, at the tag named in the release notes.
