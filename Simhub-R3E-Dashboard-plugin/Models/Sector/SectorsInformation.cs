using GameReaderCommon;
using SimHub.Plugins;
using System;
using System.Threading.Tasks;

namespace Simhub_R3E_Dashboard_plugin.Models.Sector
{
    public class SectorsInformation : ISimhub
    {
        public delegate void SectorDelegate(PluginManager manager, ref GameData data);
        public event SectorDelegate Sector1Done;
        public event SectorDelegate Sector2Done;
        public event SectorDelegate Sector3Done;

        public enum ESector
        {
            S1 = 0,
            S2 = 1,
            S3 = 2
        }

        private readonly bool[] _sectorEventRaised;

        protected virtual void OnSector1Done(PluginManager manager, ref GameData data)
        {
            this._sectorEventRaised[(int)ESector.S1] = true;
            if (Sector1Done == null) return;
            Sector1Done(manager, ref data);
        }
        protected virtual void OnSector2Done(PluginManager manager, ref GameData data)
        {
            this._sectorEventRaised[(int)ESector.S2] = true;
            if (Sector2Done == null) return;
            Sector2Done(manager, ref data);
        }
        protected virtual void OnSector3Done(PluginManager manager, ref GameData data)
        {
            this._sectorEventRaised[(int)ESector.S3] = true;
            if (Sector3Done == null) return;
            Sector3Done(manager, ref data);
        }

        public SectorsInformation()
        {
            this.sector = new Sector[3];
            this._sectorEventRaised = new bool[this.sector.Length];
            for (int i = 0; i < this.sector.Length; i++) { this.sector[i] = new Sector(i + 1); }
        }

        public readonly Sector[] sector;

        public void Init(PluginManager pluginManager)
        {
            foreach (Sector sector in this.sector) { sector.Color.AddProperty(pluginManager); }
            pluginManager.DataUpdated += PluginManager_DataUpdated;
            pluginManager.NewLap += PluginManager_NewLap;
            this.Sector1Done += SectorsInformation_Sector1Done;
            this.Sector2Done += SectorsInformation_Sector2Done;
            this.Sector3Done += SectorsInformation_Sector3Done;
        }

        private void SectorsInformation_Sector1Done(PluginManager manager, ref GameData data)
        {
            this.sector[(int)ESector.S1].Update(manager, ref data);
        }

        private void SectorsInformation_Sector2Done(PluginManager manager, ref GameData data)
        {
            this.sector[(int)ESector.S2].Update(manager, ref data);
        }

        private void SectorsInformation_Sector3Done(PluginManager manager, ref GameData data)
        {
            this.sector[(int)ESector.S3].Update(manager, ref data);
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

            OnSector3Done(manager, ref data);
            ClearSectorColorsWithDelay(manager, timeSpan);

            for (int i = 0; i < this._sectorEventRaised.Length; i++)
            {
                this._sectorEventRaised[i] = false;
            }
        }

        public void PluginManager_DataUpdated(ref GameData data, PluginManager manager)
        {
            if (!data.GameRunning || !R3EDashboard.SupportedGame(data)) return;
            this.Update(manager, ref data);
        }

        public void Update(PluginManager pluginManager, ref GameData data)
        {
            if (data.NewData.Sector1Time != null && !this._sectorEventRaised[(int)ESector.S1]) this.OnSector1Done(pluginManager, ref data);
            if (data.NewData.Sector2Time != null && !this._sectorEventRaised[(int)ESector.S2]) this.OnSector2Done(pluginManager, ref data);
        }
    }
}
