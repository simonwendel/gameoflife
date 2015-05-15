// <copyright file="LinqGameIntegration.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.IntegrationTests.LinqLife
{
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.Basics;
    using GameOfLife.Library.LifeForms;
    using GameOfLife.Library.Rules;
    using GameOfLife.LinqLife;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Does integration testing of rules, patterns and the LinqGame.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class LinqGameIntegration
    {
        /// <summary>
        /// Steps an empty universe once with the standard rules, which
        /// yield an empty universe when done.
        /// </summary>
        [TestMethod]
        public void StepEmptyUniverseForwardOneGenerationLinqGame()
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
        [TestMethod]
        public void StepFivePointForwardWithStandardRulesLinqGame()
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

        /// <summary>
        /// Runs the Acorn life form to stable population after 5206 gens.
        /// </summary>
        /// <remarks>
        /// This is ignored now, since the LinqLife performance is poor and
        /// the test takes 3 minutes to completion.
        /// </remarks>
        [TestMethod, Ignore]
        public void StabilizeAcornLifeFormLinqGame()
        {
            // arrange
            var pattern = new Acorn();
            var game = new LinqGame(Mock.Of<IFormatter>(), new StandardRules());
            game.InitializeFrom(pattern.GetPattern());

            // act
            game.RunThrough(pattern.StabilizesAt + 1);

            // assert
            Assert.AreEqual(
                expected: pattern.StablePopulation,
                actual: game.Population,
                message: "The universe does not contain exactly 4 cells.");

            Assert.AreEqual(
                expected: pattern.StabilizesAt + 1,
                actual: game.Generation,
                message: "The game did not progress by one generation.");
        }
    }
}

// eof
