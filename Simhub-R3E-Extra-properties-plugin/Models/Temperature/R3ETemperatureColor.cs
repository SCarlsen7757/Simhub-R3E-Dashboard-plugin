using Microsoft.VisualStudio.Modeling.Diagrams;
using SimHub.Plugins;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Media;
using static Simhub_R3E_Extra_properties_plugin.Settings.TyreAndBrakeColorSettings;

namespace Simhub_R3E_Extra_properties_plugin.Model
{
    public class R3ETemperatureColor : TemperatureInformation, ITemperatureColor
    {
        public R3ETemperatureColor()
            : base()
        { }
        public R3ETemperatureColor(in List<string> prefixList)
            : base(prefixList) { }
        public R3ETemperatureColor(in List<string> prefixList, string prefix)
            : base(prefixList, prefix) { }

        public void UpdatedTemperatureSettings(double optimalTemperature, double coldTemperature, double hotTemperature)
        {
            this.Optimal = optimalTemperature;
            this.Max = hotTemperature;
            this.Min = coldTemperature;
        }

        public void AddColorProperty(PluginManager pluginManager)
        {
            pluginManager.AddProperty(FullName(ColorSubFix), this.GetType(), new Color() { A = 255, R = 255, G = 255, B = 255 }.ToString());
        }
        public void SetColorProperty(PluginManager pluginManager)
        {
            pluginManager.SetPropertyValue(FullName(ColorSubFix), this.GetType(), TemperatureColor.ToString());
        }
        private static string ColorSubFix { get => "Color"; }
        public Color TemperatureColor { get => ColorConverter(this, R3EExtraProperties.TyreAndBrakeColorSettings.Colors); }

        public static Color ColorConverter(TemperatureInformation temperature, ColorValues colorSettings)
        {
            double hue;
            Vector2 point1 = new Vector2();
            Vector2 point2 = new Vector2();

            switch (temperature.Temperature)
            {
                case double n when n < temperature.Min:
                    hue = colorSettings.Cold.Hue;
                    break;
                case double n when n < temperature.Optimal: //Cold
                    point1.X = (float)temperature.Min;
                    point1.Y = (float)colorSettings.Cold.Hue;
                    point2.X = (float)temperature.Optimal;
                    point2.Y = (float)colorSettings.Optimal.Hue;
                    hue = (int)System.Math.Round(Math.LinearFunction.GetY(point1, point2, temperature.Temperature), System.MidpointRounding.ToEven);
                    break;
                case double n when n > temperature.Optimal && n < temperature.Max://Hot
                    point1.X = (float)temperature.Optimal;
                    point1.Y = (float)colorSettings.Optimal.Hue;
                    point2.X = (float)temperature.Max;
                    point2.Y = (float)colorSettings.Hot.Hue;
                    hue = (int)System.Math.Round(Math.LinearFunction.GetY(point1, point2, temperature.Temperature), System.MidpointRounding.ToEven);
                    break;
                case double n when n >= temperature.Max:
                    hue = colorSettings.Hot.Hue;
                    break;
                default://Optimal
                    hue = colorSettings.Optimal.Hue;
                    break;
            }
            hue = Math.LinearFunction.Scale(hue, 0, 360, 0, 240);
            return new HslColor((int)hue, 240, 120).ToColor();
        }
    }
}
