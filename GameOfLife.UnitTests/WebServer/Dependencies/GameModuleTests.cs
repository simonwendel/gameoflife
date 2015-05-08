﻿// <copyright file="GameModuleTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.WebServer.Dependencies
{
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.Basics;
    using GameOfLife.WebServer.Dependencies;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Ninject;

    /// <summary>
    /// Unit tests (and somewhat integration tests) the GameModule class from
    /// the GameOfLife.WebServer.Dependencies namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class GameModuleTests
    {
        /// <summary>
        /// When passing an GameModule instance to the Ninject standard kernel
        /// the bindings we expect are actually bound.
        /// </summary>
        [TestMethod]
        public void WebIOModuleTestsLoadCorrectlyBindsServices()
        {
            // act
            using (var module = new GameModule())
            using (var kernel = new StandardKernel(module))
            {
                kernel.Bind<IObjectFactory>().ToConstant(Mock.Of<IObjectFactory>());

                // assert
                Assert.IsTrue(
                    kernel.HasModule("GameOfLife.WebServer.Dependencies.GameModule"),
                    message: "The IO module was not loaded");

                Assert.IsNotNull(
                    kernel.Get<IBootstrapper>() as ObjectFactoryBootstrapper,
                    message: "The IWriter interface was resolved incorrectly.");
            }
        }
    }
}
