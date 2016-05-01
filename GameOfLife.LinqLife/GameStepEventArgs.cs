// <copyright file="GameStepEventArgs.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2016.
// </copyright>

namespace GameOfLife.LinqLife
{
    using System;
    using System.Collections.Generic;
    using GameOfLife.Basics;

    /// <summary>
    /// Information about a game step event raised from a game.
    /// </summary>
    public class GameStepEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameStepEventArgs" /> class.
        /// </summary>
        /// <param name="deadCells">A collection of cells that have died.</param>
        /// <param name="newCells">A collection of cells that have been born.</param>
        public GameStepEventArgs(IEnumerable<Cell> deadCells, IEnumerable<Cell> newCells)
        {
            DeadCells = deadCells;
            NewCells = newCells;
        }

        /// <summary>
        /// Gets an enumerable collection of cells that has died during the step.
        /// </summary>
        public IEnumerable<Cell> DeadCells { get; private set; }

        /// <summary>
        /// Gets an enumerable collection of cells that have been born during the step.
        /// </summary>
        public IEnumerable<Cell> NewCells { get; private set; }
    }
}
