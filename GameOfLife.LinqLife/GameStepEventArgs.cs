// <copyright file="GameStepEventArgs.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.LinqLife
{
    using System;

    /// <summary>
    /// Information about a game step event raised from a game.
    /// </summary>
    public class GameStepEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameStepEventArgs" /> class.
        /// </summary>
        public GameStepEventArgs()
        {
        }
    }
}
