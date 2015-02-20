// <copyright file="IOModule.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.WebServer.Dependencies
{
    using GameOfLife.Basics;
    using GameOfLife.WebServer.IO;
    using Ninject.Modules;

    /// <summary>
    /// Registers IO dependencies for the MVC application.
    /// </summary>
    public class IOModule : NinjectModule
    {
        /// <summary>
        /// Binds dependencies with the IoC container at run-time.
        /// </summary>
        public override void Load()
        {
            Bind<IWriter>().ToConstant(new EmptyWriter());
        }
    }
}

// eof