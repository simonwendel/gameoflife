// <copyright file="GameBaseTests.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
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
        public void RunThroughCorrectlyStepsForwardInTime()
        {
            // arrange
            var game = new TestGame(Mock.Of<IWriter>(), new StandardRules());

            // act
            game.RunThrough(10);

            // assert
            Assert.AreEqual(
                expected: 10,
                actual: game.Generation,
                message: "Game did not step forward correctly.");
        }

        /// <summary>
        /// If passing a null reference IWriter to the GameBase constructor it 
        /// will throw an exception.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Usage",
            "CA1806:DoNotIgnoreMethodResults",
            MessageId = "GameOfLife.UnitTests.Basics.GameBaseTests+TestGame",
            Justification = "The object can never be used, since we expect an exception.")]
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void GameBaseNullWriterToConstructorThrowsException()
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
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void GameBaseNullRulesToConstructorThrowsException()
        {
            // act
            new TestGame(Mock.Of<IWriter>(), null);
        }

        /// <summary>
        /// The passed in IWriter gets properly used by the GameBase WriteOut method.
        /// </summary>
        [TestMethod]
        public void GameBaseWriteOutMethodCorrectlyUsesWriter()
        {
            // arrange
            var mockWriter = new Mock<IWriter>();
            mockWriter
                .Setup(x => x.WriteOut(It.IsAny<GameBase>()));

            var game = new TestGame(mockWriter.Object, new StandardRules());

            // act
            game.WriteOut();

            // assert
            mockWriter.Verify(
                x => x.WriteOut(It.IsAny<GameBase>()),
                Times.Once());
        }

        /// <summary>
        /// The passed in RulesBase implementation is exposed to derived classes 
        /// of GameBase correctly.
        /// </summary>
        [TestMethod]
        public void GameBaseRulesProperlySet()
        {
            // arrange
            var rules = new StandardRules();
            var game = new TestGame(Mock.Of<IWriter>(), rules);

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
            /// <summary>The generation the game is at.</summary>
            private int generation;

            /// <summary>
            /// Initializes a new instance of the TestGame class.
            /// </summary>
            /// <param name="writer">The writer to write state to console.</param>
            /// <param name="rules">The rules for running the game.</param>
            public TestGame(IWriter writer, RulesBase rules)
                : base(writer, rules)
            {
                generation = 0;
            }

            /// <summary>
            /// Gets the population at the current time, which is always <value>0</value>.
            /// </summary>
            public override int Population
            {
                get { return 0; }
            }

            /// <summary>
            /// Gets the current generation.
            /// </summary>
            public override int Generation
            {
                get { return generation; }
            }

            /// <summary>
            /// Gets the otherwise hidden rules from the base class.
            /// </summary>
            public new RulesBase Rules
            {
                get
                {
                    return base.Rules;
                }
            }

            /// <summary>
            /// Steps the game one generation into the future.
            /// </summary>
            public override void StepForward()
            {
                ++generation;
            }

            /// <summary>
            /// Initializes the game from an integer pattern.
            /// </summary>
            /// <param name="pattern">An integer pattern, where <value>1</value> is a cell and 
            /// <value>0</value> is not.</param>
            public override void InitializeFrom(int[][] pattern)
            {
                throw new NotImplementedException();
            }
        }
    }
}

// eof