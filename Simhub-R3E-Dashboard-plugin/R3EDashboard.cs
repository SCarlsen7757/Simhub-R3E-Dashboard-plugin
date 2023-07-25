using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Dashboard_plugin.Models;
using Simhub_R3E_Dashboard_plugin.Models.Sector;
using Simhub_R3E_Dashboard_plugin.Settings;

namespace Simhub_R3E_Dashboard_plugin
{
    [PluginDescription("Raceroom Racing Experience Dashboard helper")]
    [PluginAuthor("Mark Carlsen")]
    [PluginName("R3E Dashboard")]
    public class R3EDashboard : IPlugin, IDataPlugin
    {
        public R3EDashboard() { }
        public static OptimalTemperatureColorSettings ColorSettings { get; set; } = new OptimalTemperatureColorSettings();
        public static SectorColorSettings SectorColorSettings { get; set; } = new SectorColorSettings();

        public static bool SupportedGame(GameData data)
        {
            return data.GameName == SupportedGameName;
        }
        public static string SupportedGameName { get => "RRRE"; }
        private readonly TyresInformation _tyres = new TyresInformation();
        private readonly BrakesInformation _brakes = new BrakesInformation();
        private readonly SectorsInformation _sectors = new SectorsInformation();
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
            if (!data.GameRunning || data.GameName != SupportedGameName) return;
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
            this._sectors.Init(PluginManager);
            pluginManager.DataUpdated += this._brakes.PluginManager_DataUpdated;
            pluginManager.DataUpdated += this._tyres.PluginManager_DataUpdated;
            pluginManager.DataUpdated += this._sectors.PluginManager_DataUpdated;

            pluginManager.CarChanged += Test;

            SimHub.Logging.Current.Info("Plugin started");
        }

        public void Test(string newCar, PluginManager manager)
        {
        }

        public void NewLapTest(int completedLapNumber, bool testLap, PluginManager manager, ref GameData data)
        {

        }
    }
}
