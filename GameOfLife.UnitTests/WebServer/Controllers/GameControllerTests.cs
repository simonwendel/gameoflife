// <copyright file="GameControllerTests.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.UnitTests.WebServer.Controllers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Http;
    using GameOfLife.Basics;
    using GameOfLife.Library.Factories;
    using GameOfLife.Library.Rules;
    using GameOfLife.LinqLife;
    using GameOfLife.WebServer.Controllers;
    using GameOfLife.WebServer.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Unit tests the GameController class from the GameOfLife.WebServer.Controllers namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class GameControllerTests
    {
        /// <summary>
        /// Passing a null reference for the settings to the Post action 
        /// throws an exception.
        /// </summary>
        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void NullGameSettingsPassedIntoRunGameThrowsException()
        {
            // arrange
            using (var target = new GameController(Mock.Of<IBootstrapper>()))
            {
                // act
                target.Post(null);
            }
        }

        /// <summary>
        /// If the bootstrapper fails when calling the Post action method 
        /// the game will be aborted.
        /// </summary>
        [TestMethod, ExpectedException(typeof(HttpResponseException))]
        public void RunningGameFailsWhenBootstrapperFailsToBootGame()
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

            using (var target = new GameController(mockBoot.Object))
            {
                RequestFactory.CreateRequestFor(target);

                // act
                target.Post(settings);
            }
        }

        /// <summary>
        /// If all goes well, the Post action returns an GameBase with state.
        /// </summary>
        [TestMethod]
        public void PostSucceedsWhenGameSuccessfullyRuns()
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

            using (var target = new GameController(mockBoot.Object))
            {
                // act
                var result = target.Post(settings);

                // assert
                Assert.AreSame(
                    expected: mockGame.Object,
                    actual: result);

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