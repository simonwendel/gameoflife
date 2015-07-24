// <copyright file="Universe.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.LinqLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameOfLife.Basics;

    /// <summary>
    /// The universe implemented for the LinqLife algorithm.
    /// </summary>
    internal class Universe : UniverseBase
    {
        /// <summary>The universe holding all cells in a set.</summary>
        private ISet<Cell> universe;

        /// <summary>
        /// Initializes a new instance of the Universe class.
        /// </summary>
        public Universe()
        {
            universe = new HashSet<Cell>();
        }

        /// <summary>
        /// Initializes a new instance of the Universe class.
        /// </summary>
        /// <param name="pattern">An integer pattern for initializing universe population.</param>
        public Universe(int[][] pattern)
            : this()
        {
            if (pattern == null)
            {
                throw new ArgumentNullException(paramName: "pattern");
            }

            int width = pattern.Length;
            if (width == 0)
            {
                throw new ArgumentException(
                    message: "The pattern must have a width > 0.",
                    paramName: "pattern");
            }

            int height = pattern[0].Length;

            if (!pattern.All(x => x.Length == height))
            {
                throw new ArgumentException(
                    message: "The pattern must have all columns of equal height.",
                    paramName: "pattern");
            }

            if (height == 0)
            {
                throw new ArgumentException(
                    message: "The pattern must have a height > 0.",
                    paramName: "pattern");
            }

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    if (pattern[x][y] == 1)
                    {
                        // we transpose the y coordinate so that the resulting
                        // universe is placed in the first quadrant of a
                        // cartesian coordinate system.
                        Add(
                            x: x,
                            y: height - 1 - y);
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the Universe class, copying contents from
        /// another Universe.
        /// </summary>
        /// <param name="source">The source universe to copy cells from.</param>
        public Universe(Universe source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(paramName: "source");
            }

            universe = new HashSet<Cell>(source.universe);
        }

        /// <summary>
        /// Gets the current number of cells in the universe.
        /// </summary>
        public override int Population
        {
            get
            {
                return universe.Count;
            }
        }

        /// <summary>
        /// Gets a list of all cells in the universe.
        /// </summary>
        internal List<Cell> AllCells
        {
            get
            {
                return universe.ToList();
            }
        }

        /// <summary>
        /// Adds a cell at some coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate of the new cell.</param>
        /// <param name="y">The y-coordinate of the new cell.</param>
        /// <returns><value>true</value> if successful, <value>false</value> if a cell
        /// already exists at those coordinates.</returns>
        public bool Add(int x, int y)
        {
            return universe.Add(new Cell(x, y));
        }

        /// <summary>
        /// Adds a cell to the universe.
        /// </summary>
        /// <param name="cell">The cell to add.</param>
        /// <returns><value>true</value> if successful, <value>false</value> if a cell
        /// already exists at the same coordinates.</returns>
        public bool Add(Cell cell)
        {
            return universe.Add(cell);
        }

        /// <summary>
        /// Removes a cell from the universe.
        /// </summary>
        /// <param name="cell">The cell to remove.</param>
        /// <returns><value>true</value> if the cell was successfully removed;
        /// otherwise, <value>false</value>. This method also returns <value>false</value> if
        /// the cell is not found in the universe.</returns>
        public bool Remove(Cell cell)
        {
            return universe.Remove(cell);
        }

        /// <summary>
        /// Checks to see if a cell exists at some coordinates.
        /// </summary>
        /// <param name="x">The x-coordinate of the location to check.</param>
        /// <param name="y">The y-coordinate of the location to check.</param>
        /// <returns><value>true</value> if a cell exists, <value>false</value> if not.</returns>
        public bool HasCell(int x, int y)
        {
            return universe.Contains(new Cell(x, y));
        }

        /// <summary>
        /// Calculates the number of live cells close to some location.
        /// </summary>
        /// <param name="x">The x-coordinate of the location to check.</param>
        /// <param name="y">The y-coordinate of the location to check.</param>
        /// <returns>The number of live cells surrounding the location.</returns>
        public int CountLivingNeighbors(int x, int y)
        {
            return
                ListAllPossibleNeighbors(x, y)
                .Where(c => universe.Contains(c))
                .Count();
        }

        /// <summary>
        /// Lists all neighboring cells close to some location.
        /// </summary>
        /// <param name="x">The x-coordinate of the location to list.</param>
        /// <param name="y">The y-coordinate of the location to list.</param>
        /// <returns>An enumerable collection of cells neighboring the
        /// location.</returns>
        public IEnumerable<Cell> ListAllPossibleNeighbors(int x, int y)
        {
            var range = Enumerable.Range(-1, 3);
            return from xOffset in range
                   from yOffset in range
                   where !(xOffset == 0 && yOffset == 0)
                   select new Cell(x + xOffset, y + yOffset);
        }
    }
}
