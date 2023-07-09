using GameReaderCommon;
using SimHub.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Tyre_and_brake_color_plugin.Models
{
    public interface ISimhubProperty
    {
        /// <summary>
        /// Add property to simhub
        /// </summary>
        /// <param name="pluginManager"></param>
        void AddProperty(PluginManager pluginManager);
        /// <summary>
        /// Set/update property value in simhub
        /// </summary>
        /// <param name="pluginManager"></param>
        void SetProperty(PluginManager pluginManager);
    }
}
