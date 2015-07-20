// <copyright file="GameStepEventArgs.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
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
        public IEnumerable<Cell> StepChanges { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStepEventArgs" /> class.
        /// </summary>
        public GameStepEventArgs(IEnumerable<Cell> stepChanges)
        {
            StepChanges = stepChanges;
        }
    }
}
