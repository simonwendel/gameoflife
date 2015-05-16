// <copyright file="CellTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.LinqLife
{
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.LinqLife;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the Cell class from the GameOfLife.LinqLife namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class CellTests
    {
        /// <summary>
        /// Cells in the Linq version of the game constructs properly,
        /// setting the coordinate properties as expected.
        /// </summary>
        [TestMethod]
        public void Constructor_GivenCoordinates_PreparesCellCorrectly()
        {
            // act
            var cell = new Cell(x: 1, y: 2);

            // assert
            Assert.AreEqual(
                expected: 1,
                actual: cell.X,
                message: "The x-coordinate did not initialize properly.");

            Assert.AreEqual(
                expected: 2,
                actual: cell.Y,
                message: "The Y-coordinate did not initialize properly.");
        }

        /// <summary>
        /// Two Cell structs with the same coordinates are considered equal.
        /// </summary>
        [TestMethod]
        public void Equals_GivenCellWithSameCoordinates_ReturnsTrue()
        {
            // arrange
            var cell1 = new Cell(3, 4);
            var cell2 = new Cell(y: 4, x: 3);

            // assert
            Assert.IsTrue(
                cell1.Equals(cell2),
                message: "The cells were not equal.");
        }

        /// <summary>
        /// Two Cell structs where the coordinate properties does not match
        /// are not considered equal.
        /// </summary>
        [TestMethod]
        public void Equals_GivenCellWithNotSameCoordinates_ReturnsFalse()
        {
            // arrange
            var cell1 = new Cell(3, 4);
            var cell2 = new Cell(4, 3);

            // assert
            Assert.IsFalse(
                cell1.Equals(cell2),
                message: "The cells were equal.");
        }

        /// <summary>
        /// The GetHashCode of the Cell class works as expected.
        /// </summary>
        [TestMethod]
        public void GetHashCode_WhenInvoked_ReturnsCorrectHashCode()
        {
            // arrange
            var cell = new Cell(1, 2);
            int expectedHash = (((269 * 47) + 1.GetHashCode()) * 47) + 2.GetHashCode();

            // act
            int hash = cell.GetHashCode();

            // assert
            Assert.AreEqual(
                expected: expectedHash,
                actual: hash,
                message: "The expected hash was not returned.");
        }
    }
}
