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
            Sector.SectorTime<TimeSpan> time;
            System.Windows.Media.Color notRun = new System.Windows.Media.Color() { R = 7, G = 7, B = 7 };
            System.Windows.Media.Color slow = new System.Windows.Media.Color() { R = 129, G = 151, B = 62 };
            System.Windows.Media.Color personalBest = new System.Windows.Media.Color() { R = 64, G = 117, B = 117 };
            System.Windows.Media.Color overallClassBest = new System.Windows.Media.Color() { A = 255, R = 0, G = 0, B = 255 };
            System.Windows.Media.Color overallBest = new System.Windows.Media.Color() { R = 239, G = 81, B = 82 };
            SectorColorSettings.Colors colors = new SectorColorSettings.Colors(notRun, slow, personalBest, overallClassBest, overallBest);

            //Test with no new/current sector time
            time = new Sector.SectorTime<TimeSpan>(default, new TimeSpan(300), new TimeSpan(100), new TimeSpan(150), new TimeSpan(200));

            expectedColor = notRun;
            resultColor = SectorColor.ColorConverter(colors, time);
            Assert.AreEqual(expectedColor, resultColor, "Not run color not correct.");

            //Test with slow new/current sector time
            time = new Sector.SectorTime<TimeSpan>(new TimeSpan(250), new TimeSpan(300), new TimeSpan(100), new TimeSpan(150), new TimeSpan(200));

            expectedColor = slow;
            resultColor = SectorColor.ColorConverter(colors, time);
            Assert.AreEqual(expectedColor, resultColor, "Slow color not correct.");

            //Test with personal best new/current sector time
            time = new Sector.SectorTime<TimeSpan>(new TimeSpan(160), new TimeSpan(300), new TimeSpan(100), new TimeSpan(150), new TimeSpan(200));

            expectedColor = personalBest;
            resultColor = SectorColor.ColorConverter(colors, time);
            Assert.AreEqual(expectedColor, resultColor, "Personal best color not correct.");

            //Test with overall class best new/current sector time
            time = new Sector.SectorTime<TimeSpan>(new TimeSpan(150), new TimeSpan(300), new TimeSpan(100), new TimeSpan(150), new TimeSpan(200));

            expectedColor = overallClassBest;
            resultColor = SectorColor.ColorConverter(colors, time);
            Assert.AreEqual(expectedColor, resultColor, "Over all class best color not correct.");

            //Test with overall best new/current sector time
            time = new Sector.SectorTime<TimeSpan>(new TimeSpan(100), new TimeSpan(300), new TimeSpan(100), new TimeSpan(150), new TimeSpan(200));

            expectedColor = overallBest;
            resultColor = SectorColor.ColorConverter(colors, time);
            Assert.AreEqual(expectedColor, resultColor, "Over all best color not correct.");
        }
    }
}