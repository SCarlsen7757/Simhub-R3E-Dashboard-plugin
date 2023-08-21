using SimHub.Plugins;

namespace Simhub_R3E_Extra_properties_plugin.Models
{
    public interface ISimhubProperty
    {
        /// <summary>
        /// Add property to simhub
        /// </summary>
        /// <param name="pluginManager"></param>
        void AddProperty(PluginManager pluginManager);
        /// <summary>
        /// Set/update property value in simhub
        /// </summary>
        /// <param name="pluginManager"></param>
        void SetProperty(PluginManager pluginManager);
    }
}
