// <copyright file="StandardRulesConstructorTests.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
// </copyright> 

namespace GameOfLife.UnitTests.Library.Rules
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using GameOfLife.Library.Rules;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// For code coverage completeness, this runs unit tests on the constructor for the 
    /// StandardRules class from the GameOfLife.Domain.Games namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class StandardRulesConstructorTests
    {
        /// <summary>
        /// When the constructor of the StandardRules class is called, the survival count and 
        /// birth count sequences are correctly initialized as per the "original" rules of 
        /// Conway's Game of Life.
        /// </summary>
        [TestMethod]
        public void TheStandardRulesConstructorInitializesCorrectly()
        {
            // arrange
            var birthCount = new[] { 3 };
            var survivalCount = new[] { 2, 3 };

            // act
            var rules = new StandardRules();

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