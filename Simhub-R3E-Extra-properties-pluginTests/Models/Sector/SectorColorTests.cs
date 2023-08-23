using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simhub_R3E_Extra_properties_plugin.Models.Sector;
using Simhub_R3E_Extra_properties_plugin.Settings;
using ColorHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Extra_properties_plugin.Models.Sector.Tests
{
    [TestClass()]
    public class SectorColorTests
    {
        [TestMethod()]
        public void ColorConverterTest()
        {
            HEX color;
            Sector.SectorTime time;
            HSV notRun = new HSV(150, 12, 7);
            HSV slow = new HSV(50, 100, 100);
            HSV personalBest = new HSV(120, 71, 85);
            HSV overallBest = new HSV(288, 81, 82);
            SectorColorSettings.Colors colors = new SectorColorSettings.Colors(notRun, slow, personalBest, overallBest);

            //Test with no new/current sector time
            time = new Sector.SectorTime(null, new TimeSpan(300), new TimeSpan(100), new TimeSpan(200));

            color = SectorColor.ColorConverter(colors, time);
            Assert.AreEqual<HEX>(new HEX("111312"), color);

            //Test with slow new/current sector time
            time = new Sector.SectorTime(new TimeSpan(250), new TimeSpan(300), new TimeSpan(100), new TimeSpan(200));

            color = SectorColor.ColorConverter(colors, time);
            Assert.AreEqual<HEX>(new HEX("FFD400"), color);

            //Test with personal best new/current sector time
            time = new Sector.SectorTime(new TimeSpan(150), new TimeSpan(300), new TimeSpan(100), new TimeSpan(200));

            color = SectorColor.ColorConverter(colors, time);
            Assert.AreEqual<HEX>(new HEX("3FD93F"), color);

            //Test with overall best new/current sector time
            time = new Sector.SectorTime(new TimeSpan(50), new TimeSpan(300), new TimeSpan(100), new TimeSpan(200));

            color = SectorColor.ColorConverter(colors, time);
            Assert.AreEqual<HEX>(new HEX("B028D2"), color);
        }
    }
}