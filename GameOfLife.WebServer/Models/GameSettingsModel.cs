// <copyright file="GameSettingsModel.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.WebServer.Models
{
    using System.ComponentModel.DataAnnotations;
    using GameOfLife.Library.Factories;

    /// <summary>
    /// View model for the game settings form before starting a game.
    /// </summary>
    public class GameSettingsModel
    {
        /// <summary>
        /// Gets or sets the number of generations to run the game.
        /// </summary>
        [Display(
            Name = "GameSettingsModel_NumberOfGenerations_Name",
            Description = "GameSettingsModel_NumberOfGenerations_Description",
            ResourceType = typeof(Resources.ViewModelResources))]
        [Required(
            ErrorMessageResourceName = "GameSettingsModel_NumberOfGenerations_Missing",
            ErrorMessageResourceType = typeof(Resources.ViewModelResources))]
        public int NumberOfGenerations { get; set; }

        /// <summary>
        /// Gets or sets the rules governing the game, defaults to Standard.
        /// </summary>
        [Display(
            Name = "GameSettingsModel_Rules_Name",
            Description = "GameSettingsModel_Rules_Description",
            ResourceType = typeof(Resources.ViewModelResources))]
        [Required(
            ErrorMessageResourceName = "GameSettingsModel_Rules_Missing",
            ErrorMessageResourceType = typeof(Resources.ViewModelResources))]
        public Rule Rules { get; set; }

        /// <summary>
        /// Gets or sets the initial life form pattern, defaults to a random grid.
        /// </summary>
        [Display(
            Name = "GameSettingsModel_LifeForm_Name",
            Description = "GameSettingsModel_LifeForm_Description",
            ResourceType = typeof(Resources.ViewModelResources))]
        [Required(
            ErrorMessageResourceName = "GameSettingsModel_LifeForm_Missing",
            ErrorMessageResourceType = typeof(Resources.ViewModelResources))]
        public LifeForm LifeForm { get; set; }
    }
}

// eof