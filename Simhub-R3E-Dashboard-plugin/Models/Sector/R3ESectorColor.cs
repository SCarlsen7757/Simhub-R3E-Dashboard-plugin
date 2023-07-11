using SimHub.Plugins;
using Simhub_R3E_Dashboard_plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Dashboard_plugin.Models.Sector
{
    public class R3ESectorColor : Prefix, ISimhubProperty
    {
        public R3ESectorColor() : base() { }

        public R3ESectorColor(string prefix) : base(prefix) { }
        public R3ESectorColor(List<string> prefixList) : base(prefixList) { }
        private static string ColorSubFix { get => "Color"; }

        public void AddProperty(PluginManager pluginManager)
        {
            
        }
        public void SetProperty(PluginManager pluginManager) { }
    }
}
