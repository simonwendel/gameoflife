// <copyright file="IOModuleTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.Console.Application
{
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.Basics;
    using GameOfLife.Console.Application;
    using GameOfLife.Console.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;

    /// <summary>
    /// Tests the IOModule class from the GameOfLife.Console.Application
    /// namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class IOModuleTests
    {
        /// <summary>
        /// When passing an IOModule instance to the Ninject standard kernel
        /// the bindings we expect are actually bound.
        /// </summary>
        [TestMethod]
        public void Load_WhenPassedToKernel_CorrectlyBindsServices()
        {
            // act
            using (var module = new IOModule())
            using (var kernel = new StandardKernel(module))
            {
                // assert
                Assert.IsTrue(
                    kernel.HasModule("GameOfLife.Console.Application.IOModule"),
                    message: "The IO module was not loaded");

                Assert.IsNotNull(
                    kernel.Get<IFormatter>() as StatsFormatter,
                    message: "The IFormatter interface was resolved incorrectly.");
            }
        }
    }
}
