using Microsoft.VisualStudio.Modeling.Diagrams;
using System.Windows.Media;

namespace Microsoft.VisualStudio.Modeling.Diagrams
{
    public static class ColorHelperExtension
    {
        public static HslColor ToHsl(this Color color)
        {
            double Scale(double value, double min, double max, double minScale, double maxScale)
            {
                double scaled = minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
                return scaled;
            }
            var c = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);

            var hslColor = new HslColor();
            hslColor.Hue = (int)Scale(c.GetHue(), 0f, 360f, 0, 240);
            hslColor.Saturation = (int)Scale(c.GetSaturation(), 0f, 1f, 0, 240);
            hslColor.Luminosity = (int)Scale(c.GetBrightness(), 0f, 1f, 0, 240);

            return hslColor;
        }
    }
}

namespace System.Windows.Media
{
    public static class SystemWindowsMediaColorExtension
    {
        public static Color ToColor(this HslColor hslColor)
        {
            var c = hslColor.ToRgbColor();
            var newColor = new Color() { A = c.A, R = c.R, G = c.G, B = c.B };
            return newColor;
        }
    }
}
