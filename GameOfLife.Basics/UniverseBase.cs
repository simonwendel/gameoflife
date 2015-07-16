// <copyright file="UniverseBase.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Basics
{
    /// <summary>
    /// Base class of a "universe" in the Game Of Life terminology.
    /// </summary>
    public abstract class UniverseBase
    {
        /// <summary>
        /// Gets the current number of cells in the universe.
        /// </summary>
        public abstract int Population { get; }
    }
}
