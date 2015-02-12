// <copyright file="ConsoleStatWriterTests.cs" company="N/A"> 
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
    /// Unit tests the ConsoleStatWriter class from the GameOfLife.Application.IO namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ConsoleStatWriterTests
    {
        /// <summary>The target console stat writer to test.</summary>
        private StatWriter target;

        /// <summary>
        /// Sets up the test fixture.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            target = new StatWriter();
        }

        /// <summary>
        /// Passing a null reference game to the WriteOut method throws an exception.
        /// </summary>
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NullGameBaseToWriteOutThrowsException()
        {
            // act
            target.WriteOut(null);
        }

        /// <summary>
        /// Writing a game to console works.
        /// </summary>
        [TestMethod]
        public void WriteOutGameToConsoleSuccessfully()
        {
            // arrange
            var mockRules = new Mock<RulesBase>(new[] { 1 }, new[] { 2 });
            var mockGame = new Mock<GameBase>(
                Mock.Of<IWriter>(),
                mockRules.Object);

            mockGame.SetupGet(x => x.Generation).Returns(10);
            mockGame.SetupGet(x => x.Population).Returns(80);

            // act
            target.WriteOut(mockGame.Object);

            // assert
            mockGame.VerifyGet(
                x => x.Generation,
                Times.Once());

            mockGame.VerifyGet(
                x => x.Population,
                Times.Once());
        }
    }
}

// eof