// <copyright file="EmptyWriterTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.WebServer.IO
{
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.WebServer.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the EmptyWriter class from the GameOfLife.WebServer.IO namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class EmptyWriterTests
    {
        /// <summary>
        /// When the WriteOut method is called, an empty string will be returned,
        /// regardless of the state of the game.
        /// </summary>
        [TestMethod]
        public void EmptyWriterReturnsEmptyString()
        {
            // arrange
            var target = new EmptyWriter();

            // act
            string results = target.WriteOut(null);

            // assert
            Assert.AreEqual(
                expected: string.Empty,
                actual: results,
                message: "The empty string was not returned.");
        }
    }
}

// eof
