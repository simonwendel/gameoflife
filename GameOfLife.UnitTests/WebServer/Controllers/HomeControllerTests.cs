// <copyright file="HomeControllerTests.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.UnitTests.WebServer.Controllers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;
    using GameOfLife.Basics;
    using GameOfLife.Library.Factories;
    using GameOfLife.Library.Rules;
    using GameOfLife.LinqLife;
    using GameOfLife.WebServer.Controllers;
    using GameOfLife.WebServer.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Unit tests the HomeController class from the GameOfLife.Web.Controllers namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class HomeControllerTests
    {
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
                var result = target.RunGame(settings) as JsonResult;
                var error = result.Data as GameBootError;

                // assert
                Assert.IsNotNull(
                    result,
                    message: "Result was not a JSON-formatted string.");

                Assert.AreEqual(
                    expected: "Booting the game failed.",
                    actual: error.Message,
                    message: "Error message not correctly returned.");

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
                var result = target.RunGame(settings) as JsonResult;
                dynamic data = result.Data;

                // assert
                Assert.IsNotNull(
                    result,
                    message: "The result was not a JSON-formatted string.");

                Assert.IsNotNull(
                    data.Population);

                Assert.IsNotNull(
                    data.Generation);

                Assert.IsNotNull(
                    data.LastRuntime);

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