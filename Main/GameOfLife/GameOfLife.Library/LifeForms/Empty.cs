// <copyright file="Empty.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
// </copyright> 

namespace GameOfLife.Library.LifeForms
{
    using GameOfLife.Basics;

    /// <summary>
    /// A completely empty universe.
    /// </summary>
    public class Empty : LifeFormBase
    {
        /// <summary>
        /// Initializes a new instance of the Empty class.
        /// </summary>
        public Empty()
            : base(0, 0)
        {
            var pattern = new[] 
            {
                new[] { 0 }
            };

            SetPattern(pattern);
        }
    }
}

// eof