using GameReaderCommon;
using SimHub.Plugins;
using SimHub.Plugins.OutputPlugins.Dash.GLCDTemplating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Extra_properties_plugin.Models.Sector
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
            Color.Colors.Font = SectorColor.ColorConverter(R3EExtraProperties.SectorColorSettings.Sector.Font, Time);
            Color.Colors.Background = SectorColor.ColorConverter(R3EExtraProperties.SectorColorSettings.Sector.Background, Time);
            Color.SetProperty(pluginManager);
        }

        public void Update(PluginManager pluginManager, ref GameData data)
        {
            R3E.Data.Shared rawdata = (R3E.Data.Shared)data.NewData.GetRawDataObject();

            TimeSpan? personalBest;
            TimeSpan? overallBest;
            long ticks;
            float bestIndividualSectorTimeSelf;
            float bestIndividualSectorTimeLeaderClass;

            switch (sectorNumber)
            {
                case 1:
                    bestIndividualSectorTimeSelf = rawdata.BestIndividualSectorTimeSelf.Sector1;
                    bestIndividualSectorTimeLeaderClass = rawdata.BestIndividualSectorTimeLeaderClass.Sector1;
                    
                    Time.Last = data.NewData.Sector1LastLapTime;
                    Time.New = data.NewData.Sector1Time;
                    break;
                case 2:
                    bestIndividualSectorTimeSelf = rawdata.BestIndividualSectorTimeSelf.Sector2;
                    bestIndividualSectorTimeLeaderClass = rawdata.BestIndividualSectorTimeLeaderClass.Sector2; 
                    Time.Last = data.NewData.Sector2LastLapTime;
                    Time.New = data.NewData.Sector2Time;
                    break;
                case 3:  
                    bestIndividualSectorTimeSelf = rawdata.BestIndividualSectorTimeSelf.Sector3;
                    bestIndividualSectorTimeLeaderClass = rawdata.BestIndividualSectorTimeLeaderClass.Sector3;
                    Time.OverallBest = data.NewData.Sector3BestLapTime;
                    Time.Last = data.OldData.Sector3LastLapTime;
                    Time.New = data.NewData.Sector3LastLapTime;
                    break;
                default:
                    bestIndividualSectorTimeSelf = -1;
                    bestIndividualSectorTimeLeaderClass = -1;
                    break;
            }

            if (bestIndividualSectorTimeSelf > 0)
            {
                ticks = (long)(bestIndividualSectorTimeSelf * 1000 * 10000);
                personalBest = new TimeSpan(ticks);
            }
            else
            {
                personalBest = null;
            }
            Time.PersonalBest = personalBest;

            if (bestIndividualSectorTimeLeaderClass > 0)
            {
                ticks = (long)(bestIndividualSectorTimeLeaderClass * 1000 * 10000);
                overallBest = new TimeSpan(ticks);
            }
            else
            {
                overallBest = null;
            }
            Time.OverallBest = overallBest;


            Color.Colors.Font = SectorColor.ColorConverter(R3EExtraProperties.SectorColorSettings.Sector.Font, Time);
            Color.Colors.Background = SectorColor.ColorConverter(R3EExtraProperties.SectorColorSettings.Sector.Background, Time);
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
