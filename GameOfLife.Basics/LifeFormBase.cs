// <copyright file="LifeFormBase.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.Basics
{
    /// <summary>
    /// The abstract base of all life forms in the library.
    /// </summary>
    public abstract class LifeFormBase
    {
        /// <summary>The initial pattern to start off the life form.</summary>
        private int[][] initialPattern;

        /// <summary>
        /// Initializes a new instance of the LifeFormBase class with an unstable population.
        /// </summary>
        protected LifeFormBase()
            : this(-1, -1)
        {
        }

        /// <summary>
        /// Initializes a new instance of the LifeFormBase class with a stable population.
        /// </summary>
        /// <param name="stabilizesAt">The generation at which the population stabilizes.</param>
        /// <param name="stablePopulation">The number of cells populating the universe when it's stable.</param>
        protected LifeFormBase(int stabilizesAt, int stablePopulation)
        {
            StabilizesAt = stabilizesAt;
            StablePopulation = stablePopulation;
        }

        /// <summary>
        /// Gets the generation at which the population stabilizes.
        /// </summary>
        public int StabilizesAt { get; private set; }

        /// <summary>
        /// Gets the number of cells in the population when it's stable.
        /// </summary>
        public int StablePopulation { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this is a stable pattern or not.
        /// </summary>
        public bool IsStable
        {
            get
            {
                return StabilizesAt > -1;
            }
        }

        /// <summary>
        /// Gets the initial pattern.
        /// </summary>
        /// <returns>A two-dimensional jagged array of integers representing the 
        /// initial pattern of the life form.</returns>
        public int[][] GetPattern()
        {
            return (int[][])initialPattern.Clone();
        }

        /// <summary>
        /// Sets the initial pattern for the life form.
        /// </summary>
        /// <param name="pattern">A two-dimensional array of integers representing the 
        /// initial pattern of the life form.</param>
        protected void SetPattern(int[][] pattern)
        {
            initialPattern = pattern;
        }
    }
}

// eof