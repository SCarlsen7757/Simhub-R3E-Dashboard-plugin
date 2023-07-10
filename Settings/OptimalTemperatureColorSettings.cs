using Simhub_R3E_Dashboard_plugin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Dashboard_plugin.Settings
{
    public class OptimalTemperatureColorSettings
    {
        public OptimalTemperatureColorSettings() { }
        public HueValues Hue { get; set; } = new HueValues(180, 120, 0);
        public TemperatureValues BrakesTemperature { get; set; } = new TemperatureValues(new AbsoluteRelative(null,300), new AbsoluteRelative(null, 300), 100, 100);
        public TemperatureValues TyresTemperature { get;set; } = new TemperatureValues(new AbsoluteRelative(null, 30), new AbsoluteRelative(null, 30), 5, 5);
    }
    public class HueValues
    {
        public HueValues() { }
        public HueValues(byte cold, byte optimal, byte hot)
        {
            Cold = cold;
            Optimal = optimal;
            Hot = hot;
        }
        public byte Cold { get; set; }
        public byte Optimal { get; set; }
        public byte Hot { get; set; }
    }

    public class AbsoluteRelative
    {
        public AbsoluteRelative() { }

        public AbsoluteRelative(double? absolute, double? relative)
        {
            Absolute = absolute;
            Relative = relative;
        }
        public double? Absolute { get; set; } = null;
        public double? Relative { get; set; } = null;
    }
    public class TemperatureValues
    {
        public TemperatureValues() { }
        public TemperatureValues(AbsoluteRelative min, AbsoluteRelative max, Range range)
        {
            Min = min;
            Max = max;
            Range = range;
        }
        public TemperatureValues(AbsoluteRelative min, AbsoluteRelative max, double rangeLower, double rangeUpper)
        {
            Min = min;
            Max = max;
            Range = new Range(rangeLower, rangeUpper);
        }

        public AbsoluteRelative Min { get; set;} = new AbsoluteRelative();
        public AbsoluteRelative Max { get; set; } = new AbsoluteRelative();
        public Range Range { get; set;}

    }
}
