using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Dashboard_plugin.Models.Temperature.Tire;

namespace Simhub_R3E_Dashboard_plugin.Models
{
    public class TyresInformation : Prefix
    {
        public TyresInformation()
            : base("Tire")
        {
            this.Front   = new LeftRightSet<Tire>(this._prefix, nameof(Front));
            this.Rear = new LeftRightSet<Tire>(this._prefix, nameof(Rear));
        }
        /// <summary>
        /// Instance of the current plugin manager
        /// </summary>
        public PluginManager PluginManager { get; set; }

        private string _carId = string.Empty;
        public void Init(PluginManager pluginManager)
        {
            this.PluginManager = pluginManager;
            this.Front.AddProperty(PluginManager);
            this.Rear.AddProperty(PluginManager);
        }
        public LeftRightSet<Tire> Front { get; set; }
        public LeftRightSet<Tire> Rear { get; set; }
        public void Update(StatusDataBase data)
        {
            if(data.CarId != this._carId)
            {
                this._carId = data.CarId;
                R3E.Data.Shared rawR3EData = (R3E.Data.Shared)data.GetRawDataObject();

                this.Front.Left.UpdatedTemperatureSettings(rawR3EData.TireTemp.FrontLeft.OptimalTemp, R3EDashboard.ColorSettings.TyresTemperature);
                this.Front.Right.UpdatedTemperatureSettings(rawR3EData.TireTemp.FrontRight.OptimalTemp, R3EDashboard.ColorSettings.TyresTemperature);
                this.Rear.Left.UpdatedTemperatureSettings(rawR3EData.TireTemp.RearLeft.OptimalTemp, R3EDashboard.ColorSettings.TyresTemperature);
                this.Rear.Right.UpdatedTemperatureSettings(rawR3EData.TireTemp.RearRight.OptimalTemp, R3EDashboard.ColorSettings.TyresTemperature);
            }
            this.UpdateTemperature(data);
        }
        public void UpdateTemperature(StatusDataBase data)
        {
            if (this.PluginManager == null) return;

            Front.Left.ColorOMITemperature.Outer.Temperature = data.TyreTemperatureFrontLeftOuter;
            Front.Left.ColorOMITemperature.Middle.Temperature = data.TyreTemperatureFrontLeftMiddle;
            Front.Left.ColorOMITemperature.Inner.Temperature = data.TyreTemperatureFrontLeftInner;

            Front.Right.ColorOMITemperature.Outer.Temperature = data.TyreTemperatureFrontRightOuter;
            Front.Right.ColorOMITemperature.Middle.Temperature = data.TyreTemperatureFrontRightMiddle;
            Front.Right.ColorOMITemperature.Inner.Temperature = data.TyreTemperatureFrontRightInner;

            Rear.Left.ColorOMITemperature.Outer.Temperature = data.TyreTemperatureRearLeftOuter;
            Rear.Left.ColorOMITemperature.Middle.Temperature = data.TyreTemperatureRearLeftMiddle;
            Rear.Left.ColorOMITemperature.Inner.Temperature = data.TyreTemperatureRearLeftInner;

            Rear.Right.ColorOMITemperature.Outer.Temperature = data.TyreTemperatureRearRightOuter;
            Rear.Right.ColorOMITemperature.Middle.Temperature = data.TyreTemperatureRearRightMiddle;
            Rear.Right.ColorOMITemperature.Inner.Temperature = data.TyreTemperatureRearRightInner;

            this.Front.SetProperty(PluginManager);
            this.Rear.SetProperty(PluginManager);
        }
    }
}
