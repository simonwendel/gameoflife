// <copyright file="NinjectFactory.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.WebServer.Dependencies
{
    using System;
    using Ninject;
    using Ninject.Modules;

    /// <summary>
    /// An <see cref="IObjectFactory"/> implementation based on Ninject as an IoC container.
    /// </summary>
    internal class NinjectFactory : IObjectFactory
    {
        private IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectFactory"/> class.
        /// </summary>
        /// <param name="modules">Ninject modules binding dependencies to implementations.</param>
        public NinjectFactory(params INinjectModule[] modules)
        {
            kernel = new StandardKernel(modules);
            kernel.Bind<IObjectFactory>().ToConstant<NinjectFactory>(this);
        }

        /// <summary>
        /// Register an object as resolution target for a specified type.
        /// </summary>
        /// <typeparam name="T">The type to register for.</typeparam>
        /// <param name="constant">The resolution target.</param>
        public void Provide<T>(object constant)
        {
            kernel.Rebind<T>().ToConstant((T)constant);
        }

        /// <summary>
        /// Builds an object of a specified type.
        /// </summary>
        /// <typeparam name="T">The type for which to resolve dependencies and build.</typeparam>
        /// <returns>The resulting object.</returns>
        public T Build<T>()
        {
            return (T)kernel.Get<T>();
        }

        /// <summary>
        /// Builds an object of a specified type.
        /// </summary>
        /// <param name="type">The type for which to resolve dependencies and build.</param>
        /// <returns>The resulting object.</returns>
        public object Build(Type type)
        {
            return kernel.Get(type);
        }
    }
}
