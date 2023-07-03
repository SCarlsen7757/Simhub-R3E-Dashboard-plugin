using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Tyre_and_brake_color_plugin.Model
{
    public class TemperatureInformation
    {
        public TemperatureInformation() { }

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
        public double Lower { get; set; }
        public double Upper { get; set; }
    }
}
