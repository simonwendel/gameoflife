// <copyright file="EmptyFormatter.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Webserver.IO
{
    using GameOfLife.Basics;

    /// <summary>
    /// Implements a formatter that outputs to an empty string.
    /// </summary>
    public class EmptyFormatter : IFormatter
    {
        /// <summary>
        /// Writes an empty string for output.
        /// </summary>
        /// <param name="game">The game to output, however not used.</param>
        /// <returns>An empty string.</returns>
        public string Format(GameBase game)
        {
            return string.Empty;
        }
    }
}
