// <copyright file="GameHubTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.Webserver.Hubs
{
    using System;
    using GameOfLife.Basics;
    using GameOfLife.Library.Factories;
    using GameOfLife.Library.Rules;
    using GameOfLife.LinqLife;
    using GameOfLife.Webserver.Hubs;
    using GameOfLife.Webserver.Models;
    using Microsoft.AspNet.SignalR.Hubs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Unit tests the GameHub SignalR hub, with client side interactions.
    /// </summary>
    [TestClass]
    public class GameHubTests : IDisposable
    {
        private Mock<IGameClientContract> clients;

        private GameHub hub;

        private Mock<IBootstrapper> mockBoot;

        /// <summary>
        /// Sets up the test fixture and initializes shared objects.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            mockBoot = new Mock<IBootstrapper>();

            hub = new GameHub(mockBoot.Object);

            var mockContext = new Mock<IHubCallerConnectionContext<dynamic>>();
            hub.Clients = mockContext.Object;

            clients = new Mock<IGameClientContract>();
            mockContext.Setup(x => x.All).Returns(clients.Object);

            clients.Setup(x => x.DisplayError(It.IsAny<string>())).Verifiable();
            clients.Setup(x => x.DisplayResults(It.IsAny<GameBase>())).Verifiable();
        }

        /// <summary>
        /// Passing a null reference for the settings to the StartGame action
        /// will raise an exception, since this is something we can't possibly
        /// handle in a good way.
        /// </summary>
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void StartGame_GivenNullGameSettings_ThrowsException()
        {
            // act
            hub.StartGame(null);
        }

        /// <summary>
        /// If the bootstrapper fails when calling the StartGame action
        /// the hub will call displayError on the clients.
        /// </summary>
        [TestMethod]
        public void StartGame_WhenBootstrappingFails_CallsErrorCallback()
        {
            // arrange
            mockBoot
                .Setup(x => x.Boot<LinqGame>(It.IsAny<RulesBase>()))
                .Throws(new BootFailedException());

            var settings = new GameSettingsModel
            {
                LifeForm = LifeForm.Empty,
                NumberOfGenerations = 30,
                Rules = Rule.Standard
            };

            // act:ish
            hub.StartGame(settings);

            // assert
            clients.Verify(
                x => x.DisplayError(It.IsAny<string>()),
                Times.Once());
        }

        /// <summary>
        /// If all goes well, the Post action returns an GameBase with state.
        /// </summary>
        [TestMethod]
        public void StartGame_WhenGameRunsThrough_ReturnsGameState()
        {
            // arrange
            var mockGame = BuildMockGame();
            mockBoot
                .Setup(x => x.Boot<LinqGame>(It.IsAny<RulesBase>()))
                .Returns(mockGame.Object);

            var settings = new GameSettingsModel
            {
                LifeForm = LifeForm.Empty,
                NumberOfGenerations = 30,
                Rules = Rule.Standard
            };

            // act
            hub.StartGame(settings);

            // assert
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
                x => x.Format(),
                Times.Never());

            clients.Verify(
                x => x.DisplayResults(It.Is<GameBase>(r => r == mockGame.Object)),
                Times.Once());
        }

        /// <summary>
        /// Disposes the disposable resources used by the NinjectFactory instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the disposable resources used by the NinjectFactory instance.
        /// </summary>
        /// <param name="disposing">
        /// If true, the disposable resources of the NinjectFactory instance will be disposed.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (hub != null)
                {
                    hub.Dispose();
                    hub = null;
                }
            }
        }

        private static Mock<GameBase> BuildMockGame()
        {
            var mockGame = new Mock<GameBase>(
                Mock.Of<IFormatter>(),
                new StandardRules());

            mockGame
                .Setup(x => x.InitializeFrom(It.IsAny<int[][]>()));

            mockGame
                .Setup(x => x.RunThrough(It.IsAny<int>()));

            mockGame
                .Setup(x => x.Format())
                .Returns(string.Empty);

            return mockGame;
        }
    }
}
