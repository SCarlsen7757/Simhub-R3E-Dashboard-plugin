using System.Collections.Generic;
using System.Numerics;
using ColorHelper;
using SimHub.Plugins;
using Simhub_R3E_Extra_properties_plugin.Extensions.ColorHelper;
using Simhub_R3E_Extra_properties_plugin.Settings;
using static Simhub_R3E_Extra_properties_plugin.Settings.OptimalTemperatureColorSettings;

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
        public void UpdatedTemperatureSettings(double optimalTemperature, OptimalTemperatureColorSettings.TemperatureValues settings)
        {
            this.Optimal.Value = optimalTemperature;
            this.Optimal.Range.Upper = optimalTemperature + settings.Range.Upper;
            this.Optimal.Range.Lower = optimalTemperature - settings.Range.Lower;
            
            if (settings.Max.Absolute is null)
            {
                this.Max = this.Optimal.Range.Upper + settings.Max.Relative.Value;
            }
            else
            {
                this.Max = settings.Max.Absolute.Value;
            }

            if (settings.Min.Absolute is null)
            {
                this.Min = this.Optimal.Range.Lower - settings.Min.Relative.Value;
            }
            else
            {
                this.Min = settings.Min.Absolute.Value;
            }
        }
        public void AddColorProperty(PluginManager pluginManager)
        {
            pluginManager.AddProperty(FullName(ColorSubFix), this.GetType(), new HEX("FFFFFF").ToColorString());
        }
        public void SetColorProperty(PluginManager pluginManager)
        {
            pluginManager.SetPropertyValue(FullName(ColorSubFix), this.GetType(), Color.ToColorString());
        }
        private static string ColorSubFix { get => "Color"; }
        public HEX Color { get => ColorConverter(this.Temperature, this.Optimal, this.Min, this.Max, R3EExtraProperties.ColorSettings.Hue); }

        public static HEX ColorConverter(double temperature, Optimal optimal, double min, double max, HueValues hueColorSettings)
        {
            HSV hsl = new HSV(0, 100, 100);
            Vector2 point1 = new Vector2();
            Vector2 point2 = new Vector2();

            switch (temperature)
            {
                case double n when n < min:
                    hsl.H = hueColorSettings.Cold;
                    break;
                case double n when n < optimal.Range.Lower: //Cold
                    point1.X = (float)min;
                    point1.Y = (float)hueColorSettings.Cold;
                    point2.X = (float)optimal.Range.Lower;
                    point2.Y = (float)hueColorSettings.Optimal;
                    hsl.H = (int)System.Math.Round(Math.LinearFunction.GetY(point1, point2, temperature),System.MidpointRounding.ToEven);
                    break;
                case double n when n > optimal.Range.Upper && n < max://Hot
                    point1.X = (float)optimal.Range.Upper;
                    point1.Y = (float)hueColorSettings.Optimal;
                    point2.X = (float)max;
                    point2.Y = (float)hueColorSettings.Hot;
                    hsl.H = (int)System.Math.Round(Math.LinearFunction.GetY(point1, point2, temperature),System.MidpointRounding.ToEven);
                    break;
                case double n when n >= max:
                    hsl.H = hueColorSettings.Hot;
                    break;
                default://Optimal
                    hsl.H = hueColorSettings.Optimal;
                    break;
            }
            return hsl.ToHEX();
        }
    }



}
