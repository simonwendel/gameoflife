// <copyright file="IBootstrapper.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
// </copyright> 

namespace GameOfLife.Basics
{
    /// <summary>
    /// Common interface for bootstrappers.
    /// </summary>
    public interface IBootstrapper
    {
        /// <summary>
        /// Boots a game by resolving all dependencies and instantiating a 
        /// new game object.
        /// </summary>
        /// <typeparam name="T">The type of the game to boot.</typeparam>
        /// <param name="rules">The rules to use for the game.</param>
        /// <returns>A new game object, or <value>null</value> if resolution fails.</returns>
        /// <exception cref="BootFailedException">Thrown if the boot fails for 
        /// some reason.</exception>
        GameBase Boot<T>(RulesBase rules) where T : GameBase;
    }
}

// eof