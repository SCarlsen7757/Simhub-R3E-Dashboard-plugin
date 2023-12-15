using Simhub_R3E_Extra_properties_plugin.Models;
using System.Collections.Generic;

namespace Simhub_R3E_Extra_properties_plugin.Model
{
    public abstract class TemperatureInformation : Prefix
    {
        public TemperatureInformation() { }

        public TemperatureInformation(List<string> prefixList)
            : base(prefixList) { }
        public TemperatureInformation(List<string> prefixList, string prefix)
            : base(prefixList, prefix) { }
        public double Temperature { get; set; }
        /// <summary>
        /// Optimal value.
        /// </summary>
        public double Optimal { get; set; }
        /// <summary>
        /// Max value.
        /// </summary>
        public double Max { get; set; }
        /// <summary>
        /// Min value.
        /// </summary>
        public double Min { get; set; }
    }
}
