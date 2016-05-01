// <copyright file="GameBase.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Basics
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A game to run.
    /// </summary>
    public abstract class GameBase
    {
        /// <summary>The rules governing the game.</summary>
        private RulesBase rules;

        /// <summary>The stopwatch to time each run.</summary>
        private Stopwatch stopwatch;

        /// <summary>
        /// Initializes a new instance of the GameBase class.
        /// </summary>
        /// <param name="formatter">The object performing game state output.</param>
        /// <param name="rules">The rules to run the game.</param>
        protected GameBase(RulesBase rules)
        {
            if (rules == null)
            {
                throw new ArgumentNullException(paramName: "rules");
            }
            
            this.rules = rules;
            stopwatch = new Stopwatch();
        }

        /// <summary>
        /// Gets the population
        /// </summary>
        public abstract int Population { get; }

        /// <summary>
        /// Gets the current generation.
        /// </summary>
        public abstract int Generation { get; }

        /// <summary>
        /// Gets the number of milliseconds the last run took.
        /// </summary>
        public long LastRuntime
        {
            get
            {
                return stopwatch.ElapsedMilliseconds;
            }
        }

        /// <summary>
        /// Gets the rules governing the game.
        /// </summary>
        protected RulesBase Rules
        {
            get
            {
                return rules;
            }
        }

        /// <summary>
        /// Initializes the game from an integer pattern.
        /// </summary>
        /// <param name="pattern">An integer pattern, where <value>1</value> is a cell and
        /// <value>0</value> is not.</param>
        public abstract void InitializeFrom(int[][] pattern);

        /// <summary>
        /// Steps the game one generation into the future.
        /// </summary>
        public abstract void StepForward();

        /// <summary>
        /// Runs the game for a specific number of generations into the future.
        /// </summary>
        /// <param name="generations">The number of generations to run for.</param>
        public virtual void RunThrough(int generations)
        {
            stopwatch.Restart();

            while (generations-- > 0)
            {
                StepForward();
            }

            stopwatch.Stop();
        }
    }
}
