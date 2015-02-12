// <copyright file="SierpinskishRulesConstructorTests.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.UnitTests.Library.Rules
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using GameOfLife.Library.Rules;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// For code coverage completeness, this runs unit tests on the constructor for the 
    /// SierpinskishRules class from the GameOfLife.Domain.Game namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class SierpinskishRulesConstructorTests
    {
        /// <summary>
        /// When the constructor of the SierpinskishRules class is called, the survival count and 
        /// birth count sequences are correctly initialized so the game will evolve into four close 
        /// approximations to the Sierpiński triangle when applied on 1 living cell.
        /// </summary>
        [TestMethod]
        public void TheSierpinskishRulesConstructorInitializesCorrectly()
        {
            // arrange
            var birthCount = new[] { 1 };
            var survivalCount = new[] { 1, 2 };

            // act
            var rules = new SierpinskishRules();

            // assert
            Assert.IsTrue(
                rules.BirthCount.SequenceEqual(birthCount),
                message: "The birth count sequences was not equal.");

            Assert.IsTrue(
                rules.SurvivalCount.SequenceEqual(survivalCount),
                message: "The survival count sequences was not equal.");
        }
    }
}

// eof