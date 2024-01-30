using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Extra_properties_plugin.Models.Temperature.Tire;
using System.Windows.Markup;

namespace Simhub_R3E_Extra_properties_plugin.Models
{
    public class TyresInformation : Prefix, ISimhub
    {
        public TyresInformation()
            : base("Tire")
        {
            this.Front = new LeftRightSet<Tire>(this._prefix, nameof(Front));
            this.Rear = new LeftRightSet<Tire>(this._prefix, nameof(Rear));
        }

        public void Init(PluginManager pluginManager)
        {
            pluginManager.DataUpdated += PluginManager_DataUpdated;
            this.Front.AddProperty(pluginManager);
            this.Rear.AddProperty(pluginManager);
        }
        public void PluginManager_DataUpdated(ref GameData data, PluginManager pluginManager)
        {
            if (!data.GameRunning || !R3EExtraProperties.SupportedGame(data)) return;
            this.CalcOptimalTemperature((R3E.Data.Shared)data.NewData.GetRawDataObject());
            this.UpdateTemperature(data.NewData, pluginManager);
            this.UpdateAge(ref data, pluginManager);
        }

        public LeftRightSet<Tire> Front { get; set; }
        public LeftRightSet<Tire> Rear { get; set; }

        private void CalcOptimalTemperature(R3E.Data.Shared data)
        {
            this.Front.Left.UpdatedTemperatureSettings(data.TireTemp.FrontLeft);
            this.Front.Right.UpdatedTemperatureSettings(data.TireTemp.FrontRight);
            this.Rear.Left.UpdatedTemperatureSettings(data.TireTemp.RearLeft);
            this.Rear.Right.UpdatedTemperatureSettings(data.TireTemp.RearRight);
        }

        private void UpdateTemperature(StatusDataBase data, PluginManager pluginManager)
        {
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

            this.Front.SetProperty(pluginManager);
            this.Rear.SetProperty(pluginManager);
        }
        private void UpdateAge(ref GameData data, PluginManager pluginManager)
        {
            if(data.NewData == null) return;
            Front.Right.Age.UpdateData(ref data, pluginManager, data.OldData?.TyreWearFrontRight, data.NewData.TyreWearFrontRight);
            Front.Left.Age.UpdateData(ref data, pluginManager, data.OldData?.TyreWearFrontLeft, data.NewData.TyreWearFrontLeft);
            Rear.Right.Age.UpdateData(ref data, pluginManager, data.OldData?.TyreWearRearRight, data.NewData.TyreWearRearRight);
            Rear.Left.Age.UpdateData(ref data, pluginManager, data.OldData?.TyreWearRearLeft, data.NewData.TyreWearRearLeft);
        }
    }
}
