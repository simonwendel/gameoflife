// <copyright file="IWriter.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.Basics
{
    /// <summary>
    /// Common interface of game writers for output of universe state.
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Writes game state to a string for output.
        /// </summary>
        /// <param name="game">The game to output.</param>
        /// <returns>A string with game state.</returns>
        string WriteOut(GameBase game);
    }
}

// eof