using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Dashboard_plugin.Models;
using Simhub_R3E_Dashboard_plugin.Settings;
using System;

namespace Simhub_R3E_Dashboard_plugin
{
    [PluginDescription("R3E Dashboard helper plugin")]
    [PluginAuthor("Mark Carlsen")]
    [PluginName("R3E Dashboard")]
    public class R3EDashboard : IPlugin, IDataPlugin
    {
        public R3EDashboard() { }

        public static ColorSettings ColorSettings { get; set; } = new ColorSettings();
        private readonly string _supportedGameName = "RRRE";
        private readonly TyresInformation _tyres = new TyresInformation();
        private readonly BrakesInformation _brakes = new BrakesInformation();

        /// <summary>
        /// Instance of the current plugin manager
        /// </summary>
        public PluginManager PluginManager { get; set; }

        /// <summary>
        /// Gets a short plugin title to show in left menu. Return null if you want to use the title as defined in PluginName attribute.
        /// </summary>
        public string LeftMenuTitle => null;

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
            if (!data.GameRunning || data.GameName != this._supportedGameName) return;

            _tyres.Update(data.NewData);
            _brakes.Update(data.NewData);
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
            this._brakes.Init(PluginManager);
            this._tyres.Init(PluginManager);

            SimHub.Logging.Current.Info("Plugin started");
        }
    }
}
