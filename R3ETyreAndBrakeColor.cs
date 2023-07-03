using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Tyre_and_brake_color_plugin.Model;
using System;

namespace Simhub_R3E_Tyre_and_brake_color_plugin
{
    [PluginDescription("Convert tyre and brake temperature to a HEX color.")]
    [PluginAuthor("Mark Carlsen")]
    [PluginName("R3E Tyre and brake color")]
    public class R3ETyreAndBrakeColor : IPlugin, IDataPlugin
    {
        private readonly string _supportedGameName = "RRRE";
        //private readonly Information _tyres = new Information();
        private readonly Information _brakes = new Information();

        /// <summary>
        /// Instance of the current plugin manager
        /// </summary>
        public PluginManager PluginManager { get; set; }

        /// <summary>
        /// Gets a short plugin title to show in left menu. Return null if you want to use the title as defined in PluginName attribute.
        /// </summary>
        public string LeftMenuTitle => "R3E tyre and brake color";

        /// <summary>
        /// Called one time per game data update, contains all normalized game data,
        /// raw data are intentionnally "hidden" under a generic object type (A plugin SHOULD NOT USE IT)
        ///
        /// This method is on the critical path, it must execute as fast as possible and avoid throwing any error
        ///
        /// </summary>
        /// <param name="pluginManager"></param>
        /// <param name="data">Current game data, including current and previous data frame.</param>
        public void DataUpdate(PluginManager pluginManager, ref GameData data)
        {
            if (data.GameRunning && data.GameName == this._supportedGameName)
            {

            }
        }

        /// <summary>
        /// Called at plugin manager stop, close/dispose anything needed here !
        /// Plugins are rebuilt at game change
        /// </summary>
        /// <param name="pluginManager"></param>
        public void End(PluginManager pluginManager)
        {
        }

        /// <summary>
        /// Called once after plugins startup
        /// Plugins are rebuilt at game change
        /// </summary>
        /// <param name="pluginManager"></param>
        public void Init(PluginManager pluginManager)
        {
            SimHub.Logging.Current.Info("Starting plugin");
            pluginManager.AddProperty<bool>("PluginRunning", this.GetType(), true);
            pluginManager.AddProperty<string>("FrontLeftBrakeColor", this.GetType(), this._brakes.Front.Left.Color);
        }
    }
}
