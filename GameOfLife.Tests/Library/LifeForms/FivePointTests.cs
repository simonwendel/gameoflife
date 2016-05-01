// <copyright file="FivePointTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2016.
// </copyright>

namespace GameOfLife.Tests.Library.LifeForms
{
    using System.Linq;
    using GameOfLife.Library.LifeForms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the FivePoint class from the GameOfLife.Library.LifeForms namespace.
    /// </summary>
    [TestClass]
    public class FivePointTests
    {
        /// <summary>
        /// When the FivePoint class is instantiated all properties are set as
        /// per our expectations.
        /// </summary>
        [TestMethod]
        public void Constructor_WhenInvoked_PreparesFivePointCorrectly()
        {
            // act
            var fivePoint = new FivePoint();

            int oneSide = fivePoint.GetPattern().Length;
            int otherSide = fivePoint.GetPattern().Max(x => x.Length);

            // assert
            Assert.IsTrue(
                oneSide == 4 && oneSide == otherSide,
                message: "The five point pattern was not of size 4x4.");

            Assert.IsTrue(
                fivePoint.IsStable,
                message: "The five point pattern was not stable.");

            Assert.AreEqual(
                expected: 1,
                actual: fivePoint.StabilizesAt,
                message: "The five point pattern stabilizes at the wrong time.");

            Assert.AreEqual(
                expected: 4,
                actual: fivePoint.StablePopulation,
                message: "The five point pattern has wrong number of cells in the stable population.");
        }
    }
}
