// <copyright file="GameController.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Webserver.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using GameOfLife.Basics;
    using GameOfLife.Library.Factories;
    using GameOfLife.LinqLife;
    using GameOfLife.Webserver.Filters;
    using GameOfLife.Webserver.Models;

    /// <summary>
    /// Controller serving /API/game/* that handles creating and running games.
    /// </summary>
    public class GameController : ApiController
    {
        /// <summary>Bootstrapper used to start a new game.</summary>
        private IBootstrapper bootstrapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameController" /> class.
        /// </summary>
        /// <param name="bootstrapper">Bootstrapper used to start a new game.</param>
        public GameController(IBootstrapper bootstrapper)
        {
            this.bootstrapper = bootstrapper;
        }

        /// <summary>
        /// Handles POST to /API/game
        /// </summary>
        /// <param name="settings">Settings to start the game with.</param>
        /// <returns>An <see cref="GameBase" /> object with state of the game run.</returns>
        [NoNullArguments]
        public GameBase Post(GameSettingsModel settings)
        {
            try
            {
                var rules = RuleFactory.Build(settings.Rules);
                var lifeForm = LifeFormFactory.Build(settings.LifeForm);

                var game = bootstrapper.Boot<LinqGame>(rules);
                game.InitializeFrom(lifeForm.GetPattern());
                game.RunThrough(settings.NumberOfGenerations);

                return game;
            }
            catch (BootFailedException)
            {
                var message = "Booting the game failed.";
                throw new HttpResponseException(
                    Request.CreateErrorResponse(HttpStatusCode.InternalServerError, message));
            }
        }
    }
}
