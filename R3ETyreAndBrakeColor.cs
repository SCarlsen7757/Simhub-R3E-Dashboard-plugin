using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Tyre_and_brake_color_plugin.Model;
using Simhub_R3E_Tyre_and_brake_color_plugin.Models;
using Simhub_R3E_Tyre_and_brake_color_plugin.Settings;
using System;

namespace Simhub_R3E_Tyre_and_brake_color_plugin
{
    [PluginDescription("Convert tyre and brake temperature to a HEX color.")]
    [PluginAuthor("Mark Carlsen")]
    [PluginName("R3E Tyre and brake color")]
    public class R3ETyreAndBrakeColor : IPlugin, IDataPlugin
    {
        public R3ETyreAndBrakeColor() { }

        public static ColorSettings ColorSettings { get; set; } = new ColorSettings();
        private readonly string _supportedGameName = "RRRE";
        private readonly TyresInformation _tyres = new TyresInformation();
        private readonly BrakesInformation _brakes = new BrakesInformation();

        private string _carId;

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
                if (data.NewData.CarId != this._carId)
                {
                    this._carId = data.NewData.CarId;

                    var optimalBrakeTemp = (double)pluginManager.GetPropertyValue("DataCorePlugin.GameRawData.BrakeTemp.FrontLeft.OptimalTemp");
                    var optimalTyreTemp = (double)pluginManager.GetPropertyValue("DataCorePlugin.GameRawData.TireTemp.FrontLeft.OptimalTemp");
                    
                    this._brakes.OptimalTemperature = optimalBrakeTemp;
                    this._tyres.OptimalTemperature = optimalTyreTemp;

                    this._brakes.Max = optimalBrakeTemp + 300;
                    this._tyres.Max = optimalTyreTemp + 30;

                    this._brakes.Min = optimalBrakeTemp - 300;
                    this._tyres.Min = optimalTyreTemp - 30;
                }

                this._brakes.SetTemperature(data.NewData);
                this._tyres.SetTemperature(data.NewData);

                //Brakes
                pluginManager.SetPropertyValue("BrakeColorFrontLeft", this.GetType(), this._brakes.Front.Left.Color);
                pluginManager.SetPropertyValue("BrakeColorFrontRight", this.GetType(), this._brakes.Front.Right.Color);
                pluginManager.SetPropertyValue("BrakeColorRearLeft", this.GetType(), this._brakes.Rear.Left.Color);
                pluginManager.SetPropertyValue("BrakeColorRearRight", this.GetType(), this._brakes.Rear.Right.Color);
                //Tyres
                pluginManager.SetPropertyValue("TyreColorFrontLeftOuter", this.GetType(), this._tyres.Front.Left.Outer.Color);
                pluginManager.SetPropertyValue("TyreColorFrontLeftMiddle", this.GetType(), this._tyres.Front.Left.Middle.Color);
                pluginManager.SetPropertyValue("TyreColorFrontLeftInner", this.GetType(), this._tyres.Front.Left.Inner.Color);

                pluginManager.SetPropertyValue("TyreColorFrontRightOuter", this.GetType(), this._tyres.Front.Right.Outer.Color);
                pluginManager.SetPropertyValue("TyreColorFrontRightMiddle", this.GetType(), this._tyres.Front.Right.Middle.Color);
                pluginManager.SetPropertyValue("TyreColorFrontRightInner", this.GetType(), this._tyres.Front.Right.Inner.Color);

                pluginManager.SetPropertyValue("TyreColorRearLeftOuter", this.GetType(), this._tyres.Rear.Left.Outer.Color);
                pluginManager.SetPropertyValue("TyreColorRearLeftMiddle", this.GetType(), this._tyres.Rear.Left.Middle.Color);
                pluginManager.SetPropertyValue("TyreColorRearLeftInner", this.GetType(), this._tyres.Rear.Left.Inner.Color);

                pluginManager.SetPropertyValue("TyreColorRearRightOuter", this.GetType(), this._tyres.Rear.Right.Outer.Color);
                pluginManager.SetPropertyValue("TyreColorRearRightMiddle", this.GetType(), this._tyres.Rear.Right.Middle.Color);
                pluginManager.SetPropertyValue("TyreColorRearRightInner", this.GetType(), this._tyres.Rear.Right.Inner.Color);
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

            this._brakes.Min = 100;
            this._brakes.Max = 1000;
            this._brakes.OptimalTemperature = 550;
            this._brakes.OptimalRange = new Range(50, 50);

            this._tyres.Min = 60;
            this._tyres.Max = 100;
            this._tyres.OptimalTemperature = 85;
            this._tyres.OptimalRange = new Range(5, 5);

            pluginManager.AddProperty<bool>("PluginRunning", this.GetType(), true);
            //Brakes
            pluginManager.AddProperty("BrakeColorFrontLeft", this.GetType(), "#FFFFFF");
            pluginManager.AddProperty("BrakeColorFrontRight", this.GetType(), "#FFFFFF");
            pluginManager.AddProperty("BrakeColorRearLeft", this.GetType(), "#FFFFFF");
            pluginManager.AddProperty("BrakeColorRearRight", this.GetType(), "#FFFFFF");
            //Tyres
            pluginManager.AddProperty("TyreColorFrontLeftOuter", this.GetType(), "#FFFFFF");
            pluginManager.AddProperty("TyreColorFrontLeftMiddle", this.GetType(), "#FFFFFF");
            pluginManager.AddProperty("TyreColorFrontLeftInner", this.GetType(), "#FFFFFF");

            pluginManager.AddProperty("TyreColorFrontRightOuter", this.GetType(), "#FFFFFF");
            pluginManager.AddProperty("TyreColorFrontRightMiddle", this.GetType(), "#FFFFFF");
            pluginManager.AddProperty("TyreColorFrontRightInner", this.GetType(), "#FFFFFF");

            pluginManager.AddProperty("TyreColorRearLeftOuter", this.GetType(), "#FFFFFF");
            pluginManager.AddProperty("TyreColorRearLeftMiddle", this.GetType(), "#FFFFFF");
            pluginManager.AddProperty("TyreColorRearLeftInner", this.GetType(), "#FFFFFF");

            pluginManager.AddProperty("TyreColorRearRightOuter", this.GetType(), "#FFFFFF");
            pluginManager.AddProperty("TyreColorRearRightMiddle", this.GetType(), "#FFFFFF");
            pluginManager.AddProperty("TyreColorRearRightInner", this.GetType(), "#FFFFFF");

            SimHub.Logging.Current.Info("Plugin started");
        }
    }
}
