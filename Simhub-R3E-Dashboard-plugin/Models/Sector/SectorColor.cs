using ColorHelper;
using Simhub_R3E_Dashboard_plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Dashboard_plugin.Models.Sector
{
    public class SectorColor
    {
        public static HEX ColorConverter(SectorColorSettings.Colors colors, Sector.SectorTime time)
        {
            if (time.New is null) return ColorHelper.ColorConverter.HsvToHex(colors.NotRun);
            if (time.New < time.OverallBest) return ColorHelper.ColorConverter.HsvToHex(colors.OverallBest);
            if (time.New < time.PersonalBest) return ColorHelper.ColorConverter.HsvToHex(colors.PersonalBest);
            return ColorHelper.ColorConverter.HsvToHex(colors.Slow);
        }
    }
}
