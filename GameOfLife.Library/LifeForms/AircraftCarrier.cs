// <copyright file="AircraftCarrier.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2016.
// </copyright>

namespace GameOfLife.Library.LifeForms
{
    using GameOfLife.Basics;

    /// <summary>
    /// The aircraft carrier is the smallest known still life with
    /// more than one island.
    /// </summary>
    public class AircraftCarrier : LifeFormBase
    {
        /// <summary>
        /// Initializes a new instance of the AircraftCarrier class.
        /// </summary>
        public AircraftCarrier()
            : base(stabilizesAt: 0, stablePopulation: 6)
        {
            var pattern = new[]
            {
                new[] { 1, 1, 0, 0 },
                new[] { 1, 0, 0, 1 },
                new[] { 0, 0, 1, 1 },
                new[] { 0, 0, 0, 0 }
            };

            SetPattern(pattern);
        }
    }
}
