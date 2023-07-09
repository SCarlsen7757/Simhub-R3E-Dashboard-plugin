using SimHub.Plugins;

namespace Simhub_R3E_Tyre_and_brake_color_plugin.Model
{
    public interface ITemperatureColor
    {
        /// <summary>
        /// Get color in HEX format.
        /// </summary>
        string Color { get; }
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
