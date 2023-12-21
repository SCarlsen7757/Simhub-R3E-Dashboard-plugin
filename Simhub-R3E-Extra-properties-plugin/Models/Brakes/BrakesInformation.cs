using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Extra_properties_plugin.Models.Temperature.Brake;

namespace Simhub_R3E_Extra_properties_plugin.Models
{
    public class BrakesInformation : Prefix, ISimhub
    {
        public BrakesInformation()
            : base("Brake")
        {
            Front = new LeftRightSet<Brake>(this._prefix, nameof(Front));
            Rear = new LeftRightSet<Brake>(this._prefix, nameof(Rear));

            _brakeBiasOffset = new BrakeBiasOffset.R3EBrakeBiasOffset(_prefix, "Bias");
        }

        public readonly BrakeBiasOffset.R3EBrakeBiasOffset _brakeBiasOffset;
        public LeftRightSet<Brake> Front { get; private set; }
        public LeftRightSet<Brake> Rear { get; private set; }

        public void Init(PluginManager pluginManager)
        {
            _brakeBiasOffset.Init(pluginManager);
            pluginManager.DataUpdated += PluginManager_DataUpdated;
            Front.AddProperty(pluginManager);
            Rear.AddProperty(pluginManager);
        }

        public void PluginManager_DataUpdated(ref GameData data, PluginManager pluginManager)
        {
            if (!data.GameRunning || !R3EExtraProperties.SupportedGame(data)) return;
            this.CalcOptimalTemperature((R3E.Data.Shared)data.NewData.GetRawDataObject());
            this.UpdateTemperature(data.NewData, pluginManager);
        }

        private void CalcOptimalTemperature(R3E.Data.Shared data)
        {
            this.Front.Left.UpdatedTemperatureSettings(data.BrakeTemp.FrontLeft);
            this.Front.Right.UpdatedTemperatureSettings(data.BrakeTemp.FrontRight);
            this.Rear.Left.UpdatedTemperatureSettings(data.BrakeTemp.RearLeft);
            this.Rear.Right.UpdatedTemperatureSettings(data.BrakeTemp.RearRight);
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
