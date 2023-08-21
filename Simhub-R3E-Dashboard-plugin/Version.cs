using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Extra_properties_plugin
{
    public class Version
    {
        public static string PluginVersion { get => Assembly.GetExecutingAssembly().GetName().Version.ToString(3); }
    }
}
