// <copyright file="IFormatter.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Basics
{
    /// <summary>
    /// Common interface of game formatters for output of universe state.
    /// </summary>
    public interface IFormatter
    {
        /// <summary>
        /// Writes game state to a string for output.
        /// </summary>
        /// <param name="game">The game to output.</param>
        /// <returns>A string with game state.</returns>
        string Format(GameBase game);
    }
}

// eof
