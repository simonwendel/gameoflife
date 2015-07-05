// <copyright file="NinjectDependencyResolver.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>
namespace GameOfLife.Webserver.Dependencies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNet.SignalR;
    using Ninject;

    /// <summary>
    /// Uses Ninject to wire up dependencies for SignalR applications.
    /// </summary>
    internal class NinjectDependencyResolver : DefaultDependencyResolver
    {
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectDependencyResolver" /> class.
        /// </summary>
        /// <param name="kernel">A Ninject IKernel to use for lookups.</param>
        public NinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Resolves singly registered services that support arbitrary object creation.
        /// </summary>
        /// <param name="serviceType">The type of the requested service or object.</param>
        /// <returns>The requested service or object.</returns>
        public override object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType) ?? base.GetService(serviceType);
        }

        /// <summary>
        /// Resolves multiply registered services.
        /// </summary>
        /// <param name="serviceType">The type of the requested services.</param>
        /// <returns>The requested services.</returns>
        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType).Concat(base.GetServices(serviceType));
        }
    }
}
