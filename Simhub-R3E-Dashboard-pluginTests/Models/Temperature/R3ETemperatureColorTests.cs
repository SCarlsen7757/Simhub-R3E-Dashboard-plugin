using ColorHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simhub_R3E_Dashboard_plugin.Settings;

namespace Simhub_R3E_Dashboard_plugin.Model.Tests
{
    [TestClass()]
    public class R3ETemperatureColorTests
    {
        [TestMethod()]
        public void ColorConverterTest()
        {
            HEX color;
            double temperature;
            Optimal optimal = new Optimal(100, 90, 110);
            double min = 0;
            double max = 200;
            OptimalTemperatureColorSettings.HueValues colorSettings = new OptimalTemperatureColorSettings.HueValues(180, 120, 0);

            //Cold test
            temperature = 0;
            color = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<HEX>(new HEX("00FFFF"), color);

            //Semi cold test
            temperature = 45;
            color = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<HEX>(new HEX("00FF80"), color);

            //Lower optimal test
            temperature = 90;
            color = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<HEX>(new HEX("00FF00"), color);
            //Optimal test
            temperature = 100;
            color = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<HEX>(new HEX("00FF00"), color);
            //Upper optimal test
            temperature = 110;
            color = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<HEX>(new HEX("00FF00"), color);

            //Semi hot test
            temperature = 155;
            color = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<HEX>(new HEX("FFFF00"), color);

            //Hot test
            temperature = 200;
            color = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<HEX>(new HEX("FF0000"), color);
        }

        [TestMethod()]
        public void UpdatedTemperatureSettingsTest()
        {
            R3ETemperatureColor temperatureColor = new R3ETemperatureColor();
            OptimalTemperatureColorSettings.TemperatureValues temperatureValues;
            double optimalTemperature;

            //Test 1 with Absolute values
            temperatureValues = new OptimalTemperatureColorSettings.TemperatureValues();
            temperatureValues.Min.Absolute = 0;
            temperatureValues.Max.Absolute = 200;
            temperatureValues.Range.Lower = 10;
            temperatureValues.Range.Upper = 10;

            optimalTemperature = 100;

            temperatureColor.UpdatedTemperatureSettings(optimalTemperature, temperatureValues);
            Assert.AreEqual<double>(0, temperatureColor.Min);
            Assert.AreEqual<double>(200, temperatureColor.Max);
            Assert.AreEqual<double>(90, temperatureColor.Optimal.Range.Lower);
            Assert.AreEqual<double>(110, temperatureColor.Optimal.Range.Upper);
            Assert.AreEqual<double>(100, temperatureColor.Optimal.Value);

            //Test 2 with relative values
            temperatureValues = new OptimalTemperatureColorSettings.TemperatureValues();
            temperatureValues.Min.Relative = 50;
            temperatureValues.Max.Relative = 100;
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