using System.Reflection;

namespace Simhub_R3E_Extra_properties_plugin
{
    public class Version
    {
        public static string PluginVersion { get => Assembly.GetExecutingAssembly().GetName().Version.ToString(3); }
    }
}
