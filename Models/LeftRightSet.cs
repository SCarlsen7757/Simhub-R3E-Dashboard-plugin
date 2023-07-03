using Simhub_R3E_Tyre_and_brake_color_plugin.Model;

namespace Simhub_R3E_Tyre_and_brake_color_plugin.Models
{
    public class LeftRightSet
    {
        public LeftRightSet() { }
        public ComponentTemperatureInformation Left { get; set; } = new ComponentTemperatureInformation();
        public ComponentTemperatureInformation Right { get; set; } = new ComponentTemperatureInformation();
    }
}
