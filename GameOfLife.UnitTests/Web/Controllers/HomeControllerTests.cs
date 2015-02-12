// <copyright file="HomeControllerTests.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.UnitTests.Web.Controllers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;
    using GameOfLife.Basics;
    using GameOfLife.Library.Factories;
    using GameOfLife.Library.Rules;
    using GameOfLife.LinqLife;
    using GameOfLife.Web.Controllers;
    using GameOfLife.Web.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Unit tests the HomeController class from the GameOfLife.Web.Controllers namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class HomeControllerTests
    {
        /// <summary>
        /// When the Index action is called on the HomeController it will simply
        /// return the view of the same name.
        /// </summary>
        [TestMethod]
        public void IndexActionRetrievesDefaultView()
        {
            // arrange
            using (var target = new HomeController(Mock.Of<IBootstrapper>()))
            {
                // act
                var results = target.Index() as ViewResult;
                var model = results.Model as GameSettingsModel;

                // assert
                Assert.IsNotNull(
                    results,
                    message: "The result was not a view.");

                Assert.AreEqual(
                    expected: string.Empty,
                    actual: results.ViewName,
                    message: "The framework did not automatically infer view name.");

                Assert.IsNotNull(
                    model,
                    message: "No model set or wrong model type.");

                Assert.AreEqual(
                    expected: 30,
                    actual: model.NumberOfGenerations,
                    message: "Default number of generations not set.");

                Assert.AreEqual(
                    expected: LifeForm.RandomPattern,
                    actual: model.LifeForm,
                    message: "Default pattern not set.");

                Assert.AreEqual(
                    expected: Rule.Standard,
                    actual: model.Rules,
                    message: "Default rules not set.");
            }
        }

        /// <summary>
        /// Passing a null reference for the settings to the RunGame action 
        /// throws an exception.
        /// </summary>
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void NullGameSettingsPassedIntoRunGameThrowsException()
        {
            // arrange
            using (var target = new HomeController(Mock.Of<IBootstrapper>()))
            {
                // act
                target.RunGame(null);
            }
        }

        /// <summary>
        /// If the bootstrapper fails when calling the RunGame action method 
        /// the game will be aborted.
        /// </summary>
        [TestMethod]
        public void RunGameFailsWhenBootstrapperFailsToBootGame()
        {
            // arrange
            var mockBoot = new Mock<IBootstrapper>();
            mockBoot
                .Setup(x => x.Boot<LinqGame>(It.IsAny<RulesBase>()))
                .Throws(new BootFailedException());

            var settings = new GameSettingsModel
            {
                LifeForm = LifeForm.Empty,
                NumberOfGenerations = 30,
                Rules = Rule.Standard
            };

            using (var target = new HomeController(mockBoot.Object))
            {
                // act
                var result = target.RunGame(settings) as ViewResult;

                // assert
                Assert.IsNotNull(
                    result,
                    message: "Result was not a view.");

                Assert.AreEqual(
                    expected: "Error",
                    actual: result.ViewName,
                    message: "Error view not returned.");

                mockBoot.Verify(
                    x => x.Boot<LinqGame>(It.IsAny<RulesBase>()),
                    Times.Once());
            }
        }

        /// <summary>
        /// If all goes well, the RunGame action returns an JSON-formatted string 
        /// with a message of the game success.
        /// </summary>
        [TestMethod]
        public void RunGameSucceedsWhenGameSuccessfullyRuns()
        {
            // arrange
            string writeOut = "Some kind of output expected.";
            var mockGame = BuildMockGame(writeOut);

            var mockBoot = new Mock<IBootstrapper>();
            mockBoot
                .Setup(x => x.Boot<LinqGame>(It.IsAny<RulesBase>()))
                .Returns(mockGame.Object);

            var settings = new GameSettingsModel
            {
                LifeForm = LifeForm.Empty,
                NumberOfGenerations = 30,
                Rules = Rule.Standard
            };

            using (var target = new HomeController(mockBoot.Object))
            {
                // act
                var result = target.RunGame(settings) as ViewResult;

                // assert
                Assert.IsNotNull(
                    result,
                    message: "The result was not a view.");

                Assert.AreEqual(
                    expected: "Success",
                    actual: result.ViewName,
                    message: "The writer output expected was not returned.");

                Assert.AreSame(
                    expected: mockGame.Object,
                    actual: result.Model,
                    message: "The game was not passed as the model of the success view.");

                mockBoot.Verify(
                    x => x.Boot<LinqGame>(It.IsAny<RulesBase>()),
                    Times.Once());

                mockGame.Verify(
                    x => x.InitializeFrom(It.IsAny<int[][]>()),
                    Times.Once());

                mockGame.Verify(
                    x => x.RunThrough(It.IsAny<int>()),
                    Times.Once());

                mockGame.Verify(
                    x => x.WriteOut(),
                    Times.Never());
            }
        }

        /// <summary>
        /// Creates a mock GameBase derived object, that appears to 
        /// be fully functional.
        /// </summary>
        /// <param name="writeOut">The string outputted by the WriteOut method.</param>
        /// <returns>A mocked GameBase for testing.</returns>
        private static Mock<GameBase> BuildMockGame(string writeOut)
        {
            var mockGame = new Mock<GameBase>(
                Mock.Of<IWriter>(),
                new StandardRules());

            mockGame
                .Setup(x => x.InitializeFrom(It.IsAny<int[][]>()));

            mockGame
                .Setup(x => x.RunThrough(It.IsAny<int>()));

            mockGame
                .Setup(x => x.WriteOut())
                .Returns(writeOut);

            return mockGame;
        }
    }
}

// eof