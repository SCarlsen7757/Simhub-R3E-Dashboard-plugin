using GameReaderCommon;
using SimHub.Plugins;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simhub_R3E_Dashboard_plugin.Models.Sector
{
    public class SectorsInformation : ISimhub
    {
        public SectorsInformation()
        {
            this.sector = new Sector[3];

            for (int i = 0; i < this.sector.Length; i++) { this.sector[i] = new Sector(i + 1); }
        }

        public readonly Sector[] sector;

        public void Init(PluginManager pluginManager)
        {
            foreach (Sector sector in this.sector) { sector.Color.AddProperty(pluginManager); }
            pluginManager.DataUpdated += PluginManager_DataUpdated;
            pluginManager.NewLap += PluginManager_NewLap;
        }

        private async void ClearSectorColorsWithDelay(PluginManager pluginManager, TimeSpan timeSpan)
        {
            await Task.Delay(timeSpan);
            foreach (Sector sector in this.sector)
            {
                sector.Clear(pluginManager);
            }
        }

        private void PluginManager_NewLap(int completedLapNumber, bool testLap, PluginManager manager, ref GameData data)
        {
            TimeSpan timeSpan = new TimeSpan(0, 0, 5);

            this.sector[this.sector.Length - 1].Update(manager, data);
            ClearSectorColorsWithDelay(manager, timeSpan);
        }

        public void PluginManager_DataUpdated(ref GameData data, PluginManager manager)
        {
            if (!data.GameRunning || !R3EDashboard.SupportedGame(data)) return;
            this.Update(manager, data);
        }

        public void Update(PluginManager pluginManager, GameData data)
        {
            if (data.NewData.Sector1Time != null) this.sector[0].Update(pluginManager, data);
            if(data.NewData.Sector2Time != null) this.sector[1].Update(pluginManager, data);
        }
    }
}
