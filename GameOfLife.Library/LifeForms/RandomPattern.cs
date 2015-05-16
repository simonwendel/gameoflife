// <copyright file="RandomPattern.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Library.LifeForms
{
    using System;
    using GameOfLife.Basics;

    /// <summary>
    /// A random pattern with a specified size. We can never know if this is stable or not.
    /// </summary>
    public class RandomPattern : LifeFormBase
    {
        /// <summary>The pseudo-random number generator.</summary>
        private static Random random;

        /// <summary>
        /// Initializes a new instance of the RandomPattern class.
        /// </summary>
        /// <param name="rows">The number of rows of the initial pattern.</param>
        /// <param name="cols">The number of columns of the initial pattern.</param>
        public RandomPattern(int rows, int cols)
            : base()
        {
            var pattern = RandomizePattern(rows, cols);
            SetPattern(pattern);
        }

        /// <summary>
        /// Produces a random pattern of ones and zeros.
        /// </summary>
        /// <param name="rows">The number of rows the pattern will have.</param>
        /// <param name="cols">The number of columns the pattern will have.</param>
        /// <returns>An integer array representing the pattern.</returns>
        private static int[][] RandomizePattern(int rows, int cols)
        {
            if (random == null)
            {
                random = new Random();
            }

            var output = new int[rows][];
            for (int row = 0; row < rows; ++row)
            {
                output[row] = new int[cols];
                for (int col = 0; col < cols; ++col)
                {
                    output[row][col] = random.Next(2);
                }
            }

            return output;
        }
    }
}
