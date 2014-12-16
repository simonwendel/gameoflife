// <copyright file="Acorn.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
// </copyright> 

namespace GameOfLife.Library.LifeForms
{
    using GameOfLife.Basics;

    /// <summary>
    /// The acorn stabilizes in 5206 generations with a population of 633.
    /// </summary>
    public class Acorn : LifeFormBase
    {
        /// <summary>
        /// Initializes a new instance of the Acorn class.
        /// </summary>
        public Acorn()
            : base(stabilizesAt: 5206, stablePopulation: 633)
        {
            var pattern = new[] 
            {
                new[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 1, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 1, 0, 0, 0, 0 },
                new[] { 1, 1, 0, 0, 1, 1, 1, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0 },
                new[] { 0, 0, 0, 0, 0, 0, 0, 0 } 
            };

            SetPattern(pattern);
        }
    }
}

// eof