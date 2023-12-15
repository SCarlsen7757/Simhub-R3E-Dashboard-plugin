using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simhub_R3E_Extra_properties_plugin.Models.Color.Tests
{
    [TestClass()]
    public class ExtendedColorTests
    {
        [TestMethod()]
        public void ExtendedColorTest()
        {
            ExtendedColor color = null;
            Assert.IsNull(color, "Color object not null.");
            color = new ExtendedColor();
            Assert.IsNotNull(color, "Color object is null.");

            Assert.AreEqual(new System.Windows.Media.Color(), color.Color, "Color objects not equal.");

            Assert.AreEqual(0, color.Hue, "Hue value is not equal.");
            Assert.AreEqual(0, color.Saturation, "Saturation value is not equal.");
            Assert.AreEqual(0, color.Lightness, "Lightness value is not equal.");

            color.Color = new System.Windows.Media.Color() { R = 66, G = 135, B = 245 };
            Assert.AreEqual(217f, color.Hue, 0.5f, "Hue value is not equal.");
            Assert.AreEqual(0.9f, color.Saturation, 0.1f, "Saturation value is not equal.");
            Assert.AreEqual(0.61f, color.Lightness, 0.1f, "Lightness value is not equal.");
        }
    }
}