// <copyright file="SierpinskishRules.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2016.
// </copyright>

namespace GameOfLife.Library.Rules
{
    using GameOfLife.Basics;

    /// <summary>
    /// This is a rule that make one living cell evolve into four close
    /// approximations to the Sierpiński triangle given enough time.
    /// </summary>
    public sealed class SierpinskishRules : RulesBase
    {
        /// <summary>
        /// Initializes a new instance of the SierpinskishRules class.
        /// </summary>
        public SierpinskishRules()
            : base(new[] { 1 }, new[] { 1, 2 })
        {
        }
    }
}
