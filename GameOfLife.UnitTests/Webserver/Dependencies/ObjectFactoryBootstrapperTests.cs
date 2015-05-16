// <copyright file="ObjectFactoryBootstrapperTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.Webserver.Dependencies
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.Basics;
    using GameOfLife.Webserver.Dependencies;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Unit tests the ObjectFactoryBootstrapper class from the GameOfLife.WebServer.Dependencies
    /// namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class ObjectFactoryBootstrapperTests
    {
        /// <summary>
        /// The Boot method should call the IObjectFactory instance provided to the constructor
        /// and use the product as a return statement.
        /// </summary>
        [TestMethod]
        public void Boot_GivenRulesBase_CallsObjectFactoryAndReturnsGame()
        {
            // arrange
            var expected = CreateMockGameBaseImplementation();

            var mockFactory = new Mock<IObjectFactory>();
            mockFactory
                .Setup(x => x.Provide<IObjectFactory>(It.IsAny<object>()));

            mockFactory
                .Setup(x => x.Build<GameBase>())
                .Returns(expected);

            var bootstrapper = new ObjectFactoryBootstrapper(mockFactory.Object);

            // act
            var actual = bootstrapper.Boot<GameBase>(CreateMockRulesBaseImplementation());

            // assert
            Assert.AreSame(expected, actual, "Wrong game reference was returned from the bootstrapper.");
        }

        /// <summary>
        /// The Boot method should catch all exceptions and rethrow them as part of a more
        /// application specific BootFailedException.
        /// </summary>
        [TestMethod]
        [ExpectedException(
            typeof(BootFailedException),
            "Boot method did not throw correct exception.")]
        public void Boot_WhenObjectFactoryThrowsException_ThrowsException()
        {
            // arrange
            var mockFactory = new Mock<IObjectFactory>();
            mockFactory
                .Setup(x => x.Provide<IObjectFactory>(It.IsAny<object>()));

            mockFactory
                .Setup(x => x.Build<GameBase>())
                .Throws(Mock.Of<Exception>());

            var bootstrapper = new ObjectFactoryBootstrapper(mockFactory.Object);

            // act
            bootstrapper.Boot<GameBase>(CreateMockRulesBaseImplementation());
        }

        private static GameBase CreateMockGameBaseImplementation()
        {
            var mockGameBase = new Mock<GameBase>(Mock.Of<IFormatter>(), CreateMockRulesBaseImplementation());
            return mockGameBase.Object;
        }

        private static RulesBase CreateMockRulesBaseImplementation()
        {
            var mockRulesBase = new Mock<RulesBase>(new int[] { }, new int[] { });
            return mockRulesBase.Object;
        }
    }
}
