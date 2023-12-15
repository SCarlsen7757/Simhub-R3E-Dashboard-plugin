using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Simhub_R3E_Extra_properties_plugin.Models.BrakeBiasOffset.Tests
{
    [TestClass()]
    public class R3EBrakeBiasOffsetTests
    {
        [TestMethod()]
        public void CalculateOffsetTest()
        {
            Assert.AreEqual(0, R3EBrakeBiasOffset.CalculateOffset(56.4, 56.4), 0.01, "Current brake bias and base brake bias is the same, calculation failed.");
            Assert.AreEqual(1.5, R3EBrakeBiasOffset.CalculateOffset(51, 49.5), 0.01, "Current brake bias are possitive to base brake bias, calculation failed.");
            Assert.AreEqual(-1.9, R3EBrakeBiasOffset.CalculateOffset(54, 55.9), 0.01, "Current brake bias are negative to base brake bias, calculation failed.");
        }
    }
}