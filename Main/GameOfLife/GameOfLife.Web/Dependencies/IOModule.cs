﻿// <copyright file="IOModule.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
// </copyright> 

namespace GameOfLife.Web.Dependencies
{
    using GameOfLife.Basics;
    using GameOfLife.Web.IO;
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