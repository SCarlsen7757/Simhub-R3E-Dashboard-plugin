using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Extra_properties_plugin.Models;
using Simhub_R3E_Extra_properties_plugin.Models.DriverData;
using Simhub_R3E_Extra_properties_plugin.Models.Sector;
using Simhub_R3E_Extra_properties_plugin.Settings;
using System;
using System.Windows.Media;

namespace Simhub_R3E_Extra_properties_plugin
{
    [PluginDescription("Raceroom Racing Experience Dashboard helper")]
    [PluginAuthor("Mark Carlsen")]
    [PluginName("R3E Dashboard")]
    public class R3EExtraProperties : IPlugin, IDataPlugin, IWPFSettingsV2
    {
        public R3EExtraProperties() { }
        public static TyreAndBrakeColorSettings TyreAndBrakeColorSettings { get; set; }
        public static SectorColorSettings SectorColorSettings { get; set; } = new SectorColorSettings();

        public string PluginName
        {
            get
            {
                PluginNameAttribute attribute = (PluginNameAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof(PluginNameAttribute));
                return attribute.name;
            }
        }

        public static bool SupportedGame(ref GameData data)
        {
            return data.GameName == SupportedGameName;
        }
        public static string SupportedGameName { get => "RRRE"; }
        private readonly TyresInformation _tyres = new TyresInformation();
        private readonly BrakesInformation _brakes = new BrakesInformation();
        private readonly SectorsInformation _sectors = new SectorsInformation();
        private readonly R3EDriverData _driverData = new R3EDriverData();
        /// <summary>
        /// Instance of the current plugin manager
        /// </summary>
        public PluginManager PluginManager { get; set; }
        /// <summary>
        /// Gets the left menu icon. Icon must be 24x24 and compatible with black and white display.
        /// </summary>
        public ImageSource PictureIcon => this.ToIcon(Properties.Resources.sdkmenuicon);
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
            if (!data.GameRunning || !SupportedGame(ref data)) return;
        }
        /// <summary>
        /// Called at plugin manager stop, close/dispose anything needed here !
        /// Plugins are rebuilt at game change
        /// </summary>
        /// <param name="pluginManager"></param>
        public void End(PluginManager pluginManager)
        {
            // Save settings
            this.SaveCommonSettings(nameof(TyreAndBrakeColorSettings), TyreAndBrakeColorSettings);
            this.SaveCommonSettings(nameof(SectorColorSettings),SectorColorSettings);
        }
        /// <summary>
        /// Returns the settings control, return null if no settings control is required
        /// </summary>
        /// <param name="pluginManager"></param>
        /// <returns></returns>
        public System.Windows.Controls.Control GetWPFSettingsControl(PluginManager pluginManager)
        {
            return new Settings.UI.R3EExtraPropertiesUI();
        }
        /// <summary>
        /// Called once after plugins startup
        /// Plugins are rebuilt at game change
        /// </summary>
        /// <param name="pluginManager"></param>
        public void Init(PluginManager pluginManager)
        {            
            SimHub.Logging.Current.Info($"Starting plugin: {this.PluginName}, Version {Version.PluginVersion}");

            // Load settings
            TyreAndBrakeColorSettings = this.ReadCommonSettings(nameof(TyreAndBrakeColorSettings),() => new TyreAndBrakeColorSettings());
            SectorColorSettings = this.ReadCommonSettings(nameof(SectorColorSettings),() => new SectorColorSettings());

            pluginManager.AddProperty<bool>("PluginRunning", this.GetType(), true);
            this._brakes.Init(PluginManager);
            this._tyres.Init(PluginManager);
            this._sectors.Init(PluginManager);
            this._driverData.Init(PluginManager);
            SimHub.Logging.Current.Info("Plugin started");
        }
    }
}
