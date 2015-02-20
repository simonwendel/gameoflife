// <copyright file="ResolverBootstrapper.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.WebServer.Dependencies
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;
    using GameOfLife.Basics;
    using Ninject;
    using Ninject.Modules;

    /// <summary>
    /// Provides inversion of control by acting as both an MVC dependency resolver 
    /// and a bootstrapper.
    /// </summary>
    public class ResolverBootstrapper : IBootstrapper, IDependencyResolver, IDisposable
    {
        /// <summary>The ninject kernel to use for binding dependencies.</summary>
        private IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the ResolverBootstrapper class.
        /// </summary>
        /// <param name="modules">The ninject modules providing initial bindings.</param>
        public ResolverBootstrapper(params INinjectModule[] modules)
        {
            kernel = new StandardKernel(modules);
            kernel.Bind<IBootstrapper>().ToConstant<ResolverBootstrapper>(this);
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
            catch (Ninject.ActivationException ex)
            {
                throw new BootFailedException(
                    message: "Boot of the game failed.",
                    inner: ex);
            }
        }

        /// <summary>
        /// Resolves a service by type.
        /// </summary>
        /// <param name="serviceType">The type of service to resolve.</param>
        /// <returns>A new instance of the specified type.</returns>
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        /// <summary>
        /// Resolves services by type.
        /// </summary>
        /// <param name="serviceType">The type of the services to resolve.</param>
        /// <returns>All instances of the specified type.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        /// <summary>
        /// Starts a resolution scope.
        /// </summary>
        /// <returns>The dependency scope.</returns>
        public IDependencyScope BeginScope()
        {
            return this;
        }

        /// <summary>
        /// Disposes of disposable resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of disposable resources, if flagged to do so.
        /// </summary>
        /// <param name="disposing">If <value>true</value>, managed resources will 
        /// be disposed.</param>
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

// eof