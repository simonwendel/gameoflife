// <copyright file="ObjectFactoryBootstrapper.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.WebServer.Dependencies
{
    using System;
    using GameOfLife.Basics;

    /// <summary>
    /// Provides inversion of control by acting as both an MVC dependency resolver
    /// and a bootstrapper.
    /// </summary>
    internal class ObjectFactoryBootstrapper : IBootstrapper
    {
        private IObjectFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectFactoryBootstrapper"/> class.
        /// </summary>
        /// <param name="factory">The <see cref="IObjectFactory"/> instance to use for building games.</param>
        public ObjectFactoryBootstrapper(IObjectFactory factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// Boots a new game by resolving all dependencies.
        /// </summary>
        /// <typeparam name="T">The type of the game to boot.</typeparam>
        /// <param name="rules">The rules to use when running the game.</param>
        /// <returns>A new game object.</returns>
        public GameBase Boot<T>(RulesBase rules) where T : GameBase
        {
            try
            {
                factory.Provide<RulesBase>(rules);
                return factory.Build<T>();
            }
            catch (Exception ex)
            {
                throw new BootFailedException(
                    message: "Booting the game failed successfully.", // true dat!
                    inner: ex);
            }
        }
    }
}

// eof
