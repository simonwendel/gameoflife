// <copyright file="GameSettings.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

/*
 * This class is excluded from code coverage metrics because there is no
 * reason to test it. It just wires up the command line parser, which we
 * see no reason not to trust.
 */

namespace GameOfLife.Console.Application
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using CommandLine;
    using CommandLine.Text;
    using GameOfLife.Library.Factories;

    /// <summary>
    /// The command line options for the console interface.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class GameSettings
    {
        /// <summary>
        /// Gets or sets the number of generations to progress the game. Required.
        /// </summary>
        [Option(
            shortName: 'g',
            longName: "generations",
            Required = true,
            HelpText = "The number of generations to progress the game.")]
        public int NumberOfGenerations { get; set; }

        /// <summary>
        /// Gets or sets the rules to run the game by. If omitted it defaults to the Standard rules.
        /// </summary>
        [Option(
            shortName: 'r',
            longName: "rules",
            DefaultValue = Rule.Standard,
            HelpText = "Run according to rules Standard | Sierpinskish. Defaults to Standard.")]
        public Rule Rules { get; set; }

        /// <summary>
        /// Gets or sets the initial pattern from the library. If omitted defaults to the RandomPattern.
        /// </summary>
        [Option(
            shortName: 'p',
            longName: "pattern",
            DefaultValue = LifeForm.RandomPattern,
            HelpText = "Select life form of Empty, Acorn, AircraftCarrier, FivePoint or RandomPattern, which is default.")]
        public LifeForm InitialPattern { get; set; }

        /// <summary>
        /// Renders the help screen information string.
        /// </summary>
        /// <returns>A string that can be used to output the help screen information.</returns>
        [HelpOption]
        public string RenderHelp()
        {
            var help = HelpText.AutoBuild(
                this,
                current => HelpText.DefaultParsingErrorsHandler(this, current));

            return string.Concat(Environment.NewLine, help); // an extra newline since I'm a perfectionist.
        }
    }
}
