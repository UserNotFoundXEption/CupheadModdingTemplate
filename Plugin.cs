using BepInEx;

namespace CupheadModdingTemplate;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private static Plugin instance;

    private void Awake()
    {
        instance = this;
        Log("Loading modding template");

        new Properties().Init();
        new Veggies().Init();

        Log("Modding template loading completed");
    }

    public static void Log(object data)
    {
        instance.Logger.LogInfo(data);
    }
}

//Read README.md for instructions
