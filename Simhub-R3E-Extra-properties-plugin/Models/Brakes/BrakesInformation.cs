using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Extra_properties_plugin.Models.Temperature.Brake;
using System.Runtime.CompilerServices;

namespace Simhub_R3E_Extra_properties_plugin.Models
{
    public class BrakesInformation : Prefix, ISimhub
    {
        public BrakesInformation()
            : base("Brake")
        {
            Front = new LeftRightSet<Brake>(this._prefix, nameof(Front));
            Rear = new LeftRightSet<Brake>(this._prefix, nameof(Rear));
        }
        public LeftRightSet<Brake> Front { get; set; }
        public LeftRightSet<Brake> Rear { get; set; }

        private bool _newCar = false;
        private string _carId = string.Empty;
        public void Init(PluginManager pluginManager)
        {
            pluginManager.DataUpdated += PluginManager_DataUpdated;
            Front.AddProperty(pluginManager);
            Rear.AddProperty(pluginManager);
        }

        public void PluginManager_DataUpdated(ref GameData data, PluginManager manager)
        {
            if (!data.GameRunning || !R3EExtraProperties.SupportedGame(data)) return;
            this.Update(data.NewData, manager);
        }

        private void CalcOptimalTemperature(object rawData)
        {
            if (!(rawData is R3E.Data.Shared)) return;
            this._newCar = false;
            R3E.Data.Shared data = (R3E.Data.Shared)rawData;

            this.Front.Left.UpdatedTemperatureSettings(data.BrakeTemp.FrontLeft.OptimalTemp, R3EExtraProperties.TyreAndBrakeColorSettings.BrakesTemperature);
            this.Front.Right.UpdatedTemperatureSettings(data.BrakeTemp.FrontRight.OptimalTemp, R3EExtraProperties.TyreAndBrakeColorSettings.BrakesTemperature);
            this.Rear.Left.UpdatedTemperatureSettings(data.BrakeTemp.RearLeft.OptimalTemp, R3EExtraProperties.TyreAndBrakeColorSettings.BrakesTemperature);
            this.Rear.Right.UpdatedTemperatureSettings(data.BrakeTemp.RearRight.OptimalTemp, R3EExtraProperties.TyreAndBrakeColorSettings.BrakesTemperature);
        }

        private void Update(StatusDataBase data, PluginManager pluginManager)
        {
            if (data.CarId != this._carId)
            {
                this._carId = data.CarId;
                this._newCar = true;
            }
            if (this._newCar) this.CalcOptimalTemperature(data.GetRawDataObject());
            this.UpdateTemperature(data, pluginManager);
        }
        private void UpdateTemperature(StatusDataBase data, PluginManager pluginManager)
        {
            Front.Left.ColorTemperature.Temperature = data.BrakeTemperatureFrontLeft;
            Front.Right.ColorTemperature.Temperature = data.BrakeTemperatureFrontRight;
            Rear.Left.ColorTemperature.Temperature = data.BrakeTemperatureRearLeft;
            Rear.Right.ColorTemperature.Temperature = data.BrakeTemperatureRearRight;

            this.Front.SetProperty(pluginManager);
            this.Rear.SetProperty(pluginManager);
        }
    }


}
