using GameReaderCommon;
using SimHub.Plugins;
using System;

namespace Simhub_R3E_Extra_properties_plugin.Models.Sector
{
    public class Sector : Prefix
    {
        public Sector() : base() { }

        public Sector(SectorsInformation.ESector sectorNumber) : base("Sector" + ((int)sectorNumber + 1))
        {
            this.sectorNumber = sectorNumber;
            Color = new R3ESectorColor(_prefix);
        }

        public R3ESectorColor Color { get; set; }

        private readonly SectorsInformation.ESector sectorNumber = SectorsInformation.ESector.S1;

        private TimeSpan FloatToTimeSpan(float time)
        {
            if (time < 0) return TimeSpan.Zero;
            return new TimeSpan((long)(time * 1000 * 10000));
        }

        private SectorTime<TimeSpan> GetSectorTime(ref GameData data, bool lastLap)
        {
            R3E.Data.Shared r3eData = (R3E.Data.Shared)data.NewData.GetRawDataObject();
            SectorTime<TimeSpan> time = new SectorTime<TimeSpan>();

            switch (this.sectorNumber)
            {
                case SectorsInformation.ESector.S1:

                    time.PersonalBest = FloatToTimeSpan(r3eData.BestIndividualSectorTimeSelf.Sector1);
                    time.OverallClassBest = FloatToTimeSpan(r3eData.BestIndividualSectorTimeLeaderClass.Sector1);
                    time.OverallBest = FloatToTimeSpan(r3eData.BestIndividualSectorTimeLeader.Sector1);

                    if (!lastLap)
                    {
                        if (data.NewData.Sector1Time != null) { time.New = (TimeSpan)data.NewData.Sector1Time; }
                        if (data.OldData == null) break;
                        if (data.NewData.SessionTypeName != data.OldData.SessionTypeName) break; //Break if new data and old data are from 2 different sessions.
                        if (data.OldData.Sector1LastLapTime != null) { time.Last = (TimeSpan)data.OldData.Sector1LastLapTime; }
                    }
                    else
                    {
                        if (data.NewData.Sector1LastLapTime != null) time.New = (TimeSpan)data.NewData.Sector1LastLapTime;
                        if (data.OldData == null) break;
                        if (data.OldData.Sector1LastLapTime != null) { time.Last = (TimeSpan)data.OldData.Sector1LastLapTime; }
                    }
                    break;

                case SectorsInformation.ESector.S2:

                    time.PersonalBest = FloatToTimeSpan(r3eData.BestIndividualSectorTimeSelf.Sector2);
                    time.OverallClassBest = FloatToTimeSpan(r3eData.BestIndividualSectorTimeLeaderClass.Sector2);
                    time.OverallBest = FloatToTimeSpan(r3eData.BestIndividualSectorTimeLeader.Sector2);

                    if (!lastLap)
                    {
                        if (data.NewData.Sector2Time != null) { time.New = (TimeSpan)data.NewData.Sector2Time; }
                        if (data.OldData == null) break;
                        if (data.NewData.SessionTypeName != data.OldData.SessionTypeName) break;//Break if new data and old data are from 2 different sessions.
                        if (data.OldData.Sector2LastLapTime != null) { time.Last = (TimeSpan)data.OldData.Sector2LastLapTime; }
                    }
                    else
                    {
                        if (data.NewData.Sector2LastLapTime != null) time.New = (TimeSpan)data.NewData.Sector2LastLapTime;
                        if (data.OldData == null) break;
                        if (data.OldData.Sector2LastLapTime != null) { time.Last = (TimeSpan)data.OldData.Sector2LastLapTime; }
                    }

                    break;

                case SectorsInformation.ESector.S3:

                    if (!lastLap) break;//Don't provide data if it's not for the previous lap.

                    time.PersonalBest = FloatToTimeSpan(r3eData.BestIndividualSectorTimeSelf.Sector3);
                    time.OverallClassBest = FloatToTimeSpan(r3eData.BestIndividualSectorTimeLeaderClass.Sector3);
                    time.OverallBest = FloatToTimeSpan(r3eData.BestIndividualSectorTimeLeader.Sector3);

                    if (data.NewData != null && data.NewData.Sector3LastLapTime != null)
                    {
                        time.New = (TimeSpan)data.NewData.Sector3LastLapTime;
                    }
                    else
                    {
                        time.New = default;
                    }

                    if (data.OldData != null && data.OldData.Sector3LastLapTime != null) //TODO: Fix this shit!!!
                    {
                        time.Last = (TimeSpan)data.OldData.Sector3LastLapTime;
                    }
                    else
                    {
                        time.Last = default;
                    }
                    break;
            }

            return time;
        }

        public void Update(PluginManager pluginManager, ref GameData data, bool lastLap)
        {
            SectorTime<TimeSpan> time = GetSectorTime(ref data, lastLap);

            Color.Colors.Font.Color = SectorColor.ColorConverter(R3EExtraProperties.SectorColorSettings.Sector.Font, time);
            Color.Colors.Background.Color = SectorColor.ColorConverter(R3EExtraProperties.SectorColorSettings.Sector.Background, time);
            Color.SetProperty(pluginManager);
        }
        public class SectorTime<T>
        {
            public SectorTime() { }
            public SectorTime(T @new, T last, T overallBest, T overallClassBest, T personalBest)
            {
                New = @new;
                Last = last;
                OverallBest = overallBest;
                OverallClassBest = overallClassBest;
                PersonalBest = personalBest;
            }

            public T New { get; set; } = default;
            public T Last { get; set; } = default;
            public T OverallBest { get; set; } = default;
            public T OverallClassBest { get; set; } = default;
            public T PersonalBest { get; set; } = default;
        }
    }
}


/*
     public Sectors<float> BestIndividualSectorTimeSelf;

    public Sectors<float> BestIndividualSectorTimeLeader;

    public Sectors<float> BestIndividualSectorTimeLeaderClass;
*/