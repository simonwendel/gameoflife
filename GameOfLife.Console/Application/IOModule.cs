// <copyright file="IOModule.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Console.Application
{
    using GameOfLife.Basics;
    using GameOfLife.Console.IO;
    using Ninject.Modules;

    /// <summary>
    /// Registers dependencies for the console application.
    /// </summary>
    internal class IOModule : NinjectModule
    {
        /// <summary>
        /// Binds dependencies with the IoC container at run-time .
        /// </summary>
        public override void Load()
        {
            Bind<IFormatter>().ToConstant(new StatsFormatter());
        }
    }
}
