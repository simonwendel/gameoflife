// <copyright file="LinqGameIntegrationTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Tests.LinqLife
{
    using GameOfLife.Basics;
    using GameOfLife.Library.LifeForms;
    using GameOfLife.Library.Rules;
    using GameOfLife.LinqLife;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Does integration testing of rules, patterns and the LinqGame.
    /// </summary>
    [TestClass]
    public class LinqGameIntegrationTests
    {
        /// <summary>
        /// Steps an empty universe once with the standard rules, which
        /// yield an empty universe when done.
        /// </summary>
        [TestCategory(TestType.IntegrationTest)]
        [TestMethod]
        public void StepForward_GivenEmptyUniverse_ResultsInEmptyUniverse()
        {
            // arrange
            var game = new LinqGame(Mock.Of<IFormatter>(), new StandardRules());

            // act
            game.StepForward();

            // assert
            Assert.AreEqual(
                expected: 0,
                actual: game.Population,
                message: "The universe is not empty.");

            Assert.AreEqual(
                expected: 1,
                actual: game.Generation,
                message: "The game did not progress by one generation.");
        }

        /// <summary>
        /// Steps a FivePoint pattern one step forward, so it reaches
        /// it's stable population of 4 cells.
        /// </summary>
        [TestCategory(TestType.IntegrationTest)]
        [TestMethod]
        public void StepForward_GivenFivePoint_ResultsInPopulationOfFour()
        {
            // arrange
            var pattern = new FivePoint();
            var game = new LinqGame(Mock.Of<IFormatter>(), new StandardRules());
            game.InitializeFrom(pattern.GetPattern());

            // act
            game.StepForward();

            // assert
            Assert.AreEqual(
                expected: 4,
                actual: game.Population,
                message: "The universe does not contain exactly 4 cells.");

            Assert.AreEqual(
                expected: 1,
                actual: game.Generation,
                message: "The game did not progress by one generation.");
        }
    }
}
