// <copyright file="CellTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.Basics
{
    using GameOfLife.Basics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the Cell class from the GameOfLife.Basics namespace.
    /// </summary>
    [TestClass]
    public class CellTests
    {
        /// <summary>
        /// Cells in the game constructs properly,
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

        /// <summary>
        /// Two Cell structs where the coordinate properties does not match
        /// are not considered equal.
        /// </summary>
        [TestMethod]
        public void ObjectEquals_GivenCellWithNotSameCoordinates_ReturnsFalse()
        {
            // arrange
            var cell1 = new Cell(3, 4);
            object cell2 = new Cell(4, 3);

            // assert
            Assert.IsFalse(
                cell1.Equals(cell2),
                message: "The cells were equal.");
        }

        /// <summary>
        /// Given an object that is of the wrong type, the object.Equals method
        /// returns false.
        /// </summary>
        [TestMethod]
        public void ObjectEquals_GivenCellWithNotSameType_ReturnsFalse()
        {
            // arrange
            var cell = new Cell(3, 4);
            var notACell = new object();

            // assert
            Assert.IsFalse(
                cell.Equals(notACell),
                message: "The objects were equal.");
        }

        /// <summary>
        /// Two Cell structs with the same coordinates are considered equal.
        /// </summary>
        [TestMethod]
        public void ObjectEquals_GivenCellWithSameCoordinates_ReturnsTrue()
        {
            // arrange
            var cell1 = new Cell(3, 4);
            object cell2 = new Cell(y: 4, x: 3);

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
        public void OperatorEquals_GivenCellWithNotSameCoordinates_ReturnsFalse()
        {
            // arrange
            var cell1 = new Cell(3, 4);
            var cell2 = new Cell(4, 3);

            // assert
            Assert.IsFalse(
                cell1 == cell2,
                message: "The cells were equal.");
        }

        /// <summary>
        /// Two Cell structs with the same coordinates are considered equal.
        /// </summary>
        [TestMethod]
        public void OperatorEquals_GivenCellWithSameCoordinates_ReturnsTrue()
        {
            // arrange
            var cell1 = new Cell(3, 4);
            var cell2 = new Cell(y: 4, x: 3);

            // assert
            Assert.IsTrue(
                cell1 == cell2,
                message: "The cells were not equal.");
        }

        /// <summary>
        /// Two Cell structs where the coordinate properties does not match
        /// are not considered equal.
        /// </summary>
        [TestMethod]
        public void OperatorNotEquals_GivenCellWithNotSameCoordinates_ReturnsTrue()
        {
            // arrange
            var cell1 = new Cell(3, 4);
            var cell2 = new Cell(4, 3);

            // assert
            Assert.IsTrue(
                cell1 != cell2,
                message: "The cells were equal.");
        }

        /// <summary>
        /// Two Cell structs with the same coordinates are considered equal.
        /// </summary>
        [TestMethod]
        public void OperatorNotEquals_GivenCellWithSameCoordinates_ReturnsFalse()
        {
            // arrange
            var cell1 = new Cell(3, 4);
            var cell2 = new Cell(y: 4, x: 3);

            // assert
            Assert.IsFalse(
                cell1 != cell2,
                message: "The cells were not equal.");
        }
    }
}
