﻿// <copyright file="LinqGame.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2016.
// </copyright>

namespace GameOfLife.LinqLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GameOfLife.Basics;

    /// <summary>
    /// A game using the Linq algorithm for the universe and when stepping.
    /// </summary>
    public class LinqGame : GameBase
    {
        /// <summary>The current generation.</summary>
        private int generation;

        /// <summary>The universe at the moment.</summary>
        private Universe universe;

        /// <summary>
        /// Initializes a new instance of the LinqGame class.
        /// </summary>
        /// <param name="formatter">The formatter to output state by.</param>
        /// <param name="rules">The rules for running the game.</param>
        public LinqGame(RulesBase rules)
            : base(rules)
        {
            generation = 0;
            universe = new Universe();
        }

        /// <summary>
        /// Event fired after the game steps one generation into the future.
        /// </summary>
        public event EventHandler<GameStepEventArgs> GameStepEvent;

        /// <summary>
        /// Gets the current population of the universe.
        /// </summary>
        public override int Population
        {
            get { return universe.Population; }
        }

        /// <summary>
        /// Gets the current generation.
        /// </summary>
        public override int Generation
        {
            get { return generation; }
        }

        /// <summary>
        /// Steps the game one generation into the future.
        /// </summary>
        public override void StepForward()
        {
            var deadCells = new List<Cell>();
            var newCells = new List<Cell>();

            ++generation;
            if (Population > 0)
            {
                var currentState = new Universe(universe); // copy the state of the universe
                List<Cell> cellsToCheck = currentState.AllCells;

                // linq magic, where we check all cells already in the universe
                // and also all of their neighbors. since the speed of light is
                // 1 in game of life, this is sufficient.
                cellsToCheck.AddRange(
                    from cell in currentState.AllCells
                    from neighbor in currentState.ListAllPossibleNeighbors(cell.X, cell.Y)
                    where !cellsToCheck.Contains(neighbor)
                    select neighbor);

                foreach (var cell in cellsToCheck)
                {
                    int numberOfNeighbors = currentState.CountLivingNeighbors(cell.X, cell.Y);
                    bool aliveNow = currentState.HasCell(cell.X, cell.Y);
                    bool aliveNext = Rules.AliveNextGeneration(aliveNow, numberOfNeighbors);

                    if (aliveNow && !aliveNext)
                    {
                        universe.Remove(cell);
                        deadCells.Add(cell);
                    }

                    if (!aliveNow && aliveNext)
                    {
                        universe.Add(cell);
                        newCells.Add(cell);
                    }
                }
            }

            if (GameStepEvent != null)
            {
                var stepInformation = new GameStepEventArgs(deadCells, newCells);
                GameStepEvent(this, stepInformation);
            }
        }

        /// <summary>
        /// Initializes the game from an integer pattern.
        /// </summary>
        /// <param name="pattern">An integer pattern, where <value>1</value> is a cell and
        /// <value>0</value> is not.</param>
        public override void InitializeFrom(int[][] pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException(paramName: "pattern");
            }

            universe = new Universe(pattern);
        }
    }
}
