using GameReaderCommon;
using SimHub.Plugins;
using SimHub.Plugins.OutputPlugins.Dash.GLCDTemplating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Dashboard_plugin.Models.Sector
{
    public class Sector : Prefix
    {
        public Sector() : base() { }

        public Sector(int sectorNumber) : base("Sector" + sectorNumber)
        {
            this.sectorNumber = sectorNumber;
            Color = new R3ESectorColor(_prefix);
        }

        public R3ESectorColor Color { get; set; }

        public SectorTime Time { get; set; } = new SectorTime();

        private readonly int sectorNumber = 1;

        public void Clear(PluginManager pluginManager)
        {
            this.Time.New = null;
            Color.Colors.Font = SectorColor.ColorConverter(R3EDashboard.SectorColorSettings.Sector.Font, Time);
            Color.Colors.Background = SectorColor.ColorConverter(R3EDashboard.SectorColorSettings.Sector.Background, Time);
            Color.SetProperty(pluginManager);
        }

        public void Update(PluginManager pluginManager, GameData data)
        {


            switch (sectorNumber)
            {
                case 1:
                    Time.OverallBest = data.NewData.Sector1BestLapTime;
                    Time.PersonalBest = data.NewData.Sector1BestTime;
                    Time.Last = data.NewData.Sector1LastLapTime;
                    Time.New = data.NewData.Sector1Time;
                    break;
                case 2:
                    Time.OverallBest = data.NewData.Sector2BestLapTime;
                    Time.PersonalBest = data.NewData.Sector2BestTime;
                    Time.Last = data.NewData.Sector2LastLapTime;
                    Time.New = data.NewData.Sector2Time;
                    break;
                case 3:
                    Time.OverallBest = data.NewData.Sector3BestLapTime;
                    Time.PersonalBest = data.NewData.Sector3BestTime;
                    Time.Last = data.NewData.Sector3LastLapTime;
                    Time.New = data.OldData.Sector3LastLapTime;
                    break;
                default:
                    break;
            }




            Color.Colors.Font = SectorColor.ColorConverter(R3EDashboard.SectorColorSettings.Sector.Font, Time);
            Color.Colors.Background = SectorColor.ColorConverter(R3EDashboard.SectorColorSettings.Sector.Background, Time);
            Color.SetProperty(pluginManager);
        }
        public class SectorTime
        {
            public SectorTime() { }
            public SectorTime(TimeSpan? @new, TimeSpan? last, TimeSpan? overallBest, TimeSpan? personalBest)
            {
                New = @new;
                Last = last;
                OverallBest = overallBest;
                PersonalBest = personalBest;
            }

            public TimeSpan? New { get; set; } = null;
            public TimeSpan? Last { get; set; } = null;
            public TimeSpan? OverallBest { get; set; } = null;
            public TimeSpan? PersonalBest { get; set; } = null;
        }
    }
}
