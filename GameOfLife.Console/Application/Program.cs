// <copyright file="Program.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
// </copyright> 

/*
 * This class is excluded from code coverage metrics, as it is 
 * a plain and standard application entry point.
 */

namespace GameOfLife.Console.Application
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using CommandLine;
    using GameOfLife.Library.Factories;
    using GameOfLife.LinqLife;

    /// <summary>
    /// The main program class harboring the application entry point.
    /// </summary>
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        /// <summary>
        /// This is the main application entry point from the system.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        internal static void Main(string[] args)
        {
            var options = new GameSettings();
            if (!CommandLine.Parser.Default.ParseArguments(args, options))
            {
                // requirements of cmdline arguments not met, or some other fatal error
                // pertaining to the args array.
                Environment.Exit(1);
            }

            var rules = RuleFactory.Build(options.Rules);
            var lifeForm = LifeFormFactory.Build(options.InitialPattern);

            using (var bootstrapper = new Bootstrapper())
            {
                var game = bootstrapper.Boot<LinqGame>(rules: rules);
                game.InitializeFrom(lifeForm.GetPattern());
                game.RunThrough(generations: options.NumberOfGenerations);
                var state = game.WriteOut();
                Console.WriteLine(state);
            }
        }
    }
}

// eof