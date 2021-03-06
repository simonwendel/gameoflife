﻿// <copyright file="EmptyTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2016.
// </copyright>

namespace GameOfLife.Tests.Library.LifeForms
{
    using System.Linq;
    using GameOfLife.Library.LifeForms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the Empty class from the GameOfLife.Library.LifeForms namespace.
    /// </summary>
    [TestClass]
    public class EmptyTests
    {
        /// <summary>
        /// The empty universe pattern is correctly constructed.
        /// </summary>
        [TestMethod]
        public void Constructor_WhenInvoked_PreparesEmptyPatternCorrectly()
        {
            // act
            var empty = new Empty();

            int oneSide = empty.GetPattern().Length;
            int otherSide = empty.GetPattern().Max(x => x.Length);

            // assert
            Assert.IsTrue(
                oneSide == 1 && oneSide == otherSide,
                message: "The empty pattern was not of size 1x1.");

            Assert.IsTrue(
                empty.IsStable,
                message: "The empty pattern was not stable.");

            Assert.AreEqual(
                expected: 0,
                actual: empty.StabilizesAt,
                message: "The empty pattern stabilizes at the wrong time.");

            Assert.AreEqual(
                expected: 0,
                actual: empty.StablePopulation,
                message: "The empty pattern has wrong number of cells in the stable population.");
        }
    }
}
