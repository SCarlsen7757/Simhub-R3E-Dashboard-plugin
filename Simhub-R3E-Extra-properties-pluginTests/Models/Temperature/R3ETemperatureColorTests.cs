using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simhub_R3E_Extra_properties_plugin.Settings;

namespace Simhub_R3E_Extra_properties_plugin.Model.Tests
{
    [TestClass()]
    public class R3ETemperatureColorTests
    {
        [TestMethod()]
        public void ColorConverterTest()
        {
            Color resultColor;
            Color expectedColor;
            double temperature;
            Optimal optimal = new Optimal(100, 90, 110);
            double min = 0;
            double max = 200;

            var coldColor = new Color() { A = 255, R = 0, G = 255, B = 255 };
            var optiColor = new Color() { A = 255, R = 0, G = 255, B = 0 };
            var hotColor = new Color() { A = 255, R = 255, G = 0, B = 0 };

            TyreAndBrakeColorSettings.ColorValues colorSettings = new TyreAndBrakeColorSettings.ColorValues();
            colorSettings.Cold.Color = coldColor;
            colorSettings.Optimal.Color = optiColor;
            colorSettings.Hot.Color = hotColor;


            //Cold test
            temperature = 0;
            expectedColor = coldColor;
            resultColor = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<Color>(expectedColor, resultColor);

            //Semi cold test
            temperature = 45;
            expectedColor = new Color() { A = 255, R = 0, G = 255, B = 128 };
            resultColor = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<Color>(expectedColor, resultColor);

            //Lower optimal test
            temperature = 90;
            expectedColor = optiColor;
            resultColor = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<Color>(expectedColor, resultColor);
            //Optimal test
            temperature = 100;
            expectedColor = optiColor;
            resultColor = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<Color>(expectedColor, resultColor);
            //Upper optimal test
            temperature = 110;
            expectedColor = optiColor;
            resultColor = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<Color>(expectedColor, resultColor);

            //Semi hot test
            temperature = 155;
            expectedColor = new Color() { A = 255, R = 255, G = 255, B = 0 };
            resultColor = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<Color>(expectedColor, resultColor);

            //Hot test
            temperature = 200;
            expectedColor = hotColor;
            resultColor = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<Color>(expectedColor, resultColor);
        }

        [TestMethod()]
        public void UpdatedTemperatureSettingsTest()
        {
            R3ETemperatureColor temperatureColor = new R3ETemperatureColor();
            TyreAndBrakeColorSettings.TemperatureValues temperatureValues;
            double optimalTemperature;


            //Test 1 with relative values
            temperatureValues = new TyreAndBrakeColorSettings.TemperatureValues();
            temperatureValues.Min = 50;
            temperatureValues.Max = 100;
            temperatureValues.Range.Lower = 50;
            temperatureValues.Range.Upper = 30;

            optimalTemperature = 500;

            temperatureColor.UpdatedTemperatureSettings(optimalTemperature, temperatureValues);
            Assert.AreEqual<double>(400, temperatureColor.Min);
            Assert.AreEqual<double>(630, temperatureColor.Max);
            Assert.AreEqual<double>(450, temperatureColor.Optimal.Range.Lower);
            Assert.AreEqual<double>(530, temperatureColor.Optimal.Range.Upper);
            Assert.AreEqual<double>(500, temperatureColor.Optimal.Value);
        }
    }
}