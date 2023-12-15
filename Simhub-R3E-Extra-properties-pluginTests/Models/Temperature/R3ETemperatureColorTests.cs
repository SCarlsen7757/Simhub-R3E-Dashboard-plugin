using System.Collections.Generic;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simhub_R3E_Extra_properties_plugin.Settings;

namespace Simhub_R3E_Extra_properties_plugin.Model.Tests
{
    /// <summary>
    /// Test class to test abstract <see cref="TemperatureInformation"/>.
    /// </summary>
    public class TestTemperatureInformation : TemperatureInformation
    {
        public TestTemperatureInformation() : base() { }
        public TestTemperatureInformation(List<string> prefix) : base(prefix) { }
        public TestTemperatureInformation(List<string> prefixList, string prefix) { }
    }
    [TestClass()]
    public class R3ETemperatureColorTests
    {
        [TestMethod()]
        public void R3ETemperatureColorTest()
        {
            TestTemperatureInformation temperatureInformation;

            temperatureInformation = new TestTemperatureInformation();
            Assert.IsInstanceOfType(temperatureInformation, typeof(TemperatureInformation));

            List<string> prefixList = new List<string>() {"Test", "One" };

            temperatureInformation = new TestTemperatureInformation(prefixList);
            Assert.IsInstanceOfType(temperatureInformation, typeof(TemperatureInformation));

            temperatureInformation = new TestTemperatureInformation(prefixList, "Class");
            Assert.IsInstanceOfType(temperatureInformation,typeof(TemperatureInformation));
        }
        [TestMethod()]
        public void ColorConverterTest()
        {
            Color resultColor;
            Color expectedColor;
            double optimal = 100;
            double min = 0;
            double max = 200;


            TestTemperatureInformation temperatureInformation = new TestTemperatureInformation() { Optimal = optimal, Min = min, Max = max };

            var coldColor = new Color() { A = 255, R = 0, G = 255, B = 255 };
            var optiColor = new Color() { A = 255, R = 0, G = 255, B = 0 };
            var hotColor = new Color() { A = 255, R = 255, G = 0, B = 0 };

            TyreAndBrakeColorSettings.ColorValues colorSettings = new TyreAndBrakeColorSettings.ColorValues();
            colorSettings.Cold.Color = coldColor;
            colorSettings.Optimal.Color = optiColor;
            colorSettings.Hot.Color = hotColor;

            //Cold test
            temperatureInformation.Temperature = 0;
            expectedColor = coldColor;
            resultColor = R3ETemperatureColor.ColorConverter(temperatureInformation, colorSettings);
            Assert.AreEqual<Color>(expectedColor, resultColor, "Cold color test failed.");

            //Semi cold test
            temperatureInformation.Temperature = 50;
            expectedColor = new Color() { A = 255, R = 0, G = 255, B = 128 };
            resultColor = R3ETemperatureColor.ColorConverter(temperatureInformation, colorSettings);
            Assert.AreEqual<Color>(expectedColor, resultColor, "Semi cold color test failed.");

            //Optimal test
            temperatureInformation.Temperature = 100;
            expectedColor = optiColor;
            resultColor = R3ETemperatureColor.ColorConverter(temperatureInformation, colorSettings);
            Assert.AreEqual<Color>(expectedColor, resultColor, "Optimal color test failed.");

            //Semi hot test
            temperatureInformation.Temperature = 150;
            expectedColor = new Color() { A = 255, R = 255, G = 255, B = 0 };
            resultColor = R3ETemperatureColor.ColorConverter(temperatureInformation, colorSettings);
            Assert.AreEqual<Color>(expectedColor, resultColor, "Semi hot color test failed.");

            //Hot test
            temperatureInformation.Temperature = 200;
            expectedColor = hotColor;
            resultColor = R3ETemperatureColor.ColorConverter(temperatureInformation, colorSettings);
            Assert.AreEqual<Color>(expectedColor, resultColor, "Hot color test failed.");
        }

        [TestMethod()]
        public void UpdatedTemperatureSettingsTest()
        {
            R3ETemperatureColor temperatureColor = new R3ETemperatureColor();
            double optimal = 100;
            double min = 0;
            double max = 200;

            temperatureColor.UpdatedTemperatureSettings(optimal, min, max);
            Assert.AreEqual<double>(min, temperatureColor.Min, "Min temp not correct.");
            Assert.AreEqual<double>(max, temperatureColor.Max, "Max temp not correct.");
            Assert.AreEqual<double>(optimal, temperatureColor.Optimal, "Optimal temp not correct.");
        }
    }
}