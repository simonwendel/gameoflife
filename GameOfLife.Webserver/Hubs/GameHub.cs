// <copyright file="GameHub.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Webserver.Hubs
{
    using System;
    using GameOfLife.Basics;
    using GameOfLife.Library.Factories;
    using GameOfLife.LinqLife;
    using GameOfLife.Webserver.Models;
    using Microsoft.AspNet.SignalR;

    /// <summary>
    /// SignalR hub running games and calling back to clients on completion or error.
    /// </summary>
    public class GameHub : Hub
    {
        private IBootstrapper bootstrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameHub" /> class.
        /// </summary>
        /// <param name="bootstrapper">The bootstrapper used to create a game prior to running.</param>
        public GameHub(IBootstrapper bootstrapper)
        {
            this.bootstrapper = bootstrapper;
        }

        /// <summary>
        /// Starts a game and attempts to run it a specified number of generations. Will call the connected
        /// clients on completion or error.
        /// </summary>
        /// <param name="settings">Settings to start the game with.</param>
        public void StartGame(GameSettingsModel settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            try
            {
                var rules = RuleFactory.Build(settings.Rules);
                var lifeForm = LifeFormFactory.Build(settings.LifeForm);

                var game = bootstrapper.Boot<LinqGame>(rules);
                game.InitializeFrom(lifeForm.GetPattern());
                game.RunThrough(settings.NumberOfGenerations);

                Clients.All.DisplayResults(game);
            }
            catch (BootFailedException)
            {
                var message = "Booting the game failed.";
                Clients.All.DisplayError(message);
            }
        }
    }
}
