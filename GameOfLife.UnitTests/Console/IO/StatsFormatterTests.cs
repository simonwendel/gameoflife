// <copyright file="StatsFormatterTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.Console.IO
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.Basics;
    using GameOfLife.Console.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Unit tests the StatsFormatter class from the GameOfLife.Application.IO namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class StatsFormatterTests
    {
        /// <summary>The target stats formatter to test.</summary>
        private StatsFormatter target;

        /// <summary>
        /// Sets up the test fixture.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            target = new StatsFormatter();
        }

        /// <summary>
        /// Passing a null reference game to the Format method throws an exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(
            typeof(ArgumentNullException))]
        public void Format_GivenNullGameBase_ThrowsException()
        {
            // act
            target.Format(null);
        }

        /// <summary>
        /// Formatting a game to works.
        /// </summary>
        [TestMethod]
        public void Format_GivenGameBase_ReturnsFormattedString()
        {
            // arrange
            var mockRules = new Mock<RulesBase>(new[] { 1 }, new[] { 2 });
            var mockGame = new Mock<GameBase>(
                Mock.Of<IFormatter>(),
                mockRules.Object);

            mockGame.SetupGet(x => x.Generation).Returns(10);
            mockGame.SetupGet(x => x.Population).Returns(80);

            // act
            var actual = target.Format(mockGame.Object);

            // assert
            mockGame.VerifyGet(
                x => x.Generation,
                Times.Once());

            mockGame.VerifyGet(
                x => x.Population,
                Times.Once());

            Assert.AreNotEqual(string.Empty, actual);
        }
    }
}

// eof
