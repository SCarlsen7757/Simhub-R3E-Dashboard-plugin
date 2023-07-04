using GameReaderCommon;
using Simhub_R3E_Tyre_and_brake_color_plugin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Tyre_and_brake_color_plugin.Models
{
    public interface ISetTemperature
    {
        double OptimalTemperature { set; }
        Range OptimalRange { set; }
        double Max { set; }
        double Min { set; }

        void SetTemperature(StatusDataBase data);
    }
}
