﻿// <copyright file="IOModuleTests.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.UnitTests.WebServer.Dependencies
{
    using GameOfLife.Basics;
    using GameOfLife.WebServer.Dependencies;
    using GameOfLife.WebServer.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Ninject;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Unit tests (and somewhat integration tests) the IOModule class from 
    /// the GameOfLife.WebServer.Dependencies namespace.
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
                    kernel.HasModule("GameOfLife.WebServer.Dependencies.IOModule"),
                    message: "The IO module was not loaded");

                Assert.IsNotNull(
                    kernel.Get<IWriter>() as EmptyWriter,
                    message: "The IWriter interface was resolved incorrectly.");
            }
        }
    }
}

// eof