using System.Collections.Generic;
using System.Numerics;
using ColorHelper;
using SimHub.Plugins;
using Simhub_R3E_Dashboard_plugin.Settings;

namespace Simhub_R3E_Dashboard_plugin.Model
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

            if(settings.Max.Absolute == null )
            {
                this.Max = this.Optimal.Range.Upper + settings.Max.Relative.Value;
            }
            else
            {
                this.Max = settings.Max.Absolute.Value;
            }

            if (settings.Min.Absolute == null)
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
            pluginManager.AddProperty(FullName(ColorSubFix), this.GetType(), "#FFFFFF");
        }
        public void SetColorProperty(PluginManager pluginManager)
        {
            pluginManager.SetPropertyValue(FullName(ColorSubFix), this.GetType(), Color);
        }
        private static string ColorSubFix { get => "Color"; }
        public string Color { get => ColorConverter(); }

        private string ColorConverter()
        {

            HSV hsl = new HSV(0, 100, 100);
            Vector2 point1 = new Vector2();
            Vector2 point2 = new Vector2();

            switch (this.Temperature)
            {
                case double n when n < Min:
                    hsl.H = R3EDashboard.ColorSettings.Hue.Cold;
                    break;
                case double n when n < this.Optimal.Range.Lower: //Cold
                    point1.X = (float)Min;
                    point1.Y = (float)R3EDashboard.ColorSettings.Hue.Cold;
                    point2.X = (float)this.Optimal.Range.Lower;
                    point2.Y = (float)R3EDashboard.ColorSettings.Hue.Optimal;
                    hsl.H = (int)Math.LinearFunction.GetY(point1, point2, this.Temperature);
                    break;
                case double n when n > this.Optimal.Range.Upper && n < Max://Hot
                    point1.X = (float)this.Optimal.Range.Upper;
                    point1.Y = (float)R3EDashboard.ColorSettings.Hue.Optimal;
                    point2.X = (float)Max;
                    point2.Y = (float)R3EDashboard.ColorSettings.Hue.Hot;
                    hsl.H = (int)Math.LinearFunction.GetY(point1, point2, this.Temperature);
                    break;
                case double n when n > Max:
                    hsl.H = R3EDashboard.ColorSettings.Hue.Hot;
                    break;
                default://Optimal
                    hsl.H = R3EDashboard.ColorSettings.Hue.Optimal;
                    break;
            }
            return $"#{ColorHelper.ColorConverter.HsvToHex(hsl)}";
        }
    }



}
