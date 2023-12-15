using System.Numerics;

namespace Simhub_R3E_Extra_properties_plugin.Math
{
    public static class LinearFunction
    {
        public static double GetY(Vector2 point1, Vector2 point2, double x)
        {
            var m = (point2.Y - point1.Y) / (point2.X - point1.X);
            var b = point1.Y - (m * point1.X);

            return (m * x) + b;
        }

        public static double Scale(double value, double min, double max, double minScale, double maxScale)
        {
            return minScale + (double)(value - min) / (max - min) * (maxScale - minScale);
        }
    }
}
