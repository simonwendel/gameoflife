// <copyright file="Cell.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.LinqLife
{
    using System;

    /// <summary>
    /// Represents a live cell in the universe.
    /// </summary>
    internal struct Cell : IEquatable<Cell>
    {
        /// <summary>The x-coordinate of the cell.</summary>
        private readonly int x;

        /// <summary>The y-coordinate of the cell.</summary>
        private readonly int y;

        /// <summary>
        /// Initializes a new instance of the Cell structure.
        /// </summary>
        /// <param name="x">The x-coordinate of the cell.</param>
        /// <param name="y">The y-coordinate of the cell.</param>
        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Gets the x-coordinate of the cell.
        /// </summary>
        public int X
        {
            get
            {
                return x;
            }
        }

        /// <summary>
        /// Gets the y-coordinate of the cell.
        /// </summary>
        public int Y
        {
            get
            {
                return y;
            }
        }

        /// <summary>
        /// Indicates whether the current Cell is equal to another Cell.
        /// </summary>
        /// <param name="other">A Cell object to compare with this Cell.</param>
        /// <returns><value>true</value> if the current Cell is equal to the other Cell;
        /// otherwise, <value>false</value>.</returns>
        public bool Equals(Cell other)
        {
            return x == other.x && y == other.y;
        }

        /// <summary>
        /// Serves as a hash function for the Cell type.
        /// </summary>
        /// <returns>A hash code for the current Cell.</returns>
        public override int GetHashCode()
        {
            const int FIRSTPRIME = 269;
            const int SECONDPRIME = 47;

            // we don't care about overflow, so we go unchecked
            unchecked
            {
                int hash = FIRSTPRIME;
                hash = (hash * SECONDPRIME) + x.GetHashCode();
                hash = (hash * SECONDPRIME) + y.GetHashCode();
                return hash;
            }
        }
    }
}
