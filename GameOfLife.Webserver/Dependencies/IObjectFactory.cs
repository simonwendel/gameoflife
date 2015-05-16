// <copyright file="IObjectFactory.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Webserver.Dependencies
{
    using System;

    /// <summary>
    /// A factory creating objects for consumption of controllers and services.
    /// </summary>
    internal interface IObjectFactory
    {
        /// <summary>
        /// Register an object as resolution target for a specified type.
        /// </summary>
        /// <typeparam name="T">The type to register for.</typeparam>
        /// <param name="constant">The resolution target.</param>
        void Provide<T>(object constant);

        /// <summary>
        /// Builds an object of a specified type.
        /// </summary>
        /// <typeparam name="T">The type for which to resolve dependencies and build.</typeparam>
        /// <returns>The resulting object.</returns>
        T Build<T>();

        /// <summary>
        /// Builds an object of a specified type.
        /// </summary>
        /// <param name="type">The type for which to resolve dependencies and build.</param>
        /// <returns>The resulting object.</returns>
        object Build(Type type);
    }
}
