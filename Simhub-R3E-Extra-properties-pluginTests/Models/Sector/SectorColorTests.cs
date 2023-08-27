using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simhub_R3E_Extra_properties_plugin.Settings;
using System;

namespace Simhub_R3E_Extra_properties_plugin.Models.Sector.Tests
{
    [TestClass()]
    public class SectorColorTests
    {
        [TestMethod()]
        public void ColorConverterTest()
        {
            System.Windows.Media.Color resultColor;
            System.Windows.Media.Color expectedColor;
            Sector.SectorTime time;
            System.Windows.Media.Color notRun = new System.Windows.Media.Color() { R = 7, G = 7, B = 7 };
            System.Windows.Media.Color slow = new System.Windows.Media.Color() { R = 129, G = 151, B = 62 };
            System.Windows.Media.Color personalBest = new System.Windows.Media.Color() { R = 64, G = 117, B = 117 };
            System.Windows.Media.Color overallBest = new System.Windows.Media.Color() { R = 239, G = 81, B = 82 };
            SectorColorSettings.Colors colors = new SectorColorSettings.Colors(notRun, slow, personalBest, overallBest);

            //Test with no new/current sector time
            time = new Sector.SectorTime(null, new TimeSpan(300), new TimeSpan(100), new TimeSpan(200));

            expectedColor = notRun;
            resultColor = SectorColor.ColorConverter(colors, time);
            Assert.AreEqual(expectedColor, resultColor);

            //Test with slow new/current sector time
            time = new Sector.SectorTime(new TimeSpan(250), new TimeSpan(300), new TimeSpan(100), new TimeSpan(200));

            expectedColor = slow;
            resultColor = SectorColor.ColorConverter(colors, time);
            Assert.AreEqual(expectedColor, resultColor);

            //Test with personal best new/current sector time
            time = new Sector.SectorTime(new TimeSpan(150), new TimeSpan(300), new TimeSpan(100), new TimeSpan(200));

            expectedColor = personalBest;
            resultColor = SectorColor.ColorConverter(colors, time);
            Assert.AreEqual(expectedColor, resultColor);

            //Test with overall best new/current sector time
            time = new Sector.SectorTime(new TimeSpan(50), new TimeSpan(300), new TimeSpan(100), new TimeSpan(200));

            expectedColor = overallBest;
            resultColor = SectorColor.ColorConverter(colors, time);
            Assert.AreEqual(expectedColor, resultColor);
        }
    }
}