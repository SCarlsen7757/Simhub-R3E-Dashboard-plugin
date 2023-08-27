using SimHub.Plugins;
using System.Collections.Generic;
using System.Windows.Media;

namespace Simhub_R3E_Extra_properties_plugin.Models.Sector
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
            pluginManager.AddProperty(FullName(FontSubfix), this.GetType(), R3EExtraProperties.SectorColorSettings.Sector.Font.NotRun.Color.ToString());
            pluginManager.AddProperty(FullName(BackgroundSubfix), this.GetType(), R3EExtraProperties.SectorColorSettings.Sector.Background.NotRun.Color.ToString());
        }
        public void SetProperty(PluginManager pluginManager)
        {
            pluginManager.SetPropertyValue(FullName(FontSubfix), this.GetType(), Colors.Font.Color.ToString());
            pluginManager.SetPropertyValue(FullName(BackgroundSubfix), this.GetType(), Colors.Background.Color.ToString());
        }

        public class SectorColors
        {
            public SectorColors() { }
            public Models.Color.ExtendedColor Font { get; set; } = new Models.Color.ExtendedColor();
            public Models.Color.ExtendedColor Background { get; set; } = new Models.Color.ExtendedColor();
        }
    }
}
