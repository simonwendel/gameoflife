// <copyright file="Bootstrapper.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.Console.Application
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using GameOfLife.Basics;
    using Ninject;
    using Ninject.Modules;

    /// <summary>
    /// Bootstrapper resolving dependencies for types in the domain.
    /// </summary>
    public class Bootstrapper : IDisposable, IBootstrapper
    {
        /// <summary>The ninject kernel to use for resolving.</summary>
        private IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the Bootstrapper class.
        /// </summary>
        public Bootstrapper()
        {
            var modules = GetModules().ToArray();
            kernel = new StandardKernel(modules);
        }

        /// <summary>
        /// Resolves all dependencies for the type specified and returns an object 
        /// of that type, or <value>null</value> if unsuccessful.
        /// </summary>
        /// <typeparam name="T">The type of the object to create.</typeparam>
        /// <param name="rules">The rules of the game.</param>
        /// <returns>An instance of the specified type, or <value>null</value> if 
        /// unsuccessful resolving dependencies.</returns>
        public GameBase Boot<T>(RulesBase rules) where T : GameBase
        {
            try
            {
                kernel.Bind<RulesBase>().ToConstant(rules);
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
        /// Disposes all resources used by the bootstrapper.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Does the actual disposing according to the disposing flag.
        /// </summary>
        /// <param name="disposing">If <value>true</value>, all undisposed 
        /// resources will be disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                var registeredModules = kernel.GetModules().Cast<NinjectModule>();
                foreach (var module in registeredModules)
                {
                    module.Dispose();
                }

                kernel.Dispose();
            }
        }

        /// <summary>
        /// Enumerates all <c>Ninject</c> modules in the preset namespace.
        /// </summary>
        /// <returns>An enumerable collection of <c>Ninject</c> modules.</returns>
        private static IEnumerable<NinjectModule> GetModules()
        {
            string setting = ConfigurationManager.AppSettings.Get("ModuleNamespace");
            if (setting == null)
            {
                throw new ConfigurationErrorsException(
                    message: "Ninject module namespace not set.");
            }

            var splitSetting = setting
                .Split(',')
                .Select(s => s.Trim()).ToArray();

            var moduleNamespace = splitSetting[0];
            var assembly = Assembly.Load(splitSetting[1]);

            foreach (var moduleType in GetModuleTypes(moduleNamespace, assembly))
            {
                if (moduleType.BaseType == typeof(NinjectModule))
                {
                    // yup a class derived from NinjectModule found, get instance!
                    yield return Activator.CreateInstance(moduleType) as NinjectModule;
                }
            }
        }

        /// <summary>
        /// Retrieves an enumerable collection of types from the specified namespace.
        /// </summary>
        /// <param name="moduleNamespace">The namespace to iterate to find modules.</param>
        /// <param name="assembly">The assembly to load modules from.</param>
        /// <returns>An enumerable collection of System.Type objects.</returns>
        private static IEnumerable<Type> GetModuleTypes(string moduleNamespace, Assembly assembly)
        {
            return assembly.GetTypes().Where(type => string.Equals(
                type.Namespace,
                moduleNamespace,
                StringComparison.OrdinalIgnoreCase));
        }
    }
}

// eof