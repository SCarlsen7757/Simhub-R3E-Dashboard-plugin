using Simhub_R3E_Tyre_and_brake_color_plugin.Model;

namespace Simhub_R3E_Tyre_and_brake_color_plugin.Models
{
    public class LeftRightSet<T> where T : new()
    {
        public LeftRightSet() { }
        public T Left { get; set; } = new T();
        public T Right { get; set; } = new T();
    }
}
