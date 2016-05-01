// <copyright file="GameBaseTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2016.
// </copyright>

namespace GameOfLife.Tests.Basics
{
    using System;
    using GameOfLife.Basics;
    using GameOfLife.Library.Rules;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Tests the abstract GameBase class from the GameOfLife.Basics
    /// namespace by creating a proxy test class.
    /// </summary>
    [TestClass]
    public class GameBaseTests
    {
        /// <summary>
        /// If passing a null reference RulesBase to the GameBase constructor
        /// it will throw an exception.
        /// </summary>
        [TestMethod]
        public void Constructor_GivenNullRules_ThrowsException()
        {
            // arrange
            TestGame game;

            // act:ish
            Action action = () => game = new TestGame(null);

            // assert
            AssertExtension.Throws<ArgumentNullException>(action);
        }

        /// <summary>
        /// The passed in RulesBase implementation is exposed to derived classes
        /// of GameBase correctly.
        /// </summary>
        [TestMethod]
        public void Rules_WhenAccessed_ReturnsObjectPassedToConstructor()
        {
            // arrange
            var rules = new StandardRules();
            var game = new TestGame(rules);

            // act
            var property = game.Rules;

            // assert
            Assert.AreSame(
                expected: rules,
                actual: property,
                message: "Wrong rules reference returned by property.");
        }

        /// <summary>
        /// The RunThrough method on all GamesBase derived classes correctly
        /// steps the game forward.
        /// </summary>
        [TestMethod]
        public void RunThrough_GivenInteger_StepsForwardInTime()
        {
            // arrange
            var game = new TestGame(new StandardRules());

            // act
            game.RunThrough(10);

            // assert
            Assert.AreEqual(
                expected: 10,
                actual: game.Generation,
                message: "Game did not step forward correctly.");
        }

        /// <summary>
        /// A test GamesBase derived class for checking base functionality.
        /// </summary>
        private class TestGame : GameBase
        {
            private int generation;

            public TestGame(RulesBase rules)
                : base(rules)
            {
                generation = 0;
            }

            public override int Generation
            {
                get { return generation; }
            }

            public override int Population
            {
                get { throw new NotImplementedException(); }
            }

            public new RulesBase Rules
            {
                get
                {
                    return base.Rules;
                }
            }

            public override void InitializeFrom(int[][] pattern)
            {
                throw new NotImplementedException();
            }

            public override void StepForward()
            {
                ++generation;
            }
        }
    }
}
