using SimHub.Plugins;
using System.Windows.Media;

namespace Simhub_R3E_Extra_properties_plugin.Model
{
    public interface ITemperatureColor
    {
        /// <summary>
        /// Get color in HEX format.
        /// </summary>
        Color TemperatureColor { get; }
        /// <summary>
        /// Add color property to Simhub
        /// </summary>
        /// <param name="pluginManager"></param>
        void AddColorProperty(PluginManager pluginManager);
        /// <summary>
        /// Set/update color property value in Simhub
        /// </summary>
        /// <param name="pluginManager"></param>
        void SetColorProperty(PluginManager pluginManager);
    }
}
