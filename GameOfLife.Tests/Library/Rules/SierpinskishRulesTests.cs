// <copyright file="SierpinskishRulesTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2016.
// </copyright>

namespace GameOfLife.Tests.Library.Rules
{
    using System.Linq;
    using GameOfLife.Library.Rules;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the Sierpinskish rules (B1/S12) in the GameOfLife.Domain.Games namespace.
    /// </summary>
    /// <remarks>
    /// These tests might be overkill, but it's nice to know.
    /// </remarks>
    [TestClass]
    public class SierpinskishRulesTests
    {
        /// <summary>A constant representing a dead cell.</summary>
        private const bool DEAD = false;

        /// <summary>A constant representing a live cell.</summary>
        private const bool LIVE = true;

        /// <summary>The target to test.</summary>
        private SierpinskishRules rules;

        /// <summary>
        /// Sets up the test fixture.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            rules = new SierpinskishRules();
        }

        /// <summary>
        /// Dead cell evaluated for number of neighbors n∈[0,8].
        /// </summary>
        [TestMethod]
        public void AliveNextGeneration_GivenDeadCell_ReturnsStateAccordingToSierpinskish()
        {
            // arrange
            var expectedStates = new[]
            {
                DEAD,
                LIVE,
                DEAD,
                DEAD,
                DEAD,
                DEAD,
                DEAD,
                DEAD,
                DEAD
            };

            var states = new bool[9];

            // act
            for (int n = 0; n < 9; ++n)
            {
                states[n] = rules.AliveNextGeneration(DEAD, n);
            }

            // assert
            for (int n = 0; n < 9; ++n)
            {
                Assert.AreEqual(
                    expected: expectedStates[n],
                    actual: states[n],
                    message: "Rule yielded unexpected result as to whether the cell is alive or not.");
            }
        }

        /// <summary>
        /// Live cell evaluated for number of neighbors n∈[0,8].
        /// </summary>
        [TestMethod]
        public void AliveNextGeneration_GivenLiveCell_ReturnsStateAccordingToSierpinskish()
        {
            // arrange
            var expectedStates = new[]
            {
                DEAD,
                LIVE,
                LIVE,
                DEAD,
                DEAD,
                DEAD,
                DEAD,
                DEAD,
                DEAD
            };

            var states = new bool[9];

            // act
            for (int n = 0; n < 9; ++n)
            {
                states[n] = rules.AliveNextGeneration(LIVE, n);
            }

            // assert
            for (int n = 0; n < 9; ++n)
            {
                Assert.AreEqual(
                    expected: expectedStates[n],
                    actual: states[n],
                    message: "Rule yielded unexpected result as to whether the cell is alive or not.");
            }
        }

        /// <summary>
        /// When the constructor of the SierpinskishRules class is called, the survival count and
        /// birth count sequences are correctly initialized so the game will evolve into four close
        /// approximations to the Sierpiński triangle when applied on 1 living cell.
        /// </summary>
        [TestMethod]
        public void Constructor_WhenInvoked_PreparesSierpinskishRulesCorrectly()
        {
            // arrange
            var birthCount = new[] { 1 };
            var survivalCount = new[] { 1, 2 };

            // assert
            Assert.IsTrue(
                rules.BirthCount.SequenceEqual(birthCount),
                message: "The birth count sequences was not equal.");

            Assert.IsTrue(
                rules.SurvivalCount.SequenceEqual(survivalCount),
                message: "The survival count sequences was not equal.");
        }
    }
}
