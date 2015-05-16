// <copyright file="ServiceActivatorTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.Webserver.Dependencies
{
    using System;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using GameOfLife.Webserver.Dependencies;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Tests the service activator used for resolving dependencies and wiring up
    /// API controllers.
    /// </summary>
    [TestClass]
    public class ServiceActivatorTests
    {
        /// <summary>
        /// The create method on the activator should delegate responsibility of
        /// actually building objects to the IObjectFactory on which it depends.
        /// </summary>
        [TestMethod]
        public void Create_GivenRequest_CallsObjectFactoryAndReturnsController()
        {
            // arrange
            var expected = Mock.Of<IHttpController>();

            var mockFactory = new Mock<IObjectFactory>();
            mockFactory
                .Setup(x => x.Build(It.IsAny<Type>()))
                .Returns(expected);

            var serviceActivator = new ServiceActivator(mockFactory.Object);

            // act
            var actual = serviceActivator.Create(
                Mock.Of<HttpRequestMessage>(),
                Mock.Of<HttpControllerDescriptor>(),
                typeof(ServiceActivatorTests));

            // assert
            Assert.AreSame(expected, actual, "Wrong IHttpController reference was returned.");

            mockFactory.Verify(
                x => x.Build(It.IsAny<Type>()),
                Times.Once);
        }
    }
}
