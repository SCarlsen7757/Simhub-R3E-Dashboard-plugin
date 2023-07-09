using Simhub_R3E_Tyre_and_brake_color_plugin.Models;
using System.Collections.Generic;

namespace Simhub_R3E_Tyre_and_brake_color_plugin.Model
{
    public abstract class TemperatureInformation : Prefix
    {
        public TemperatureInformation() { }

        public TemperatureInformation(List<string> prefixList)
            : base(prefixList) { }
        public TemperatureInformation(List<string> prefixList, string prefix)
            : base(prefixList, prefix) { }
        public double Temperature { get; set; }
        public Optimal Optimal { get; set; } = new Optimal();
        /// <summary>
        /// Max value
        /// </summary>
        public double Max { get; set; }
        /// <summary>
        /// Min value
        /// </summary>
        public double Min { get; set; }
    }

    public class Optimal
    {
        public Optimal() { }
        /// <summary>
        /// Optimal value
        /// </summary>
        public double Value { get; set; }
        /// <summary>
        /// Range from optimal value +/-
        /// </summary>
        public Range Range { get; set; } = new Range();
    }

    public class Range
    {
        public Range() { }
        public Range(double lower, double upper)
        {
            Lower = lower;
            Upper = upper;
        }

        public double Lower { get; set; }
        public double Upper { get; set; }
    }
}
