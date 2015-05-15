// <copyright file="GameBaseTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.Basics
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.Basics;
    using GameOfLife.Library.Rules;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Tests the abstract GameBase class from the GameOfLife.Basics
    /// namespace by creating a proxy test class.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class GameBaseTests
    {
        /// <summary>
        /// The RunThrough method on all GamesBase derived classes correctly
        /// steps the game forward.
        /// </summary>
        [TestMethod]
        public void RunThrough_GivenInteger_StepsForwardInTime()
        {
            // arrange
            var game = new TestGame(Mock.Of<IFormatter>(), new StandardRules());

            // act
            game.RunThrough(10);

            // assert
            Assert.AreEqual(
                expected: 10,
                actual: game.Generation,
                message: "Game did not step forward correctly.");
        }

        /// <summary>
        /// If passing a null reference IFormatter to the GameBase constructor it
        /// will throw an exception.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA1806:DoNotIgnoreMethodResults",
            MessageId = "GameOfLife.UnitTests.Basics.GameBaseTests+TestGame",
            Justification = "The object can never be used, since we expect an exception.")]
        [TestMethod]
        [ExpectedException(
            typeof(ArgumentNullException))]
        public void Constructor_GivenNullFormatter_ThrowsException()
        {
            // act
            new TestGame(null, new StandardRules());
        }

        /// <summary>
        /// If passing a null reference RulesBase to the GameBase constructor
        /// it will throw an exception.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA1806:DoNotIgnoreMethodResults",
            MessageId = "GameOfLife.UnitTests.Basics.GameBaseTests+TestGame",
            Justification = "The object can never be used, since we expect an exception.")]
        [TestMethod]
        [ExpectedException(
            typeof(ArgumentNullException))]
        public void Constructor_GivenNullRules_ThrowsException()
        {
            // act
            new TestGame(Mock.Of<IFormatter>(), null);
        }

        /// <summary>
        /// The passed in IFormatter gets properly used by the GameBase WriteOut method.
        /// </summary>
        [TestMethod]
        public void WriteOut_WhenInvoked_UsesFormatterInstance()
        {
            // arrange
            var mockFormatter = new Mock<IFormatter>();
            mockFormatter
                .Setup(x => x.Format(It.IsAny<GameBase>()));

            var game = new TestGame(mockFormatter.Object, new StandardRules());

            // act
            game.WriteOut();

            // assert
            mockFormatter.Verify(
                x => x.Format(It.IsAny<GameBase>()),
                Times.Once());
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
            var game = new TestGame(Mock.Of<IFormatter>(), rules);

            // act
            var property = game.Rules;

            // assert
            Assert.AreSame(
                expected: rules,
                actual: property,
                message: "Wrong rules reference returned by property.");
        }

        /// <summary>
        /// A test GamesBase derived class for checking base functionality.
        /// </summary>
        private class TestGame : GameBase
        {
            private int generation;

            public TestGame(IFormatter formatter, RulesBase rules)
                : base(formatter, rules)
            {
                generation = 0;
            }

            public override int Population
            {
                get { return 0; }
            }

            public override int Generation
            {
                get { return generation; }
            }

            public new RulesBase Rules
            {
                get
                {
                    return base.Rules;
                }
            }

            public override void StepForward()
            {
                ++generation;
            }

            public override void InitializeFrom(int[][] pattern)
            {
                throw new NotImplementedException();
            }
        }
    }
}
