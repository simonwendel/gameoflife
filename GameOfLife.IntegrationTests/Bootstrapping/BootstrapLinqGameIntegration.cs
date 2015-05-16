// <copyright file="BootstrapLinqGameIntegration.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.IntegrationTests.Bootstrapping
{
    using GameOfLife.Console.Application;
    using GameOfLife.Library.LifeForms;
    using GameOfLife.Library.Rules;
    using GameOfLife.LinqLife;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Does some integration testing by using the Bootstrapper and LinqGame.
    /// </summary>
    [TestClass]
    public class BootstrapLinqGameIntegration
    {
        /// <summary>
        /// Bootstraps a LinqGame with standard rules and the FivePoint pattern,
        /// steps it, and correct results are returned.
        /// </summary>
        [TestMethod]
        public void StepForward_InitializedAndBootstrapped_AdvancesUniverse()
        {
            // arrange
            using (var bootstrapper = new Bootstrapper())
            {
                var rules = new StandardRules();
                var lifeForm = new FivePoint();

                // act
                var game = bootstrapper.Boot<LinqGame>(rules: rules);
                game.InitializeFrom(lifeForm.GetPattern());
                game.StepForward();

                // assert
                Assert.AreEqual(
                    expected: 4,
                    actual: game.Population,
                    message: "The universe does not contain exactly 4 cells.");

                Assert.AreEqual(
                    expected: 1,
                    actual: game.Generation,
                    message: "The game did not progress by one generation.");
            }
        }
    }
}
