using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Dashboard_plugin.Models.Temperature.Tire;

namespace Simhub_R3E_Dashboard_plugin.Models
{
    public class TyresInformation : Prefix, ISimhub
    {
        public TyresInformation()
            : base("Tire")
        {
            this.Front = new LeftRightSet<Tire>(this._prefix, nameof(Front));
            this.Rear = new LeftRightSet<Tire>(this._prefix, nameof(Rear));
        }
        /// <summary>
        /// Instance of the current plugin manager
        /// </summary>
        public PluginManager PluginManager { get; set; }

        private bool _newCar = false;
        private string _carId = string.Empty;
        public void Init(PluginManager pluginManager)
        {
            this.PluginManager = pluginManager;
            this.Front.AddProperty(PluginManager);
            this.Rear.AddProperty(PluginManager);
        }
        public void PluginManager_DataUpdated(ref GameData data, PluginManager manager)
        {
            if (!data.GameRunning || !R3EDashboard.SupportedGame(data)) return;
            this.Update(data.NewData);
        }

        public LeftRightSet<Tire> Front { get; set; }
        public LeftRightSet<Tire> Rear { get; set; }

        private void CalcOptimalTemperature(object rawData)
        {
            if (!(rawData is R3E.Data.Shared)) return;
            this._newCar = false;
            R3E.Data.Shared data = (R3E.Data.Shared)rawData;

            this.Front.Left.UpdatedTemperatureSettings(data.TireTemp.FrontLeft.OptimalTemp, R3EDashboard.ColorSettings.TyresTemperature);
            this.Front.Right.UpdatedTemperatureSettings(data.TireTemp.FrontRight.OptimalTemp, R3EDashboard.ColorSettings.TyresTemperature);
            this.Rear.Left.UpdatedTemperatureSettings(data.TireTemp.RearLeft.OptimalTemp, R3EDashboard.ColorSettings.TyresTemperature);
            this.Rear.Right.UpdatedTemperatureSettings(data.TireTemp.RearRight.OptimalTemp, R3EDashboard.ColorSettings.TyresTemperature);
        }

        public void Update(StatusDataBase data)
        {
            if (data.CarId != this._carId)
            {
                this._carId = data.CarId;
                this._newCar = true;
            }
            if (this._newCar) this.CalcOptimalTemperature(data.GetRawDataObject());
            this.UpdateTemperature(data);
        }
        private void UpdateTemperature(StatusDataBase data)
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
