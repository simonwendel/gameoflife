// <copyright file="LifeFormBaseTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.Library.LifeForms
{
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.Basics;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the LifeFormBase class from the GameOfLife.Library.LifeForms namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class LifeFormBaseTests
    {
        /// <summary>
        /// When the pattern has a stabilizing point in time, the IsStable property get accessor
        /// returns true.
        /// </summary>
        [TestMethod]
        public void IsStable_GivenStablePattern_ReturnsTrue()
        {
            // arrange
            var stable = new StableLifeForm();

            // act
            bool isStable = stable.IsStable;

            // assert
            Assert.IsTrue(
                isStable,
                message: "The life form was not stable.");
        }

        /// <summary>
        /// When the pattern doesn't have a stabilizing point in time, the IsStable property get accessor
        /// returns false.
        /// </summary>
        [TestMethod]
        public void IsStable_GivenUnstablePattern_ReturnsFalse()
        {
            // arrange
            var unstable = new UnstableLifeForm();

            // act
            bool isStable = unstable.IsStable;

            // assert
            Assert.IsFalse(
                isStable,
                message: "The life form was stable.");
        }

        private class UnstableLifeForm : LifeFormBase
        {
            public UnstableLifeForm()
                : base()
            {
                var pattern = new[] { new[] { 0 } };
                SetPattern(pattern);
            }
        }

        private class StableLifeForm : LifeFormBase
        {
            public StableLifeForm()
                : base(0, 0)
            {
                var pattern = new[] { new[] { 0 } };
                SetPattern(pattern);
            }
        }
    }
}

// eof
