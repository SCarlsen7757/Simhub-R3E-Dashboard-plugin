using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Tyre_and_brake_color_plugin.Settings
{
    public class ColorSettings
    {
        public ColorSettings() { }
        public HueValues Hue { get; set; } = new HueValues(180, 120, 0);
    }
    public class HueValues
    {
        public HueValues() { }
        public HueValues(byte cold, byte optimal, byte hot)
        {
            Cold = cold;
            Optimal = optimal;
            Hot = hot;
        }
        public byte Cold { get; set; }
        public byte Optimal { get; set; }
        public byte Hot { get; set; }
    }
}
