// <copyright file="RandomPatternTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2016.
// </copyright>

namespace GameOfLife.Tests.Library.LifeForms
{
    using System.Linq;
    using GameOfLife.Library.LifeForms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the RandomPattern class from the GameOfLife.Library.LifeForms namespace.
    /// </summary>
    [TestClass]
    public class RandomPatternTests
    {
        /// <summary>
        /// Succeeds at creating a random pattern.
        /// </summary>
        [TestMethod]
        public void Constructor_WhenGivenDimensions_PreparesRandomPatternCorrectly()
        {
            // arrange
            int rows = 13;
            int cols = 44;

            // act
            var randomPattern = new RandomPattern(rows, cols);

            // assert
            Assert.AreEqual(
                expected: rows,
                actual: randomPattern.GetPattern().Length,
                message: "The number of rows were wrong.");

            Assert.IsTrue(
                randomPattern.GetPattern().All(x => x.Length == cols),
                message: "The number of columns were wrong somehow.");

            Assert.IsFalse(
                randomPattern.IsStable,
                message: "The pattern reports it's stable, which we can never know.");
        }
    }
}
