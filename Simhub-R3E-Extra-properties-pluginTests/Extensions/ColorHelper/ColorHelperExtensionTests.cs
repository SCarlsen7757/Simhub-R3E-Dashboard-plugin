using Microsoft.VisualStudio.TestTools.UnitTesting;
using ColorHelper;
using Simhub_R3E_Extra_properties_plugin.Extensions.ColorHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Extra_properties_plugin.Extensions.ColorHelper.Tests
{
    [TestClass()]
    public class ColorHelperExtensionTests
    {
        [TestMethod()]
        public void ToHEXTest()
        {
            HSV hsv = new HSV(120, 100, 100);
            HEX hex = new HEX("#00FF00");

            Assert.AreEqual<HEX>(hex, hsv.ToHEX());
        }

        [TestMethod()]
        public void ToColorStringTest()
        {
            HEX hex = new HEX("FFD500");
            Assert.AreEqual<string>("#FFD500", hex.ToColorString());
        }
    }
}