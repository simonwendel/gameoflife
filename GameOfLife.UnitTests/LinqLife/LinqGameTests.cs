// <copyright file="LinqGameTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.LinqLife
{
    using System;
    using GameOfLife.Basics;
    using GameOfLife.Library.LifeForms;
    using GameOfLife.LinqLife;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Unit tests the LinqGame class from the GameOfLife.LinqLife namespace.
    /// </summary>
    [TestClass]
    public class LinqGameTests
    {
        /// <summary>
        /// The LinqGame class constructs properly and starts with an empty
        /// universe at generation zero.
        /// </summary>
        [TestMethod]
        public void Constructor_WhenInvoked_PreparesLinqGameCorrectly()
        {
            // arrange
            var mockRules = new Mock<RulesBase>(new[] { 1 }, new[] { 2 });

            // act
            var game = new LinqGame(Mock.Of<IFormatter>(), mockRules.Object);

            // assert
            Assert.AreEqual(
                expected: 0,
                actual: game.Population,
                message: "The initial population was not exactly zero.");

            Assert.AreEqual(
                expected: 0,
                actual: game.Generation,
                message: "The game did not start at generation zero.");
        }

        /// <summary>
        /// LinqGame correctly initializes from an integer pattern.
        /// </summary>
        [TestMethod]
        public void InitializeFrom_GivenPattern_InitializesGameCorrectly()
        {
            // arrange
            var mockRules = new Mock<RulesBase>(new[] { 1 }, new[] { 2 });
            var game = new LinqGame(Mock.Of<IFormatter>(), mockRules.Object);
            var pattern = new FivePoint();

            // act
            game.InitializeFrom(pattern.GetPattern());

            // assert
            Assert.AreEqual(
                expected: 5,
                actual: game.Population,
                message: "The universe population was not initialized correctly.");
        }

        /// <summary>
        /// When passed a null integer pattern to the InitializeFrom method, the
        /// LinqGame will throw an exception.
        /// </summary>
        [TestMethod]
        public void InitializeFrom_GivenNullPattern_ThrowsException()
        {
            // arrange
            var mockRules = new Mock<RulesBase>(new[] { 1 }, new[] { 2 });
            var game = new LinqGame(Mock.Of<IFormatter>(), mockRules.Object);

            // act:ish
            Action action = () => game.InitializeFrom(null);

            // assert
            AssertExtension.Throws<ArgumentNullException>(action);
        }
    }
}
