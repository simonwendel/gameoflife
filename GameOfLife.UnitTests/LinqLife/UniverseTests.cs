// <copyright file="UniverseTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.LinqLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameOfLife.Library.LifeForms;
    using GameOfLife.LinqLife;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the Universe class from the GameOfLife.LinqLife namespace.
    /// </summary>
    [TestClass]
    public class UniverseTests
    {
        /// <summary>The target Universe object to unit test.</summary>
        private Universe universe;

        /// <summary>
        /// Adding cell at a location works.
        /// </summary>
        [TestMethod]
        public void Add_GivenCoordinates_AddsCellAndReturnsTrue()
        {
            // act
            bool addWorked = universe.Add(12, 23);

            // assert
            Assert.IsTrue(
                addWorked,
                message: "The add operation failed.");

            Assert.AreEqual(
                expected: 1,
                actual: universe.Population,
                message: "The universe population did not increase to exactly 1.");

            Assert.IsTrue(
                universe.HasCell(12, 23),
                message: "No cell found at coordinates.");
        }

        /// <summary>
        /// Adding a second cell at the same location where another cell already
        /// exists fails, and the AddAt returns <value>false</value>.
        /// </summary>
        [TestMethod]
        public void Add_GivenSameCoordinatesTwice_DoesNotAddCellAndReturnsFalse()
        {
            // act
            universe.Add(12, 23);
            bool addWorked = universe.Add(12, 23);

            // assert
            Assert.IsFalse(
                addWorked,
                message: "The add operation succeeded.");

            Assert.AreEqual(
                expected: 1,
                actual: universe.Population,
                message: "The universe population did not increase to exactly 1.");

            Assert.IsTrue(
                universe.HasCell(12, 23),
                message: "No cell found at coordinates.");
        }

        /// <summary>
        /// When passed a pattern where all columns are not of equal height, that is the pattern is
        /// not perfectly rectangular, the Universe constructor will throw an exception.
        /// </summary>
        [TestMethod]
        public void Constructor_GivenIrregularPattern_ThrowsException()
        {
            // arrange
            var pattern = new int[][]
            {
                new[] { 1, 2 },
                new[] { 2, 3, 5 },
                new[] { 0 }
            };

            // act:ish
            Action action = () => universe = new Universe(pattern);

            // assert
            AssertExtension.Throws<ArgumentException>(action);
        }

        /// <summary>
        /// When the Universe pattern constructor is passed a null pattern,
        /// it will throw an exception.
        /// </summary>
        [TestMethod]
        public void Constructor_GivenNullPattern_ThrowsException()
        {
            // act:ish
            Action action = () => universe = new Universe(pattern: null);

            // assert
            AssertExtension.Throws<ArgumentNullException>(action);
        }

        /// <summary>
        /// When the Universe copy constructor is passed a null universe to copy,
        /// it will throw an exception.
        /// </summary>
        [TestMethod]
        public void Constructor_GivenNullSourceUniverse_ThrowsException()
        {
            // act:ish
            Action action = () => universe = new Universe(source: null);

            // assert
            AssertExtension.Throws<ArgumentNullException>(action);
        }

        /// <summary>
        /// The universe correctly initializes from an integer pattern.
        /// </summary>
        [TestMethod]
        public void Constructor_GivenPattern_PreparesUniverseCorrectly()
        {
            // arrange
            var pattern = new FivePoint();

            // act
            var target = new Universe(pattern.GetPattern());

            // assert
            Assert.AreEqual(
                expected: 5,
                actual: target.Population,
                message: "The universe population was not initialized correctly.");

            Assert.IsTrue(
                target.HasCell(0, 1),
                message: "An expected cell was not found.");

            Assert.IsTrue(
                target.HasCell(0, 3),
                message: "An expected cell was not found.");

            Assert.IsTrue(
                target.HasCell(1, 2),
                message: "An expected cell was not found.");

            Assert.IsTrue(
                target.HasCell(2, 1),
                message: "An expected cell was not found.");

            Assert.IsTrue(
                target.HasCell(2, 3),
                message: "An expected cell was not found.");
        }

        /// <summary>
        /// When passed a proper source universe to copy, the copy constructor initializes the
        /// universe properly.
        /// </summary>
        [TestMethod]
        public void Constructor_GivenSourceUniverse_PreparesCopy()
        {
            // arrange
            var pattern = new FivePoint();
            var other = new Universe(pattern.GetPattern());

            // act
            var copy = new Universe(other);

            // assert
            Assert.AreEqual(
                expected: 5,
                actual: copy.Population,
                message: "The universe population was not initialized correctly.");

            Assert.IsTrue(
                copy.HasCell(0, 1),
                message: "An expected cell was not found.");

            Assert.IsTrue(
                copy.HasCell(0, 3),
                message: "An expected cell was not found.");

            Assert.IsTrue(
                copy.HasCell(1, 2),
                message: "An expected cell was not found.");

            Assert.IsTrue(
                copy.HasCell(2, 1),
                message: "An expected cell was not found.");

            Assert.IsTrue(
                copy.HasCell(2, 3),
                message: "An expected cell was not found.");
        }

        /// <summary>
        /// When passed in a zero height pattern, the Universe constructor throws an exception.
        /// </summary>
        [TestMethod]
        public void Constructor_GivenZeroHeightPattern_ThrowsException()
        {
            // arrange
            var pattern = new int[][] { new int[] { } };

            // act:ish
            Action action = () => universe = new Universe(pattern);

            // assert
            AssertExtension.Throws<ArgumentException>(action);
        }

        /// <summary>
        /// When passed in a zero width pattern, the Universe constructor throws an exception.
        /// </summary>
        [TestMethod]
        public void Constructor_GivenZeroWidthPattern_ThrowsException()
        {
            // arrange
            var pattern = new int[][] { };

            // act:ish
            Action action = () => universe = new Universe(pattern);

            // assert
            AssertExtension.Throws<ArgumentException>(action);
        }

        /// <summary>
        /// The universe correctly returns all neighbors to a location.
        /// </summary>
        [TestMethod]
        public void ListNeighbors_GivenLocationWithEightCellsBordering_ReturnsEightCellList()
        {
            // arrange
            var expectedNeighbors = new List<Cell>();

            for (int x = 0; x < 3; ++x)
            {
                for (int y = 0; y < 3; ++y)
                {
                    if (x != 1 || y != 1)
                    {
                        expectedNeighbors.Add(new Cell(x, y));
                    }

                    universe.Add(x, y);
                }
            }

            // act
            IEnumerable<Cell> neighbors = universe.ListNeighbors(1, 1);

            // assert
            Assert.AreEqual(
                expected: 8,
                actual: neighbors.Count(),
                message: "The cell did not have exactly 8 neighbors.");

            foreach (var cell in expectedNeighbors)
            {
                Assert.IsTrue(
                    neighbors.Contains(cell),
                    message: "An expected cell was not returned in all neighbors collection.");
            }
        }

        /// <summary>
        /// The universe correctly counts the number of neighbors to some location.
        /// </summary>
        [TestMethod]
        public void Neighbors_GivenLocationWithEightCellsBordering_ReturnsEight()
        {
            // arrange
            for (int x = 0; x < 3; ++x)
            {
                for (int y = 0; y < 3; ++y)
                {
                    universe.Add(x, y);
                }
            }

            // act
            int neighbors = universe.Neighbors(1, 1);

            // assert
            Assert.AreEqual(
                expected: 8,
                actual: neighbors,
                message: "The cell did not have exactly 8 neighbors.");
        }

        /// <summary>
        /// The universe correctly counts the number of neighboring cells
        /// to some location.
        /// </summary>
        [TestMethod]
        public void Neighbors_GivenLocationWithThreeCellsBordering_ReturnsThree()
        {
            // arrange
            universe.Add(1, 1);
            universe.Add(2, 2);
            universe.Add(2, 0);

            // act
            int neighbors = universe.Neighbors(2, 1);

            // assert
            Assert.AreEqual(
                expected: 3,
                actual: neighbors,
                message: "The cell did not have exactly 3 neighbors.");
        }

        /// <summary>
        /// The universe is empty on creation.
        /// </summary>
        [TestMethod]
        public void Population_WhenInvokedOnNewUniverse_ReturnsZero()
        {
            // act
            int population = universe.Population;

            // assert
            Assert.AreEqual(
                expected: 0,
                actual: population,
                message: "The universe was not empty.");
        }

        /// <summary>
        /// Sets up the test fixture.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            universe = new Universe();
        }
    }
}
