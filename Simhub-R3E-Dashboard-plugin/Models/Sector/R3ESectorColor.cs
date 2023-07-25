using ColorHelper;
using SimHub.Plugins;
using Simhub_R3E_Dashboard_plugin.Extensions.ColorHelper;
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

        public SectorColors Colors { get; set; } = new SectorColors();
        public R3ESectorColor(string prefix) : base(prefix) { }
        public R3ESectorColor(List<string> prefixList) : base(prefixList) { }
        private static string ColorSubFix { get => "Color"; }
        private List<string> FontSubfix { get => new List<string> { "Font", ColorSubFix }; }
        private List<string> BackgroundSubfix { get => new List<string> { "Background", ColorSubFix }; }
        public void AddProperty(PluginManager pluginManager)
        {
            pluginManager.AddProperty(FullName(FontSubfix), this.GetType(), R3EDashboard.SectorColorSettings.Sector.Font.NotRun.ToHEX().ToColorString());
            pluginManager.AddProperty(FullName(BackgroundSubfix), this.GetType(), R3EDashboard.SectorColorSettings.Sector.Background.NotRun.ToHEX().ToColorString());
        }
        public void SetProperty(PluginManager pluginManager)
        {
            pluginManager.SetPropertyValue(FullName(FontSubfix), this.GetType(), Colors.Font.ToColorString());
            pluginManager.SetPropertyValue(FullName(BackgroundSubfix), this.GetType(), Colors.Background.ToColorString());
        }

        public class SectorColors
        {
            public SectorColors() { }
            public HEX Font { get; set; } = new HEX("FFFFFF");
            public HEX Background { get; set; } = new HEX("FFFFFF");
        }
    }
}
