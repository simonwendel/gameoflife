// <copyright file="EmptyFormatterTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.Webserver.IO
{
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.Webserver.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the EmptyFormatter class from the GameOfLife.WebServer.IO namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class EmptyFormatterTests
    {
        /// <summary>
        /// When the Format method is called, an empty string will be returned,
        /// regardless of the state of the game.
        /// </summary>
        [TestMethod]
        public void Format_WhenInvoked_ReturnsEmptyString()
        {
            // arrange
            var target = new EmptyFormatter();

            // act
            string results = target.Format(null);

            // assert
            Assert.AreEqual(
                expected: string.Empty,
                actual: results,
                message: "The empty string was not returned.");
        }
    }
}
