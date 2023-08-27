using Simhub_R3E_Extra_properties_plugin.Settings;
using System;

namespace Simhub_R3E_Extra_properties_plugin.Models.Sector
{
    public class SectorColor
    {
        public static System.Windows.Media.Color ColorConverter(SectorColorSettings.Colors colors, Sector.SectorTime time)
        {
            if (time.New == TimeSpan.Zero  || time.New is null) return colors.NotRun.Color;
            if (time.New < time.OverallBest || time.OverallBest is null) return colors.OverallBest.Color;
            if (time.New < time.PersonalBest || time.PersonalBest is null) return colors.PersonalBest.Color;
            return colors.Slow.Color;
        }
    }
}
