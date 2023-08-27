using Simhub_R3E_Extra_properties_plugin.Model;
using System.Windows.Media;

namespace Simhub_R3E_Extra_properties_plugin.Settings
{
    public class TyreAndBrakeColorSettings
    {
        public TyreAndBrakeColorSettings() { }
        public ColorValues Colors { get; set; } = new ColorValues();
        public TemperatureValues BrakesTemperature { get; set; } = new TemperatureValues(300, 300, 100, 100);
        public TemperatureValues TyresTemperature { get; set; } = new TemperatureValues(30, 30, 5, 5);

        public class ColorValues
        {
            public ColorValues() { }
            public Models.Color.ExtendedColor Cold { get; set; } = new Models.Color.ExtendedColor() { Color = new Color() {A = 255, R = 0, G = 255, B = 255 } }; //Light blue
            public Models.Color.ExtendedColor Optimal { get; set; } = new Models.Color.ExtendedColor() { Color = new Color() {A = 255, R = 0, G = 255, B = 0 } }; //Green
            public Models.Color.ExtendedColor Hot { get; set; } = new Models.Color.ExtendedColor() { Color = new Color() {A = 255, R = 255, G = 0, B = 0 } }; //Red
        }
        
        public class TemperatureValues
        {
            public TemperatureValues() { }
            public TemperatureValues(double min, double max, Range range)
            {
                Min = min;
                Max = max;
                Range = range;
            }
            public TemperatureValues(double min, double max, double rangeLower, double rangeUpper)
            {
                Min = min;
                Max = max;
                Range = new Range(rangeLower, rangeUpper);
            }

            public double Min { get; set; }
            public double Max { get; set; }
            public Range Range { get; set; } = new Range();

        }
    }
}
