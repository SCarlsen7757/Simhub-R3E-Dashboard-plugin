using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Tyre_and_brake_color_plugin.Model;
using Simhub_R3E_Tyre_and_brake_color_plugin.Models;
using System;

namespace Simhub_R3E_Tyre_and_brake_color_plugin
{
    [PluginDescription("Convert tyre and brake temperature to a HEX color.")]
    [PluginAuthor("Mark Carlsen")]
    [PluginName("R3E Tyre and brake color")]
    public class R3ETyreAndBrakeColor : IPlugin, IDataPlugin
    {
        public R3ETyreAndBrakeColor() { }

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
            //Brakes
            pluginManager.AddProperty<string>("FrontLeftBrakeColor", this.GetType(), this._brakes.Front.Left.Color);
            pluginManager.AddProperty<string>("FrontRightBrakeColor", this.GetType(), this._brakes.Front.Right.Color);
            pluginManager.AddProperty<string>("RearLeftBrakeColor", this.GetType(), this._brakes.Rear.Left.Color);
            pluginManager.AddProperty<string>("RearRightBrakeColor", this.GetType(), this._brakes.Rear.Right.Color);
            //Tyres
            pluginManager.AddProperty<string>("FrontLeftTyreOuterColor", this.GetType(), this._tyres.Front.Left.Outer.Color);
            pluginManager.AddProperty<string>("FrontLeftTyreMiddleColor", this.GetType(), this._tyres.Front.Left.Middle.Color);
            pluginManager.AddProperty<string>("FrontLeftTyreInnerColor", this.GetType(), this._tyres.Front.Left.Inner.Color);

            pluginManager.AddProperty<string>("FrontRightTyreOuterColor", this.GetType(), this._tyres.Front.Right.Outer.Color);
            pluginManager.AddProperty<string>("FrontRightTyreMiddleColor", this.GetType(), this._tyres.Front.Right.Middle.Color);
            pluginManager.AddProperty<string>("FrontRightTyreInnerColor", this.GetType(), this._tyres.Front.Right.Inner.Color);

            pluginManager.AddProperty<string>("RearLeftTyreOuterColor", this.GetType(), this._tyres.Rear.Left.Outer.Color);
            pluginManager.AddProperty<string>("RearLeftTyreMiddleColor", this.GetType(), this._tyres.Rear.Left.Middle.Color);
            pluginManager.AddProperty<string>("RearLeftTyreInnerColor", this.GetType(), this._tyres.Rear.Left.Inner.Color);

            pluginManager.AddProperty<string>("RearRightTyreOuterColor", this.GetType(), this._tyres.Rear.Right.Outer.Color);
            pluginManager.AddProperty<string>("RearRightTyreMiddleColor", this.GetType(), this._tyres.Rear.Right.Middle.Color);
            pluginManager.AddProperty<string>("RearRightTyreInnerColor", this.GetType(), this._tyres.Rear.Right.Inner.Color);
        }
    }
}
