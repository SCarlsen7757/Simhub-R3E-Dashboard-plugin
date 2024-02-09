using GameReaderCommon;
using SimHub.Plugins;
using System.Collections.Generic;


namespace Simhub_R3E_Extra_properties_plugin.Models.Temperature.Tire
{
    public delegate void NewTireEvent(string tireName);
    public class R3ETyreAge : Prefix, ISimhubProperty
    {
        public event NewTireEvent NewTire;

        private int _age = -1;
        private int Age
        {
            get
            {
                if (_age <= 0)
                { return 0; }
                else
                { return _age; }
            }
            set { _age = value; }
        }
        private bool _newTire;

        public R3ETyreAge() : base() { }

        public R3ETyreAge(List<string> prefixList)
            : base(prefixList, "Age")
        {

        }

        private void SetNewTireAge()
        {
            _age = -1;
        }

        private void PluginManager_NewLap(int completedLapNumber, bool testLap, PluginManager manager, ref GameData data)
        {
            _age++;
        }

        public void UpdateData(ref GameData data, PluginManager pluginManager, double? oldWear, double newWear)
        {
            if ((oldWear == null || oldWear < newWear) && !_newTire)
            {
                _newTire = true;
                SetNewTireAge();
                NewTire?.Invoke(FullName());
            }
            else if (oldWear == null || oldWear >= newWear)
            {
                _newTire = false;
            }
            this.SetProperty(pluginManager);
        }

        public void AddProperty(PluginManager pluginManager)
        {
            pluginManager.AddProperty(FullName(), GetType(), this.Age);
            pluginManager.NewLap += PluginManager_NewLap;
        }

        public void SetProperty(PluginManager pluginManager)
        {
            pluginManager.SetPropertyValue(FullName(), GetType(), this.Age);
        }

    }
}
