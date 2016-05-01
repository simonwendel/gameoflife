// <copyright file="RuleFactoryTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2016.
// </copyright>

namespace GameOfLife.Tests.Library.Factories
{
    using GameOfLife.Library.Factories;
    using GameOfLife.Library.Rules;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Static unit tests of the RuleFactory class from the
    /// GameOfLife.Library.Rules
    /// </summary>
    [TestClass]
    public class RuleFactoryTests
    {
        /// <summary>
        /// The factory successfully builds a SierpinskishRules object when asked to.
        /// </summary>
        [TestMethod]
        public void Build_GivenSierpinskish_ReturnsSierpinskishRulesObject()
        {
            // act
            var rules = RuleFactory.Build(Rule.Sierpinskish) as SierpinskishRules;

            // assert
            Assert.IsNotNull(
                rules,
                message: "SierpinskishRules not built per expectation.");
        }

        /// <summary>
        /// The factory successfully builds a StandardRules object when asked to.
        /// </summary>
        [TestMethod]
        public void Build_GivenStandard_ReturnsStandardRulesObject()
        {
            // act
            var rules = RuleFactory.Build(Rule.Standard) as StandardRules;

            // assert
            Assert.IsNotNull(
                rules,
                message: "StandardRules not built per expectation.");
        }
    }
}
