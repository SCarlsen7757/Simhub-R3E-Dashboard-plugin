using Microsoft.VisualStudio.Modeling.Diagrams;
using System;
using System.Windows.Data;
using System.Windows.Media;

namespace Simhub_R3E_Extra_properties_plugin.Models.Color
{
    public class HueToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var color = (System.Windows.Media.Color)value;
            var c = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
            return c.GetHue();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var hslColor = new HslColor((int)Math.LinearFunction.Scale((double)value, 0,360,0,240), 240, 120);
            return hslColor.ToColor();
        }        
    }
}
