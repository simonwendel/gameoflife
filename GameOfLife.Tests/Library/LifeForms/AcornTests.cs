// <copyright file="AcornTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Tests.Library.LifeForms
{
    using System.Linq;
    using GameOfLife.Library.LifeForms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the Acorn class from the GameOfLife.Library.LifeForms namespace.
    /// </summary>
    [TestClass]
    public class AcornTests
    {
        /// <summary>
        /// The acorn initial pattern is correctly constructed.
        /// </summary>
        [TestMethod]
        public void Constructor_WhenInvoked_PreparesAcornCorrectly()
        {
            // act
            var acorn = new Acorn();

            int oneSide = acorn.GetPattern().Length;
            int otherSide = acorn.GetPattern().Max(x => x.Length);

            // assert
            Assert.IsTrue(
                oneSide == 8 && oneSide == otherSide,
                message: "The acorn pattern was not of size 8x8.");

            Assert.IsTrue(
                acorn.IsStable,
                message: "The acorn pattern was not stable.");

            Assert.AreEqual(
                expected: 5206,
                actual: acorn.StabilizesAt,
                message: "The acorn pattern stabilizes at the wrong time.");

            Assert.AreEqual(
                expected: 633,
                actual: acorn.StablePopulation,
                message: "The acorn pattern has wrong number of cells in the stable population.");
        }
    }
}
