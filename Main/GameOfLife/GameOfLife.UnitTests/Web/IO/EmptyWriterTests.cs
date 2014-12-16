// <copyright file="EmptyWriterTests.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
// </copyright> 

namespace GameOfLife.UnitTests.Web.IO
{
    using System;
    using GameOfLife.Basics;
    using GameOfLife.Web.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Unit tests the EmptyWriter class from the GameOfLife.Web.IO namespace.
    /// </summary>
    [TestClass]
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