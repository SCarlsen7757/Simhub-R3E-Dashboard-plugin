using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Dashboard_plugin.Models.Temperature.Brake;

namespace Simhub_R3E_Dashboard_plugin.Models
{
    public class BrakesInformation : Prefix
    {
        public BrakesInformation()
            : base("Brake")
        {
            Front = new LeftRightSet<Brake>(this._prefix, nameof(Front));
            Rear = new LeftRightSet<Brake>(this._prefix, nameof(Rear));
        }
        public LeftRightSet<Brake> Front { get; set; }
        public LeftRightSet<Brake> Rear { get; set; }
        /// <summary>
        /// Instance of the current plugin manager
        /// </summary>
        public PluginManager PluginManager { get; set; } = null;

        private string _carId = string.Empty;
        public void Init(PluginManager pluginManager)
        {
            this.PluginManager = pluginManager;
            Front.AddProperty(pluginManager);
            Rear.AddProperty(pluginManager);
        }
        public void Update(StatusDataBase data)
        {
            if (data.CarId != this._carId)
            {
                this._carId = data.CarId;
                R3E.Data.Shared rawR3EData = (R3E.Data.Shared)data.GetRawDataObject();

                this.Front.Left.UpdatedTemperatureSettings(rawR3EData.BrakeTemp.FrontLeft.OptimalTemp, R3EDashboard.ColorSettings.BrakesTemperature);
                this.Front.Right.UpdatedTemperatureSettings(rawR3EData.BrakeTemp.FrontRight.OptimalTemp, R3EDashboard.ColorSettings.BrakesTemperature);
                this.Rear.Left.UpdatedTemperatureSettings(rawR3EData.BrakeTemp.RearLeft.OptimalTemp, R3EDashboard.ColorSettings.BrakesTemperature);
                this.Rear.Right.UpdatedTemperatureSettings(rawR3EData.BrakeTemp.RearRight.OptimalTemp, R3EDashboard.ColorSettings.BrakesTemperature);
            }
            this.UpdateTemperature(data);
        }
        public void UpdateTemperature(StatusDataBase data)
        {
            if (this.PluginManager == null) return;

            Front.Left.ColorTemperature.Temperature = data.BrakeTemperatureFrontLeft;
            Front.Right.ColorTemperature.Temperature = data.BrakeTemperatureFrontRight;
            Rear.Left.ColorTemperature.Temperature = data.BrakeTemperatureRearLeft;
            Rear.Right.ColorTemperature.Temperature = data.BrakeTemperatureRearRight;

            this.Front.SetProperty(PluginManager);
            this.Rear.SetProperty(PluginManager);
        }
    }


}
