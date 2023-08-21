using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simhub_R3E_Extra_properties_plugin.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Simhub_R3E_Extra_properties_plugin.Math.Tests
{
    [TestClass()]
    public class LinearFunctionTests
    {
        [TestMethod()]
        public void GetYTest()
        {
            Vector2 point1;
            Vector2 point2;
            double result;

            point1 = new Vector2(0, 100);
            point2 = new Vector2(0, 10);

            result = LinearFunction.GetY(point1, point2, 50);
            Assert.AreEqual<double>(double.NaN, result);


            point1 = new Vector2(0, 0);
            point2 = new Vector2(10, 100);

            result = LinearFunction.GetY(point1, point2, 5);
            Assert.AreEqual<double>(50, result);
        }
    }
}