﻿// <copyright file="StandardRulesTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.Library.Rules
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using GameOfLife.Library.Rules;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the standard set of rules (B3/S23) in the GameOfLife.Domain.Games namespace.
    /// </summary>
    /// <remarks>
    /// These tests might be overkill, but it's nice to know that expectations are met.
    /// </remarks>
    [TestClass, ExcludeFromCodeCoverage]
    public class StandardRulesTests
    {
        /// <summary>A constant representing a dead cell.</summary>
        private const bool DEAD = false;

        /// <summary>A constant representing a live cell.</summary>
        private const bool LIVE = true;

        /// <summary>The target to test.</summary>
        private StandardRules rules;

        /// <summary>
        /// Sets up the test fixture.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            rules = new StandardRules();
        }

        /// <summary>
        /// When the constructor of the StandardRules class is called, the survival count and
        /// birth count sequences are correctly initialized as per the "original" rules of
        /// Conway's Game of Life.
        /// </summary>
        [TestMethod]
        public void Constructor_WhenInvoked_PreparesStandardRulesCorrectly()
        {
            // arrange
            var birthCount = new[] { 3 };
            var survivalCount = new[] { 2, 3 };

            // assert
            Assert.IsTrue(
                rules.BirthCount.SequenceEqual(birthCount),
                message: "The birth count sequences was not equal.");

            Assert.IsTrue(
                rules.SurvivalCount.SequenceEqual(survivalCount),
                message: "The survival count sequences was not equal.");
        }

        /// <summary>
        /// Dead cell evaluated for number of neighbors n∈[0,8].
        /// </summary>
        [TestMethod]
        public void AliveNextGeneration_GivenDeadCell_ReturnsStateAccordingToStandard()
        {
            // arrange
            var expectedStates = new[]
            {
                DEAD,
                DEAD,
                DEAD,
                LIVE,
                DEAD,
                DEAD,
                DEAD,
                DEAD,
                DEAD
            };

            var states = new bool[9];

            // act
            for (int i = 0; i < 9; ++i)
            {
                states[i] = rules.AliveNextGeneration(DEAD, i);
            }

            // assert
            for (int i = 0; i < 9; ++i)
            {
                Assert.AreEqual(
                    expected: expectedStates[i],
                    actual: states[i],
                    message: "Rule yielded unexpected result as to whether the cell is alive or not.");
            }
        }

        /// <summary>
        /// Live cell evaluated for number of neighbors n∈[0,8].
        /// </summary>
        [TestMethod]
        public void AliveNextGeneration_GivenLiveCell_ReturnsStateAccordingToStandard()
        {
            // arrange
            var expectedStates = new[]
            {
                DEAD,
                DEAD,
                LIVE,
                LIVE,
                DEAD,
                DEAD,
                DEAD,
                DEAD,
                DEAD
            };

            var states = new bool[9];

            // act
            for (int i = 0; i < 9; ++i)
            {
                states[i] = rules.AliveNextGeneration(LIVE, i);
            }

            // assert
            for (int i = 0; i < 9; ++i)
            {
                Assert.AreEqual(
                    expected: expectedStates[i],
                    actual: states[i],
                    message: "Rule yielded unexpected result as to whether the cell is alive or not.");
            }
        }
    }
}

// eof
