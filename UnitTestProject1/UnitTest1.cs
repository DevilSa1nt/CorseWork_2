using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Coursework_WinForms_Framework;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Create new battlesuite instance
            Battlesuite battlesuite = new Battlesuite(0, "1", "1", new DateTime(2000, 1, 1), "1", 10, 10, "1", "1", 1, 2, 3, 4, 5, 4);

            //Create new array to test
            double[] values = new double[] { 1, 2, 3, 4, 5, 4 };

            //Testing
            Assert.AreEqual(values.ToString(), battlesuite.GetStats().ToString(), $"Battlesuite: {battlesuite.ToString()}");
        }
    }
}