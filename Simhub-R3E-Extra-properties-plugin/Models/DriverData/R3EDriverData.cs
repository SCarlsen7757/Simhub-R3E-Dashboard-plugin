using GameReaderCommon;
using SimHub.Plugins;

namespace Simhub_R3E_Extra_properties_plugin.Models.DriverData
{
    public class R3EDriverData : ISimhub
    {
        int _carsOnTrack = 0;
        int _carsInPitLane = 0;

        public void Init(PluginManager pluginManager)
        {
            pluginManager.AddProperty("NumberOfCarsOnTrack", GetType(), _carsOnTrack);
            pluginManager.AddProperty("NumberOfCarsInPitLane", GetType(), _carsInPitLane);

            pluginManager.DataUpdated += PluginManager_DataUpdated;
        }

        public void PluginManager_DataUpdated(ref GameData data, PluginManager pluginManager)
        {
            if (!data.GameRunning || !R3EExtraProperties.SupportedGame(ref data)) return;

            _carsOnTrack = 0;
            _carsInPitLane = 0;
            R3E.Data.Shared gameData = (R3E.Data.Shared)data.NewData.GetRawDataObject();
            foreach (R3E.Data.DriverData driver in gameData.DriverData)
            {
                if (driver.DriverInfo.CarNumber < 0) break;

                if (driver.InPitlane > 0)
                {
                    _carsInPitLane++;
                }
                else
                {
                    _carsOnTrack++;
                }
            }

            pluginManager.SetPropertyValue("NumberOfCarsOnTrack", GetType(), _carsOnTrack);
            pluginManager.SetPropertyValue("NumberOfCarsInPitLane", GetType(), _carsInPitLane);
        }



    }
}
