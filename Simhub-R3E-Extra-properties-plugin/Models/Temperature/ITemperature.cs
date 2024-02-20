using GameReaderCommon;

namespace Simhub_R3E_Extra_properties_plugin.Models
{
    public interface ITemperature
    {

        double OptimalTemperature { set; }
        double Max { set; }
        double Min { set; }
        void SetTemperature(StatusDataBase data);
        void UpdateTemperature(StatusDataBase data);
    }
}
