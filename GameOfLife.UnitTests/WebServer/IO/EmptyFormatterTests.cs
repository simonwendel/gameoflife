﻿// <copyright file="EmptyFormatterTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.WebServer.IO
{
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.WebServer.IO;
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
        public void EmptyFormatterReturnsEmptyString()
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

// eof