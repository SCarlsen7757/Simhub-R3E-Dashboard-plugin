using System.Numerics;
using ColorHelper;

namespace Simhub_R3E_Tyre_and_brake_color_plugin.Model
{
    public class ComponentTemperatureInformation : TemperatureInformation, ITemperatureColor
    {
        private static double GetY(Vector2 point1, Vector2 point2, double x)
        {
            var dx = point2.X - point1.X; 
            if (dx == 0)
                return double.NaN;
            var m = (point2.Y - point1.Y) / dx;
            var b = point1.Y - (m * point1.X);

            return (m * x) + b;
        }

        public ComponentTemperatureInformation()
        {
        }
        public double Temperature { get; set; }

        public string color = string.Empty;
        public string Color { get => ColorConverter(); }

        private string ColorConverter()
        {
            double otl = this.Optimal.Value - this.Optimal.Range.Lower;
            double oth = this.Optimal.Value + this.Optimal.Range.Upper;

            double hue;
            Vector2 point1 = new Vector2();
            Vector2 point2 = new Vector2();

            switch (this.Temperature)
            {
                case double n when n < Min:
                    hue = R3ETyreAndBrakeColor.ColorSettings.Hue.Cold;
                    break;
                case double n when n < otl: //Cold
                    point1.X = (float)Min;
                    point1.Y = (float)R3ETyreAndBrakeColor.ColorSettings.Hue.Cold;
                    point2.X = (float)otl;
                    point2.Y = (float)R3ETyreAndBrakeColor.ColorSettings.Hue.Optimal;
                    hue = GetY(point1, point2, this.Temperature);
                    break;
                case double n when n > oth && n < Max://Hot
                    point1.X = (float)oth;
                    point1.Y = (float)R3ETyreAndBrakeColor.ColorSettings.Hue.Optimal;
                    point2.X = (float)Max;
                    point2.Y = (float)R3ETyreAndBrakeColor.ColorSettings.Hue.Hot;
                    hue = GetY(point1, point2, this.Temperature);
                    break;
                case double n when n > Max:
                    hue = R3ETyreAndBrakeColor.ColorSettings.Hue.Hot;
                    break;
                default://Optimal
                    hue = R3ETyreAndBrakeColor.ColorSettings.Hue.Optimal;
                    break;
            }
            HSV hsl = new HSV((int)hue, 100, 100);
            var test2 = ColorHelper.ColorConverter.HsvToHex(hsl);
            
            return $"#{ColorHelper.ColorConverter.HsvToHex(hsl)}";
        }
    }



}
