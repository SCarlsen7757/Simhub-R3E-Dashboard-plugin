using Simhub_R3E_Tyre_and_brake_color_plugin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Tyre_and_brake_color_plugin.Models
{
    public class OMITemperatureInformation
    {
        public OMITemperatureInformation() { }
        public ComponentTemperatureInformation Outer { get; set; } = new ComponentTemperatureInformation();
        public ComponentTemperatureInformation Middle { get; set; } = new ComponentTemperatureInformation();
        public ComponentTemperatureInformation Inner { get; set;} = new ComponentTemperatureInformation();
    }
}
