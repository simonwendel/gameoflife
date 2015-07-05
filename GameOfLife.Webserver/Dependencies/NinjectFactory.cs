// <copyright file="NinjectFactory.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Webserver.Dependencies
{
    using System;
    using Ninject;

    /// <summary>
    /// An <see cref="IObjectFactory"/> implementation based on Ninject as an IoC container.
    /// </summary>
    internal class NinjectFactory : IObjectFactory, IDisposable
    {
        private IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectFactory"/> class.
        /// </summary>
        /// <param name="kernel">The <see cref="IKernel"/> providing dependency registration.</param>
        public NinjectFactory(IKernel kernel)
        {
            this.kernel = kernel;
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

        /// <summary>
        /// Disposes the disposable resources used by the NinjectFactory instance.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the disposable resources used by the NinjectFactory instance.
        /// </summary>
        /// <param name="disposing">
        /// If true, the disposable resources of the NinjectFactory instance will be disposed.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (kernel != null)
                {
                    kernel.Dispose();
                    kernel = null;
                }
            }
        }
    }
}
