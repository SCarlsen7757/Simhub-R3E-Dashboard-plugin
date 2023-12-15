using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Simhub_R3E_Extra_properties_plugin.Models.Tests
{
    [TestClass()]
    public class PrefixTests
    {
        /// <summary>
        /// Test class to test abstract <see cref="Prefix"/> class.
        /// </summary>
        private class TestClass : Prefix
        {
            public TestClass() : base() { }
            public TestClass(string prefix) : base(prefix) { }
            public TestClass(List<string> prefixList) : base(prefixList) { }
            public TestClass(List<string> prefixList, string prefix) : base(prefixList, prefix) { }
        }
        [TestMethod()]
        public void PrefixTest()
        {
            TestClass testClass;

            testClass = new TestClass();
            Assert.IsInstanceOfType(testClass, typeof(TestClass));

            testClass = new TestClass("TestClass");
            Assert.IsInstanceOfType(testClass, typeof(TestClass));

            List<string> prefixList = new List<string>
            {
                "TestClass",
                "Is"
            };

            testClass = new TestClass(prefixList);
            Assert.IsInstanceOfType(testClass, typeof(TestClass));

            testClass = new TestClass(prefixList, "Awesome");
            Assert.IsInstanceOfType(testClass, typeof(TestClass));
        }
        [TestMethod()]
        public void FullPrefixTest()
        {
            TestClass testClass;

            testClass = new TestClass();
            Assert.AreEqual<string>("", testClass.FullPrefix, "Prefix test with default ctor, full prefix failed.");

            testClass = new TestClass("TestClass");
            Assert.AreEqual<string>("TestClass", testClass.FullPrefix, "Prefix test with Prefix string, full prefix failed.");

            List<string> prefixList = new List<string>
            {
                "TestClass",
                "Is"
            };

            testClass = new TestClass(prefixList);
            Assert.AreEqual<string>("TestClass.Is", testClass.FullPrefix, "Prefix test with Prefix List, full prefix failed.");

            testClass = new TestClass(prefixList, "Awesome");
            Assert.AreEqual<string>("TestClass.Is.Awesome", testClass.FullPrefix, "Prefix test with Prefix List and string, full prefix failed.");
        }
        [TestMethod()]
        public void FullNameTest()
        {
            TestClass testClass;

            testClass = new TestClass();
            Assert.AreEqual<string>("", testClass.FullName(""), "Prefix test with default ctor, FullName with empty string failed.");
            Assert.AreEqual<string>("", testClass.FullName("    "), "Prefix test with default ctor, FullName with white space string failed.");
            Assert.AreEqual<string>("Test1", testClass.FullName("Test1"), "Prefix test with default ctor, FullName with valid string failed.");

            testClass = new TestClass("TestClass");
            Assert.AreEqual<string>("TestClass", testClass.FullName(""), "Prefix test with Prefix string, FullName with empty string failed.");
            Assert.AreEqual<string>("TestClass", testClass.FullName("   "), "Prefix test with Prefix string, FullName with white space string failed.");
            Assert.AreEqual<string>("TestClass.Test2", testClass.FullName("Test2"), "Prefix test with Prefix string, FullName with valid string failed.");

            List<string> prefixList = new List<string>
            {
                "TestClass",
                "Is"
            };

            testClass = new TestClass(prefixList);
            Assert.AreEqual<string>("TestClass.Is", testClass.FullName(""), "Prefix test with Prefix List, FullName with empty string failed.");
            Assert.AreEqual<string>("TestClass.Is", testClass.FullName("    "), "Prefix test with Prefix List, FullName with white space string failed.");
            Assert.AreEqual<string>("TestClass.Is.Test3", testClass.FullName("Test3"), "Prefix test with Prefix List, FullName with valid string failed.");

            testClass = new TestClass(prefixList, "Awesome");
            Assert.AreEqual<string>("TestClass.Is.Awesome", testClass.FullName(""), "Prefix test with Prefix List and string, FullName with empty string failed.");
            Assert.AreEqual<string>("TestClass.Is.Awesome", testClass.FullName("    "), "Prefix test with Prefix List and string, FullName with white space string failed.");
            Assert.AreEqual<string>("TestClass.Is.Awesome.Test4", testClass.FullName("Test4"), "Prefix test with Prefix List and string, FullName with valid string failed.");
        }
    }
}