// <copyright file="LinqGameIntegrationTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Tests.LinqLife
{
    using System;
    using System.Linq;
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
            var game = new LinqGame(new StandardRules());

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
            var game = new LinqGame(new StandardRules());
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

        /// <summary>
        /// Steps a FivePoint pattern one step forward, so it reaches
        /// it's stable population of 4 cells and checks the step event info.
        /// </summary>
        [TestCategory(TestType.IntegrationTest)]
        [TestMethod]
        public void StepForward_GivenFivePointAndEventHandler_ResultsInPopulationOfFourAndFiveRemoved()
        {
            // arrange
            var pattern = new FivePoint();
            var game = new LinqGame(new StandardRules());

            object sender = null;
            GameStepEventArgs eventArgs = null;
            EventHandler<GameStepEventArgs> handler = (object s, GameStepEventArgs e) =>
                {
                    sender = s;
                    eventArgs = e;
                };

            game.InitializeFrom(pattern.GetPattern());
            game.GameStepEvent += handler;

            // act
            game.StepForward();

            // assert
            Assert.AreEqual(
                expected: 4,
                actual: game.Population,
                message: "The universe does not contain exactly 4 cells.");

            Assert.AreSame(
                expected: game,
                actual: sender,
                message: "Incorrect sender reference in event handler.");

            Assert.AreEqual(
                expected: 5,
                actual: eventArgs.DeadCells.Count(),
                message: "The set of removed cells does not contain exactly 5 cells.");

            Assert.AreEqual(
                expected: 4,
                actual: eventArgs.NewCells.Count(),
                message: "The set of added cells does not contain exactly 4 cells.");
        }
    }
}
