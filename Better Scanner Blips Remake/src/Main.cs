using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Nautilus.Handlers;
#if SUBNAUTICA
using InputPaths = Nautilus.Handlers.GameInputHandler.Paths;
#endif

namespace Better_Scanner_Blips_Remake;

[BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
[BepInDependency("com.snmodding.nautilus")]
[BepInIncompatibility("BetterScannerBlips")]
[BepInIncompatibility("com.whotnt.subnautica.dynamicscannerblips.mod")]
#if SUBNAUTICA
// The original Subnautica mod patches the same methods; running both would apply every patch twice
[BepInIncompatibility("Ungeziefi.Better_Scanner_Blips_Remake")]
#endif
public class Main : BaseUnityPlugin
{
    public const string PLUGIN_GUID = "themayor897.Better_Scanner_Blips_Remake";
    public const string PLUGIN_NAME = "Better Scanner Blips Remake";
    public const string PLUGIN_VERSION = "2.2.1";

#if SUBNAUTICA
    public static GameInput.Button ToggleBlipsButton;
#endif

    private static Assembly Assembly { get; } = Assembly.GetExecutingAssembly();
    internal new static ManualLogSource Logger { get; private set; }
    internal new static Config Config { get; } = OptionsPanelHandler.RegisterModOptions<Config>();

    public void Awake()
    {
        Logger = base.Logger;
        Logger.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");

#if SUBNAUTICA
        ToggleBlipsButton = EnumHandler.AddEntry<GameInput.Button>("ToggleBlipsButton")
            .CreateInput("Toggle blips")
            .WithKeyboardBinding(InputPaths.Keyboard.B)
            .WithCategory("Better Scanner Blips Remake")
            .AvoidConflicts();
#endif

        Harmony.CreateAndPatchAll(Assembly, $"{PLUGIN_GUID}");
    }
}