using System.Windows.Media;

namespace Simhub_R3E_Extra_properties_plugin.Settings
{
    public class TyreAndBrakeColorSettings
    {
        public TyreAndBrakeColorSettings() { }
        public ColorValues Colors { get; set; } = new ColorValues();

        public class ColorValues
        {
            public ColorValues() { }
            public Models.Color.ExtendedColor Cold { get; set; } = new Models.Color.ExtendedColor() { Color = new Color() {A = 255, R = 0, G = 255, B = 255 } }; //Light blue
            public Models.Color.ExtendedColor Optimal { get; set; } = new Models.Color.ExtendedColor() { Color = new Color() {A = 255, R = 0, G = 255, B = 0 } }; //Green
            public Models.Color.ExtendedColor Hot { get; set; } = new Models.Color.ExtendedColor() { Color = new Color() {A = 255, R = 255, G = 0, B = 0 } }; //Red
        }
    }
}
