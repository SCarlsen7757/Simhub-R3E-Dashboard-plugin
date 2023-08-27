using Newtonsoft.Json;
using System.ComponentModel;

namespace Simhub_R3E_Extra_properties_plugin.Models.Color
{
    public class ExtendedColor : INotifyPropertyChanged
    {
        public ExtendedColor() { }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propName) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));

        private System.Windows.Media.Color color = new System.Windows.Media.Color();
        /// <summary>
        /// Describes a color in terms of alpha, red, green, and blue channels.
        /// </summary>
        public System.Windows.Media.Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                if (this.color == value) return;
                color = value;
                this.NotifyPropertyChanged(nameof(Color));

                // Update HSL values
                var c = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
                this.Hue = c.GetHue();
                this.Saturation = c.GetSaturation();
                this.Lightness = c.GetBrightness();
            }

        }
        private float hue;
        /// <summary>
        /// The hue, in degrees, of this color. The hue is measured in degrees, ranging from 0.0 through 360.0, in HSL color space.
        /// </summary>
        [JsonIgnore]
        public float Hue
        {
            get { return this.hue; }
            private set { this.hue = value; }
        }

        private float saturation;
        /// <summary>
        /// The saturation of this color. The saturation ranges from 0.0 through 1.0, where 0.0 is grayscale and 1.0 is the most saturated.
        /// </summary>
        [JsonIgnore]
        public float Saturation
        {
            get { return this.saturation; }
            private set { this.saturation = value; }
        }

        private float lightness;
        /// <summary>
        /// The lightness of this color. The lightness ranges from 0.0 through 1.0, where 0.0 represents black and 1.0 represents white.
        /// </summary>
        [JsonIgnore]
        public float Lightness
        {
            get { return this.lightness; }
            private set { this.lightness = value;}
        }
    }
}
