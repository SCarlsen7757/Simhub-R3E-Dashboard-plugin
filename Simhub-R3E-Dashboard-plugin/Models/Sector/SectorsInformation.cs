using GameReaderCommon;
using SimHub.Plugins;
using System;
using System.Collections.Generic;
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

            for (int i = 0; i < this.sector.Length; i++) { this.sector[i] = new Sector("Sector" + (i + 1).ToString()); }
        }

        public readonly Sector[] sector;

        public PluginManager PluginManager { get; set; } = null;
        public void Init(PluginManager pluginManager)
        {
            PluginManager = pluginManager;
            foreach (Sector sector in this.sector) { sector.Color.AddProperty(pluginManager); }
            pluginManager.DataUpdated += PluginManager_DataUpdated;
            pluginManager.NewLap += PluginManager_NewLap;
        }

        private async void Test()
        {
            await Console.Out.WriteLineAsync("First msg");
            await Task.Delay(5000);
            await Console.Out.WriteLineAsync("This is a msg");
        }

        private void PluginManager_NewLap(int completedLapNumber, bool testLap, PluginManager manager, ref GameData data)
        {
            //throw new NotImplementedException();
            Test();
            // Thread.Sleep(5000);
        }

        public void PluginManager_DataUpdated(ref GameData data, PluginManager manager)
        {
            if (!data.GameRunning || !R3EDashboard.SupportedGame(data)) return;
            this.Update(data.NewData);
        }

        public void Update(StatusDataBase data) { }
    }
}
