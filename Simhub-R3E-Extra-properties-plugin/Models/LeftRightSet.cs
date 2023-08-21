using SimHub.Plugins;
using Simhub_R3E_Extra_properties_plugin.Model;
using System;
using System.Collections.Generic;

namespace Simhub_R3E_Extra_properties_plugin.Models
{
    public class LeftRightSet<T> : Prefix, ISimhubProperty where T :ISimhubProperty, new()
    {
        public LeftRightSet() : base()
        {
            this.Left = (T)Activator.CreateInstance(typeof(T), nameof(Left));
            this.Right = (T)Activator.CreateInstance(typeof(T), nameof(Right));
        }
        public LeftRightSet(List<string> prefixList, string prefix)
            : base(prefixList, prefix)
        {
            this.Left = (T)Activator.CreateInstance(typeof(T), this._prefix, nameof(Left));
            this.Right = (T)Activator.CreateInstance(typeof(T), this._prefix, nameof(Right));
        }
        public T Left { get; set; }
        public T Right { get; set; }

        public void AddProperty(PluginManager pluginManager)
        {
            this.Left.AddProperty(pluginManager);
            this.Right.AddProperty(pluginManager);
        }
        public void SetProperty(PluginManager pluginManager)
        {
            this.Left.SetProperty(pluginManager);
            this.Right.SetProperty(pluginManager);
        }
    }
}
