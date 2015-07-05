// <copyright file="ObjectFactoryBootstrapper.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Webserver.Dependencies
{
    using System;
    using GameOfLife.Basics;
    using Ninject;

    /// <summary>
    /// Provides an <see cref="IBootstrapper"/> implementation using the <see cref="IKernel"/>
    /// service to wire up dependencies.
    /// </summary>
    internal class NinjectBootstrapper : IBootstrapper
    {
        private IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectBootstrapper"/> class.
        /// </summary>
        /// <param name="kernel">The <see cref="IKernel"/> instance to use for building games.</param>
        public NinjectBootstrapper(IKernel kernel)
        {
            this.kernel = kernel;
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
                kernel.Rebind<RulesBase>().ToConstant(rules);
                return kernel.Get<T>();
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
