using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangle;

namespace UnitTestingOfTriangle
{
    [TestClass]
    public class UnitTestingOfTriangle
    {
        [TestMethod]
        public void ZeroSidesIsFalse()
        {
            Assert.IsFalse(Triangle.Triangle.CheckTheExistenceOfTriangle(0,0,0));
        }

        [TestMethod]
        public void MinusSidesIsFalse()
        {
            Assert.IsFalse(Triangle.Triangle.CheckTheExistenceOfTriangle(-1, -1, -1));
        }

        [TestMethod]
        public void TwoSidesAreEqualIsTrue()
        {
            Assert.IsTrue(Triangle.Triangle.CheckTheExistenceOfTriangle(2,2,1));
        }

        [TestMethod]
        public void AllSidesAreEqualIsTrue()
        {
            Assert.IsTrue(Triangle.Triangle.CheckTheExistenceOfTriangle(3,3,3));
        }

        [TestMethod]
        public void ReactangularTriangleIsTrue()
        {
            Assert.IsTrue(Triangle.Triangle.CheckTheExistenceOfTriangle(3, 4, 5));
        }

        [TestMethod]
        public void OneSideIsMoreThanSumIsFalse()
        {
            Assert.IsFalse(Triangle.Triangle.CheckTheExistenceOfTriangle(3, 2, 1));
        }

        [TestMethod]
        public void OneSideIsMinusIsFalse()
        {
            Assert.IsFalse(Triangle.Triangle.CheckTheExistenceOfTriangle(3, -3, 3));
        }

        [TestMethod]
        public void AllSideIsZeroIsFalse()
        {
            Assert.IsFalse(Triangle.Triangle.CheckTheExistenceOfTriangle(3, 0, 3));
        }

        [TestMethod]
        public void AllSidesAreRightDoubleIsTrue()
        {
            Assert.IsTrue(Triangle.Triangle.CheckTheExistenceOfTriangle(1.5, 1.6, 2.1));
        }

        [TestMethod]
        public void AllSidesAreWrongDoubleIsFalse()
        {
            Assert.IsFalse(Triangle.Triangle.CheckTheExistenceOfTriangle(3.5, 1.4, 1.3));
        }
    }
}
