using GameReaderCommon;
using SimHub.Plugins;
using System;
using System.Collections.Generic;

namespace Simhub_R3E_Extra_properties_plugin.Models.BrakeBiasOffset
{
    public class R3EBrakeBiasOffset : Prefix, ISimhub, ISimhubProperty
    {
        private const string SUBFIX = "Offset";
        private double? baseBrakeBias = null;

        public R3EBrakeBiasOffset() : base("BrakeBiasOffset")
        {
            
        }

        public R3EBrakeBiasOffset(List<string> prefixList, string prefix) : base(prefixList, prefix)
        {
                
        }

        public void Init(PluginManager pluginManager)
        {
            this.AddProperty(pluginManager);
            pluginManager.DataUpdated += this.PluginManager_DataUpdated;
            pluginManager.GameManager.CarChanged += GameManager_CarChanged;
            pluginManager.GameManager.TrackChanged += GameManager_TrackChanged;

            //Add Save brake bias offset event to Simhub
            pluginManager.AddAction(FullName("Save"), (Action<PluginManager, string>)((pm, a) =>
            {
                if (!pm.Status.GameRunning) return;
                SaveBrakeBias(pluginManager);
            }));

            //Add Clear brake bias offset event to Simhub
            pluginManager.AddAction(FullName("Clear"), (Action<PluginManager, string>)((pm, a) => { ClearBrakeBias(); }));
        }

        private void GameManager_CarChanged(string newCar, IGameManager manager)
        {
            ClearBrakeBias();
        }
        private void GameManager_TrackChanged(string newTrack, IGameManager manager)
        {
            ClearBrakeBias();
        }

        public void PluginManager_DataUpdated(ref GameData data, PluginManager manager)
        {
            if (!data.GameRunning) return;
            SetProperty(manager);
        }

        public void AddProperty(PluginManager pluginManager)
        {
            pluginManager.AddProperty(FullName(SUBFIX), GetType(), baseBrakeBias);
        }
        public void SetProperty(PluginManager pluginManager)
        {
            double? value;
            if (baseBrakeBias == null) { value = null; } else { value = CalculateOffset(pluginManager.Status.NewData.BrakeBias, (double)baseBrakeBias); }

            pluginManager.SetPropertyValue(FullName(SUBFIX), GetType(), value);
        }

        private void SaveBrakeBias(PluginManager pluginManager)
        {
            var newData = pluginManager.Status.NewData;
            if(newData == null) return;
            baseBrakeBias = newData.BrakeBias;
        }

        private void ClearBrakeBias()
        {
            baseBrakeBias = null;
        }

        public static double CalculateOffset(double currentBrakeBias, double baseBrakeBias)
        {
            return currentBrakeBias - baseBrakeBias;
        }
    }
}