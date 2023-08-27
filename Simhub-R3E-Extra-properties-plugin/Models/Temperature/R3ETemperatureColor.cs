using System.Collections.Generic;
using System.Numerics;
using SimHub.Plugins;
using Simhub_R3E_Extra_properties_plugin.Settings;
using Microsoft.VisualStudio.Modeling.Diagrams;
using static Simhub_R3E_Extra_properties_plugin.Settings.TyreAndBrakeColorSettings;
using System.Windows.Media;

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
        public void UpdatedTemperatureSettings(double optimalTemperature, TyreAndBrakeColorSettings.TemperatureValues settings)
        {
            this.Optimal.Value = optimalTemperature;
            this.Optimal.Range.Upper = optimalTemperature + settings.Range.Upper;
            this.Optimal.Range.Lower = optimalTemperature - settings.Range.Lower;

            this.Max = this.Optimal.Range.Upper + settings.Max;
            this.Min = this.Optimal.Range.Lower - settings.Min;
        }
        public void AddColorProperty(PluginManager pluginManager)
        {
            pluginManager.AddProperty(FullName(ColorSubFix), this.GetType(), new Color().ToString());
        }
        public void SetColorProperty(PluginManager pluginManager)
        {
            pluginManager.SetPropertyValue(FullName(ColorSubFix), this.GetType(), TemperatureColor.ToString());
        }
        private static string ColorSubFix { get => "Color"; }
        public Color TemperatureColor { get => ColorConverter(this.Temperature, this.Optimal, this.Min, this.Max, R3EExtraProperties.TyreAndBrakeColorSettings.Colors); }

        public static Color ColorConverter(double temperature, Optimal optimal, double min, double max, ColorValues colorSettings)
        {
            double hue;
            Vector2 point1 = new Vector2();
            Vector2 point2 = new Vector2();

            switch (temperature)
            {
                case double n when n < min:
                    hue = colorSettings.Cold.Hue;
                    break;
                case double n when n < optimal.Range.Lower: //Cold
                    point1.X = (float)min;
                    point1.Y = (float)colorSettings.Cold.Hue;
                    point2.X = (float)optimal.Range.Lower;
                    point2.Y = (float)colorSettings.Optimal.Hue;
                    hue = (int)System.Math.Round(Math.LinearFunction.GetY(point1, point2, temperature), System.MidpointRounding.ToEven);
                    break;
                case double n when n > optimal.Range.Upper && n < max://Hot
                    point1.X = (float)optimal.Range.Upper;
                    point1.Y = (float)colorSettings.Optimal.Hue;
                    point2.X = (float)max;
                    point2.Y = (float)colorSettings.Hot.Hue;
                    hue = (int)System.Math.Round(Math.LinearFunction.GetY(point1, point2, temperature), System.MidpointRounding.ToEven);
                    break;
                case double n when n >= max:
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
