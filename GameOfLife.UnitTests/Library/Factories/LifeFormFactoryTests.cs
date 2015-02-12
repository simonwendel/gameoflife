// <copyright file="LifeFormFactoryTests.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.UnitTests.Library.Factories
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
        /// The factory successfully builds the Empty life form when asked to.
        /// </summary>
        [TestMethod]
        public void EmptyLifeFormSuccessfullyBuilt()
        {
            // act
            var lifeForm = LifeFormFactory.Build(LifeForm.Empty) as Empty;

            // assert
            Assert.IsNotNull(
                lifeForm,
                message: "Life form not built as per expectation.");
        }

        /// <summary>
        /// The factory successfully builds the Acorn life form when asked to.
        /// </summary>
        [TestMethod]
        public void AcornLifeFormSuccessfullyBuilt()
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
        public void AircraftCarrierLifeFormSuccessfullyBuilt()
        {
            // act
            var lifeForm = LifeFormFactory.Build(LifeForm.AircraftCarrier) as AircraftCarrier;

            // assert
            Assert.IsNotNull(
                lifeForm,
                message: "Life form not built as per expectation.");
        }

        /// <summary>
        /// The factory successfully builds the FivePoint life form when asked to.
        /// </summary>
        [TestMethod]
        public void FivePointLifeFormSuccessfullyBuilt()
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
        public void RandomPatternLifeFormSuccessfullyBuilt()
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

// eof