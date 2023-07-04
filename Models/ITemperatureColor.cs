using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Tyre_and_brake_color_plugin.Model
{
    public interface ITemperatureColor
    {
        /// <summary>
        /// Temperature value.
        /// </summary>
        /// <param name="temperature">New temperature variable.</param>
        double Temperature { get; set; }

        /// <summary>
        /// Get color in HEX format.
        /// </summary>
        string Color { get; }
    }
}
