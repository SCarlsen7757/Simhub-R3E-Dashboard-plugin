﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Dashboard_plugin.Math
{
    public static class LinearFunction
    {
        public static double GetY(Vector2 point1, Vector2 point2, double x)
        {
            var dx = point2.X - point1.X;
            if (dx == 0)
                return double.NaN;
            var m = (point2.Y - point1.Y) / dx;
            var b = point1.Y - (m * point1.X);

            return (m * x) + b;
        }
    }
}
