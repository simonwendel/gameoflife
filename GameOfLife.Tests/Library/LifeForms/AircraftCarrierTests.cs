// <copyright file="AircraftCarrierTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Tests.Library.LifeForms
{
    using System.Linq;
    using GameOfLife.Library.LifeForms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests the AircraftCarrier class from the GameOfLife.Library.LifeForms namespace.
    /// </summary>
    [TestClass]
    public class AircraftCarrierTests
    {
        /// <summary>
        /// The aircraft carrier initial pattern is correctly constructed.
        /// </summary>
        [TestMethod]
        public void Constructor_WhenInvoked_PreparesAircraftCarrierCorrectly()
        {
            // act
            var carrier = new AircraftCarrier();

            int oneSide = carrier.GetPattern().Length;
            int otherSide = carrier.GetPattern().Max(x => x.Length);

            // assert
            Assert.IsTrue(
                oneSide == 4 && oneSide == otherSide,
                message: "The aircraft carrier pattern was not of size 4x4.");

            Assert.IsTrue(
                carrier.IsStable,
                message: "The aircraft carrier pattern was not stable.");

            Assert.AreEqual(
                expected: 0,
                actual: carrier.StabilizesAt,
                message: "The aircraft carrier pattern stabilizes at the wrong time.");

            Assert.AreEqual(
                expected: 6,
                actual: carrier.StablePopulation,
                message: "The aircraft carrier pattern has wrong number of cells in the stable population.");
        }
    }
}
