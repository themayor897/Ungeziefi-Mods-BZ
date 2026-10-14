# Subnautica Mods: Ports

My ports of [Ungeziefi's](https://github.com/Ungeziefi/Subnautica-Mods) Subnautica mods to Subnautica: Below Zero,
built from one source per mod so each can also ship for Subnautica.

## Credit

Every mod here is a derivative work of a mod by **Ungeziefi**, used under the GNU General Public License v3. Each mod's
original commit history is preserved in this repository, and the commits after it show exactly what I changed. I am not
the original author and these are not the original author's releases. Please send feedback about the original
Subnautica mods to their own pages.

## Mods

| Mod                                       | Below Zero      | Subnautica                   | Original                                                    |
|-------------------------------------------|-----------------|------------------------------|-------------------------------------------------------------|
| [Rotatable Ladders](Rotatable%20Ladders/) | Tested in-game  | Builds, not yet run in-game  | [Nexus](https://www.nexusmods.com/subnautica/mods/2015)     |

## Layout

Each mod has its own folder containing:

- `src/`: shared source for both games
- `SN/` and `BZ/`: thin projects that compile `src/` for Subnautica or Below Zero (`SUBNAUTICA` / `BELOWZERO` symbols
  select the few game-specific lines)
- `README.md` and `COC-CHECKLIST.md`: the mod's credit, changes, AI disclosure and Code of Conduct checklist

Shared build settings live in `Directory.Build.props` and `Directory.Build.targets` at the root. Builds are packaged into
`Release/<SN|BZ>/BepInEx/plugins/...`. To also copy builds into a game install, copy
`Directory.Build.local.props.example` to `Directory.Build.local.props` (not committed) and set the paths.

```bash
dotnet build Ports.sln -c Release
```

## Releases

Each Nexus download is built from a tag named `<mod>-v<version>-<sn|bz>`, for example `rotatable-ladders-v2.3.0-bz`,
which is named in that release's notes.

## Adding another port

To keep the original history, split the mod out of a clone of Ungeziefi's repository and import it here:

```bash
# in a clone of Ungeziefi/Subnautica-Mods
git subtree split -P "New Mods/<Mod Name>" -b split-<mod>

# in this repository
git subtree add --prefix="<Mod Name>" <path-to-that-clone> split-<mod>
```

Then restructure into `src/`, `SN/` and `BZ/` as separate, readable commits, and add the mod's README and checklist.

## AI disclosure

The Below Zero ports and the shared-source structure are written with Claude Code (Anthropic). See each mod's
`COC-CHECKLIST.md`.

## License

GPLv3, see [LICENSE](LICENSE).
