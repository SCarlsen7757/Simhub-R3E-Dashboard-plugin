using GameReaderCommon;
using SimHub.Plugins;
using Simhub_R3E_Extra_properties_plugin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Extra_properties_plugin.Models
{
    public interface ITemperature
    {
        
        double OptimalTemperature { set; }
        Range OptimalRange { set; }
        double Max { set; }
        double Min { set; }
        void SetTemperature(StatusDataBase data);
        void UpdateTemperature(StatusDataBase data);
    }
}
