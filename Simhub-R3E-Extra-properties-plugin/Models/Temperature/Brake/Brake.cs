using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Extra_properties_plugin.Model;
using Simhub_R3E_Extra_properties_plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Extra_properties_plugin.Models.Temperature.Brake
{
    public class Brake : Prefix, ISimhubProperty
    {
        public R3ETemperatureColor ColorTemperature { get; set; }
        public Brake() 
            : base() 
        {
            ColorTemperature = new R3ETemperatureColor();
        }
        public Brake(List<string> prefixList, string prefix) 
            : base(prefixList, prefix)
        {
            ColorTemperature = new R3ETemperatureColor(this._prefix);
        }

        public void AddProperty(PluginManager pluginManager)
        {
            ColorTemperature.AddColorProperty(pluginManager);
        }
        public void SetProperty(PluginManager pluginManager)
        {
            ColorTemperature.SetColorProperty(pluginManager);
        }
        public void UpdatedTemperatureSettings(double optimalTemperature, TyreAndBrakeColorSettings.TemperatureValues settings)
        {
            ColorTemperature.UpdatedTemperatureSettings(optimalTemperature, settings);
        }
    }
}
