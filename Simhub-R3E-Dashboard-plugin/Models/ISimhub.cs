using GameReaderCommon;
using SimHub.Plugins;

namespace Simhub_R3E_Dashboard_plugin.Models
{
    public interface ISimhub
    {
        void Init(PluginManager pluginManager);
        void PluginManager_DataUpdated(ref GameData data, PluginManager manager);
    }
}
