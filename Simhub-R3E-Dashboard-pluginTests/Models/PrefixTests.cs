using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simhub_R3E_Dashboard_plugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simhub_R3E_Dashboard_plugin.Models.Tests
{
    [TestClass()]
    public class PrefixTests
    {
        [TestMethod()]
        public void FullNameTest()
        {
            TestClass testClass;

            testClass = new TestClass();

            Assert.AreEqual<string>("", testClass.FullPrefix);
            Assert.AreEqual<string>("", testClass.FullName(""));
            Assert.AreEqual<string>("Test1", testClass.FullName("Test1"));

            testClass = new TestClass("TestClass");
            Assert.AreEqual<string>("TestClass", testClass.FullPrefix);
            Assert.AreEqual<string>("TestClass", testClass.FullName(""));
            Assert.AreEqual<string>("TestClass.Test2", testClass.FullName("Test2"));

            List<string> prefixList = new List<string>();
            prefixList.Add("TestClass");
            prefixList.Add("Is");

            testClass = new TestClass(prefixList);
            Assert.AreEqual<string>("TestClass.Is", testClass.FullPrefix);
            Assert.AreEqual<string>("TestClass.Is", testClass.FullName(""));
            Assert.AreEqual<string>("TestClass.Is.Test3", testClass.FullName("Test3"));

            testClass = new TestClass(prefixList, "Awesome");
            Assert.AreEqual<string>("TestClass.Is.Awesome", testClass.FullPrefix);
            Assert.AreEqual<string>("TestClass.Is.Awesome", testClass.FullName(""));
            Assert.AreEqual<string>("TestClass.Is.Awesome.Test4", testClass.FullName("Test4"));
        }

        private class TestClass : Prefix
        {
            public TestClass() : base() { }
            public TestClass(string prefix) : base(prefix) { }
            public TestClass(List<string> prefixList): base(prefixList) { }
            public TestClass(List<string> prefixList, string prefix) : base(prefixList, prefix) { }

        }
    }
}