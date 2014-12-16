// <copyright file="IOModuleTests.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
// </copyright> 

namespace GameOfLife.UnitTests.Web.Dependencies
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.Basics;
    using GameOfLife.Web.Dependencies;
    using GameOfLife.Web.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;

    /// <summary>
    /// Unit tests (and somewhat integration tests) the IOModule class from 
    /// the GameOfLife.Web.Dependencies namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class IOModuleTests
    {
        /// <summary>
        /// When passing an IOModule instance to the Ninject standard kernel 
        /// the bindings we expect are actually bound.
        /// </summary>
        [TestMethod]
        public void WebIOModuleTestsLoadCorrectlyBindsServices()
        {
            // act
            using (var module = new IOModule())
            using (var kernel = new StandardKernel(module))
            {
                // assert
                Assert.IsTrue(
                    kernel.HasModule("GameOfLife.Web.Dependencies.IOModule"),
                    message: "The IO module was not loaded");

                Assert.IsNotNull(
                    kernel.Get<IWriter>() as EmptyWriter,
                    message: "The IWriter interface was resolved incorrectly.");
            }
        }
    }
}

// eof