﻿// <copyright file="IOModule.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Webserver.Dependencies
{
    using GameOfLife.Basics;
    using GameOfLife.Webserver.IO;
    using Ninject.Modules;

    /// <summary>
    /// Registers IO dependencies for the MVC application.
    /// </summary>
    internal class IOModule : NinjectModule
    {
        /// <summary>
        /// Binds dependencies with the IoC container at run-time.
        /// </summary>
        public override void Load()
        {
            Bind<IFormatter>().ToConstant(new EmptyFormatter());
        }
    }
}