// <copyright file="StandardRules.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
// </copyright> 

namespace GameOfLife.Library.Rules
{
    using GameOfLife.Basics;

    /// <summary>
    /// These are the original rules, as defined by John Horton Conway.
    /// </summary>
    public sealed class StandardRules : RulesBase
    {
        /// <summary>
        /// Initializes a new instance of the StandardRules class.
        /// </summary>
        public StandardRules()
            : base(new[] { 3 }, new[] { 2, 3 })
        {
        }
    }
}

// eof