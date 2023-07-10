using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Dashboard_plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Dashboard_plugin.Models.Temperature.Tire
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
            ColorOMITemperature = new OMITemperatureInformation(this._prefix.ToList());
        }
        public void AddProperty(PluginManager pluginManager)
        {
            ColorOMITemperature.AddProperty(pluginManager);
        }
        public void SetProperty(PluginManager pluginManager)
        {
            ColorOMITemperature.SetProperty(pluginManager);
        }
        public void UpdatedTemperatureSettings(double optimalTemperature, OptimalTemperatureColorSettings.TemperatureValues settings)
        {
            ColorOMITemperature.Outer.UpdatedTemperatureSettings(optimalTemperature, settings);
            ColorOMITemperature.Middle.UpdatedTemperatureSettings(optimalTemperature, settings);
            ColorOMITemperature.Inner.UpdatedTemperatureSettings(optimalTemperature, settings);
        }
    }
}
