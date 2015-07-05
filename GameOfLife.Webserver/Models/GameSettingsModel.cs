// <copyright file="GameSettingsModel.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Webserver.Models
{
    using GameOfLife.Library.Factories;

    /// <summary>
    /// View model for the game settings form before starting a game.
    /// </summary>
    public class GameSettingsModel
    {
        /// <summary>
        /// Gets or sets the number of generations to run the game.
        /// </summary>
        public int NumberOfGenerations { get; set; }

        /// <summary>
        /// Gets or sets the rules governing the game, defaults to Standard.
        /// </summary>
        public Rule Rules { get; set; }

        /// <summary>
        /// Gets or sets the initial life form pattern.
        /// </summary>
        public LifeForm LifeForm { get; set; }
    }
}
