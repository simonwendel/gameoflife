// <copyright file="FivePoint.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2016.
// </copyright>

namespace GameOfLife.Library.LifeForms
{
    using GameOfLife.Basics;

    /// <summary>
    /// A simple pattern which will evolve from
    /// <para>
    /// X-X-
    /// -X--
    /// X-X-
    /// ---
    /// </para>
    /// into
    /// <para>
    /// -X--
    /// X-X-
    /// -X--
    /// ----
    /// </para>
    /// in generation 1 and then is a still life.
    /// </summary>
    public class FivePoint : LifeFormBase
    {
        /// <summary>
        /// Initializes a new instance of the FivePoint class.
        /// </summary>
        public FivePoint()
            : base(stabilizesAt: 1, stablePopulation: 4)
        {
            var pattern = new[]
            {
                new[] { 1, 0, 1, 0 },
                new[] { 0, 1, 0, 0 },
                new[] { 1, 0, 1, 0 },
                new[] { 0, 0, 0, 0 }
            };

            SetPattern(pattern);
        }
    }
}
