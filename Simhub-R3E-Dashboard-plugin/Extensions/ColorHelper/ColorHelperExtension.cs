using ColorHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Dashboard_plugin.Extensions.ColorHelper
{
    public static class ColorHelperExtension
    {
        public static HEX ToHEX(this HSV hsv)
        {
            return ColorConverter.HsvToHex(hsv);
        }
        public static string ToColorString(this HEX hex)
        {
            return "#" + hex.ToString();
        }
    }
}
