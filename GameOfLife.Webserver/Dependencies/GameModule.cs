// <copyright file="GameModule.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Webserver.Dependencies
{
    using GameOfLife.Basics;
    using Ninject.Modules;

    /// <summary>
    /// Registers game dependencies for the MVC application.
    /// </summary>
    internal class GameModule : NinjectModule
    {
        /// <summary>
        /// Binds dependencies with the IoC container at run-time.
        /// </summary>
        public override void Load()
        {
            Bind<IBootstrapper>().To<ObjectFactoryBootstrapper>();
        }
    }
}
