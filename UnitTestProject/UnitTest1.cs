using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Base_Plate_Engine.Common.Mathematics;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(7.5, MyMath.Interpolate(1.5, new[] { 1.0, 2.0 }, new[] { 5.0, 10.0 }));
            Assert.AreEqual(5.0, MyMath.Interpolate(0.5, new[] { 1.0, 2.0 }, new[] { 5.0, 10.0 }));
            Assert.AreEqual(10.0, MyMath.Interpolate(2.5, new[] { 1.0, 2.0 }, new[] { 5.0, 10.0 }));
            

        }
    }
}
