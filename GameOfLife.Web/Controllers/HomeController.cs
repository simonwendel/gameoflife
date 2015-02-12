// <copyright file="HomeController.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.Web.Controllers
{
    using System;
    using System.Web.Mvc;
    using GameOfLife.Basics;
    using GameOfLife.Library.Factories;
    using GameOfLife.LinqLife;
    using GameOfLife.Web.Models;

    /// <summary>
    /// Handles all requests to /Home/ or /.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>The bootstrapper to use when starting a game.</summary>
        private IBootstrapper bootstrapper;

        /// <summary>
        /// Initializes a new instance of the HomeController class.
        /// </summary>
        /// <param name="bootstrapper">The bootstrapper for starting up games.</param>
        public HomeController(IBootstrapper bootstrapper)
        {
            this.bootstrapper = bootstrapper;
        }

        /// <summary>
        /// Retrieves the start page.
        /// </summary>
        /// <returns>A view result to be rendered by the framework and displaying 
        /// the start page.</returns>
        public ActionResult Index()
        {
            return View(new GameSettingsModel
                {
                    NumberOfGenerations = 30,
                    LifeForm = LifeForm.RandomPattern,
                    Rules = Rule.Standard
                });
        }

        /// <summary>
        /// Runs the game and returns information about the results via a 
        /// JSON-formatted string.
        /// </summary>
        /// <param name="settings">The game settings to run the game by.</param>
        /// <returns>A JSON-formatted string of the game results.</returns>
        [HttpPost]
        public ActionResult RunGame(GameSettingsModel settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(paramName: "settings");
            }

            try
            {
                var rules = RuleFactory.Build(settings.Rules);
                var lifeForm = LifeFormFactory.Build(settings.LifeForm);

                var game = bootstrapper.Boot<LinqGame>(rules);
                game.InitializeFrom(lifeForm.GetPattern());
                game.RunThrough(settings.NumberOfGenerations);

                return View("Success", model: game);
            }
            catch (BootFailedException)
            {
                return View("Error", model: "Booting the game failed.");
            }
        }
    }
}

// eof