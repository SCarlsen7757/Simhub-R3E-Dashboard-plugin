using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simhub_R3E_Dashboard_plugin.Model;
using Simhub_R3E_Dashboard_plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Dashboard_plugin.Model.Tests
{
    [TestClass()]
    public class R3ETemperatureColorTests
    {
        [TestMethod()]
        public void ColorConverterTest()
        {
            string color;
            double temperature;
            Optimal optimal = new Optimal(100, 10, 10);
            double min = 0;
            double max = 200;
            OptimalTemperatureColorSettings.HueValues colorSettings = new OptimalTemperatureColorSettings.HueValues(180, 120, 0);

            //Cold test
            temperature = 0;
             color = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<string>("#00FFFF", color);

            //Optimal test
            temperature = 100;
             color = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<string>("#00FF00", color);

            //Hot test
            temperature = 200;
             color = R3ETemperatureColor.ColorConverter(temperature, optimal, min, max, colorSettings);
            Assert.AreEqual<string>("#FF0000", color);
        }
    }
}