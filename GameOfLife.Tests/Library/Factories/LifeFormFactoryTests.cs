// <copyright file="LifeFormFactoryTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Tests.Library.Factories
{
    using GameOfLife.Library.Factories;
    using GameOfLife.Library.LifeForms;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Static unit tests for the LifeFormFactory class from the
    /// GameOfLife.Library.Factories namespace.
    /// </summary>
    [TestClass]
    public class LifeFormFactoryTests
    {
        /// <summary>
        /// The factory successfully builds the Acorn life form when asked to.
        /// </summary>
        [TestMethod]
        public void Build_GivenAcorn_ReturnsAcornObject()
        {
            // act
            var lifeForm = LifeFormFactory.Build(LifeForm.Acorn) as Acorn;

            // assert
            Assert.IsNotNull(
                lifeForm,
                message: "Life form not built as per expectation.");
        }

        /// <summary>
        /// The factory successfully builds the AircraftCarrier life form when asked to.
        /// </summary>
        [TestMethod]
        public void Build_GivenAircraftCarrier_ReturnsAircraftCarrierObject()
        {
            // act
            var lifeForm = LifeFormFactory.Build(LifeForm.AircraftCarrier) as AircraftCarrier;

            // assert
            Assert.IsNotNull(
                lifeForm,
                message: "Life form not built as per expectation.");
        }

        /// <summary>
        /// The factory successfully builds the Empty life form when asked to.
        /// </summary>
        [TestMethod]
        public void Build_GivenEmptyLifeForm_ReturnsEmptyLifeFormObject()
        {
            // act
            var lifeForm = LifeFormFactory.Build(LifeForm.Empty) as Empty;

            // assert
            Assert.IsNotNull(
                lifeForm,
                message: "Life form not built as per expectation.");
        }

        /// <summary>
        /// The factory successfully builds the FivePoint life form when asked to.
        /// </summary>
        [TestMethod]
        public void Build_GivenFivePoint_ReturnsFivePointObject()
        {
            // act
            var lifeForm = LifeFormFactory.Build(LifeForm.FivePoint) as FivePoint;

            // assert
            Assert.IsNotNull(
                lifeForm,
                message: "Life form not built as per expectation.");
        }

        /// <summary>
        /// The factory successfully builds the RandomPattern life form when asked to.
        /// </summary>
        [TestMethod]
        public void Build_GivenRandomPattern_ReturnsRandomPatternObject()
        {
            // act
            var lifeForm = LifeFormFactory.Build(LifeForm.RandomPattern) as RandomPattern;

            // assert
            Assert.IsNotNull(
                lifeForm,
                message: "Life form not built as per expectation.");
        }
    }
}
