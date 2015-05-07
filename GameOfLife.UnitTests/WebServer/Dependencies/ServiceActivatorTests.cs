﻿// <copyright file="ServiceActivatorTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.WebServer.Dependencies
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using GameOfLife.WebServer.Dependencies;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Tests the service activator used for resolving dependencies and wiring up 
    /// API controllers.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ServiceActivatorTests
    {
        /// <summary>
        /// The create method on the activator should delegate responsibility of 
        /// actually building objects to the IObjectFactory on which it depends.
        /// </summary>
        [TestMethod]
        public void CreateUsesObjectFactoryToCreateController()
        {
            // arrange
            var mockFactory = new Mock<IObjectFactory>();
            mockFactory.Setup(x => x.Build(It.IsAny<Type>()));
            var serviceActivator = new ServiceActivator(mockFactory.Object);

            // act
            serviceActivator.Create(
                Mock.Of<HttpRequestMessage>(),
                Mock.Of<HttpControllerDescriptor>(),
                typeof(ServiceActivatorTests));

            // assert
            mockFactory.Verify(x => x.Build(It.IsAny<Type>()), Times.Once);
        }
    }
}