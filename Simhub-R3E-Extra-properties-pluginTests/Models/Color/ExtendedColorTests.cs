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
            Assert.IsNull(color);
            color = new ExtendedColor();
            Assert.IsNotNull(color);

            Assert.AreEqual(new System.Windows.Media.Color(), color.Color);

            Assert.AreEqual(0, color.Hue);
            Assert.AreEqual(0, color.Saturation);
            Assert.AreEqual(0, color.Lightness);

            color.Color = new System.Windows.Media.Color() { R = 66, G = 135, B = 245 };
            Assert.AreEqual(217f,color.Hue,0.5f);
            Assert.AreEqual(0.9f, color.Saturation,0.1f);
            Assert.AreEqual(0.61f, color.Lightness, 0.1f);
        }
    }
}