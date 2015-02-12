﻿// <copyright file="LinqGameTests.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.UnitTests.LinqLife
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.Basics;
    using GameOfLife.Library.LifeForms;
    using GameOfLife.LinqLife;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Unit tests the LinqGame class from the GameOfLife.LinqLife namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class LinqGameTests
    {
        /// <summary>
        /// The LinqGame class constructs properly and starts with an empty 
        /// universe at generation zero.
        /// </summary>
        [TestMethod]
        public void LinqGameConstructsProperly()
        {
            // arrange
            var mockRules = new Mock<RulesBase>(new[] { 1 }, new[] { 2 });

            // act
            var game = new LinqGame(Mock.Of<IWriter>(), mockRules.Object);

            // assert
            Assert.AreEqual(
                expected: 0,
                actual: game.Population,
                message: "The initial population was not exactly zero.");

            Assert.AreEqual(
                expected: 0,
                actual: game.Generation,
                message: "The game did not start at generation zero.");
        }

        /// <summary>
        /// LinqGame correctly initializes from an integer pattern.
        /// </summary>
        [TestMethod]
        public void LinqGameInitializesFromIntegerPatternCorrectly()
        {
            // arrange
            var mockRules = new Mock<RulesBase>(new[] { 1 }, new[] { 2 });
            var game = new LinqGame(Mock.Of<IWriter>(), mockRules.Object);
            var pattern = new FivePoint();

            // act
            game.InitializeFrom(pattern.GetPattern());

            // assert
            Assert.AreEqual(
                expected: 5,
                actual: game.Population,
                message: "The universe population was not initialized correctly.");
        }

        /// <summary>
        /// When passed a null integer pattern to the InitializeFrom method, the 
        /// LinqGame will throw an exception.
        /// </summary>
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void LinqGamePassedNullInitializationPatternThrowsException()
        {
            // arrange
            var mockRules = new Mock<RulesBase>(new[] { 1 }, new[] { 2 });
            var game = new LinqGame(Mock.Of<IWriter>(), mockRules.Object);

            // act
            game.InitializeFrom(null);
        }
    }
}

// eof