
namespace Simhub_R3E_Tyre_and_brake_color_plugin.Model
{
    public class ComponentTemperatureInformation : TemperatureInformation, ITemperatureColor
    {
        public ComponentTemperatureInformation()
        {
        }
        private double _temperature;

        public void ChangeTemperature(ref double temperature)
        {
            _temperature = temperature;
        }
        public string Color { get => "#e90300"; }
    }
}
