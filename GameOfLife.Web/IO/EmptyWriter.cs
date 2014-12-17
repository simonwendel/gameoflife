// <copyright file="EmptyWriter.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
// </copyright> 

namespace GameOfLife.Web.IO
{
    using GameOfLife.Basics;

    /// <summary>
    /// Implements a writer that outputs to an HTML string.
    /// </summary>
    public class EmptyWriter : IWriter
    {
        /// <summary>
        /// Writes game state to an HTML-formatted string for output.
        /// </summary>
        /// <param name="game">The game to output.</param>
        /// <returns>A string with a HTML-based representation of 
        /// game state.</returns>
        public string WriteOut(GameBase game)
        {
            return string.Empty;
        }
    }
}

// eof