using GameReaderCommon;
using SimHub.Plugins;
using System;
using System.Threading.Tasks;

namespace Simhub_R3E_Extra_properties_plugin.Models.Sector
{
    public class SectorsInformation : ISimhub
    {
        public enum ESector
        {
            S1 = 0,
            S2 = 1,
            S3 = 2
        }

        private bool _lastLap = false;

        public SectorsInformation()
        {
            this.sector = new Sector[3];
            for (int i = 0; i < this.sector.Length; i++) { this.sector[i] = new Sector((ESector)i); }
        }

        public readonly Sector[] sector;

        public void Init(PluginManager pluginManager)
        {
            foreach (Sector sector in this.sector) { sector.Color.AddProperty(pluginManager); }
            pluginManager.DataUpdated += PluginManager_DataUpdated;
            pluginManager.NewLap += PluginManager_NewLap;
        }

        private async void NewLapLastLap(TimeSpan timeSpan)
        {
            //After a new lap, set lastLap, for Sector to calc color for sector on last lap instead of this new lap. Wait x time before it reset lastLap.
            _lastLap = true;
            await Task.Delay(timeSpan);
            _lastLap = false;
        }

        private void PluginManager_NewLap(int completedLapNumber, bool testLap, PluginManager manager, ref GameData data)
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, 5);
            NewLapLastLap(timeSpan);
        }

        public void PluginManager_DataUpdated(ref GameData data, PluginManager manager)
        {
            if (!data.GameRunning || !R3EExtraProperties.SupportedGame(data)) return;

            foreach (Sector sector in this.sector)
            {
                sector.Update(manager, ref data, _lastLap);
            }
        }
    }
}
