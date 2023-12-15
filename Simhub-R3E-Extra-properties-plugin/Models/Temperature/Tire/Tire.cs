using R3E.Data;
using SimHub.Plugins;
using System.Collections.Generic;

namespace Simhub_R3E_Extra_properties_plugin.Models.Temperature.Tire
{
    public class Tire : Prefix, ISimhubProperty
    {
        public OMITemperatureInformation ColorOMITemperature { get; set; }
        public Tire()
            : base()
        {
            ColorOMITemperature = new OMITemperatureInformation();
        }

        public Tire(List<string> prefixList, string prefix)
            : base(prefixList, prefix)
        {
            ColorOMITemperature = new OMITemperatureInformation(this._prefix);
        }
        public void AddProperty(PluginManager pluginManager)
        {
            ColorOMITemperature.AddProperty(pluginManager);
        }
        public void SetProperty(PluginManager pluginManager)
        {
            ColorOMITemperature.SetProperty(pluginManager);
        }
        public void UpdatedTemperatureSettings(TireTempInformation temps)
        {
            ColorOMITemperature.Outer.UpdatedTemperatureSettings(temps.OptimalTemp, temps.ColdTemp, temps.HotTemp);
            ColorOMITemperature.Middle.UpdatedTemperatureSettings(temps.OptimalTemp, temps.ColdTemp, temps.HotTemp);
            ColorOMITemperature.Inner.UpdatedTemperatureSettings(temps.OptimalTemp, temps.ColdTemp, temps.HotTemp);
        }
    }
}
