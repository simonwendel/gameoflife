// <copyright file="RulesBase.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
// </copyright> 

namespace GameOfLife.Basics
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The base class of all rules.
    /// </summary>
    public abstract class RulesBase
    {
        /// <summary>
        /// Initializes a new instance of the RulesBase class.
        /// </summary>
        /// <param name="birthCount">A collection of birth counts defining this rule.</param>
        /// <param name="survivalCount">A collection of survival counts defining this rule.</param>
        protected RulesBase(IEnumerable<int> birthCount, IEnumerable<int> survivalCount)
        {
            BirthCount = new List<int>(birthCount.OrderBy(x => x));
            SurvivalCount = new List<int>(survivalCount.OrderBy(x => x));
        }

        /// <summary>
        /// Gets a list of different numbers of neighbors triggering the birth of a dead cell.
        /// </summary>
        public IList<int> BirthCount { get; private set; }

        /// <summary>
        /// Gets a list of different numbers of neighbors allowing the survival of a living cell.
        /// </summary>
        public IList<int> SurvivalCount { get; private set; }

        /// <summary>
        /// Calculates whether a cell should be alive the next generation or not.
        /// </summary>
        /// <param name="cellAlive">A value indicating whether the cell in question is alive or not.</param>
        /// <param name="numberOfNeighbors">The number of neighbors the cell has.</param>
        /// <returns><value>true</value> if the cell should be alive, or 
        /// <value>false</value> if not.</returns>
        public bool AliveNextGeneration(bool cellAlive, int numberOfNeighbors)
        {
            if (cellAlive && SurvivalCount.Contains(numberOfNeighbors))
            {
                return true;
            }

            if (!cellAlive && BirthCount.Contains(numberOfNeighbors))
            {
                return true;
            }

            return false;
        }
    }
}

// eof