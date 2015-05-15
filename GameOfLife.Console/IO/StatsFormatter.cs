// <copyright file="StatsFormatter.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Console.IO
{
    using System;
    using System.Globalization;
    using GameOfLife.Basics;
    using GameOfLife.Console.Resources;

    /// <summary>
    /// Implements a formatter that outputs stats to the system console.
    /// </summary>
    internal class StatsFormatter : IFormatter
    {
        /// <summary>
        /// Writes game state statistics to a string headed to the system console.
        /// </summary>
        /// <param name="game">The game to output.</param>
        /// <returns>A string suitable for console output.</returns>
        public string Format(GameBase game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(paramName: "game");
            }

            var rule = ConsoleStrings.StatsFormatter_HorizontalRule;
            var generations = string.Format(
                CultureInfo.CurrentCulture,
                ConsoleStrings.StatsFormatter_AtGenerations,
                game.Generation);

            var population = string.Format(
                CultureInfo.CurrentCulture,
                ConsoleStrings.StatsFormatter_PopulationIs,
                game.Population);

            var timeOut = string.Format(
                CultureInfo.CurrentCulture,
                ConsoleStrings.StatsFormatter_RanInMs,
                game.LastRuntime);

            return string.Concat(
                rule,
                Environment.NewLine,
                generations,
                population,
                Environment.NewLine,
                timeOut,
                Environment.NewLine,
                rule,
                Environment.NewLine);
        }
    }
}

// eof
