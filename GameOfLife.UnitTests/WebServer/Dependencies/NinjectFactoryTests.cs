// <copyright file="NinjectFactoryTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.WebServer.Dependencies
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using GameOfLife.WebServer.Dependencies;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Ninject.Modules;
    using Ninject.Syntax;
    using Ninject.Syntax.Fakes;

    /// <summary>
    /// Unit tests the NinjectFactory class from the GameOfLife.WebServer.Dependencies
    /// namespace.
    /// </summary>
    [TestClass, ExcludeFromCodeCoverage]
    public class NinjectFactoryTests
    {
        private interface ITestInterface
        {
        }

        /// <summary>
        /// The non-generic Build method should simply return according to injected modules.
        /// </summary>
        [TestMethod]
        public void Build_GivenRegisteredType_ReturnsCorrectlyTypedObject()
        {
            // arrange
            var expected = new TestClass();
            using (var module = new TestModule(typeof(ITestInterface), expected))
            {
                var factory = new NinjectFactory(module);

                // act
                var actual = factory.Build(typeof(ITestInterface));

                // assert
                Assert.AreSame(actual, expected, "The correct reference was not returned.");
            }
        }

        /// <summary>
        /// The generic Build method should simply return according to injected modules.
        /// </summary>
        [TestMethod]
        public void BuildOfT_GivenRegisteredType_ReturnsCorrectlyTypedObject()
        {
            // arrange
            var expected = new TestClass();
            using (var module = new TestModule(typeof(ITestInterface), expected))
            {
                var factory = new NinjectFactory(module);

                // act
                var actual = factory.Build<ITestInterface>();

                // assert
                Assert.AreSame(actual, expected, "The correct reference was not returned.");
            }
        }

        /// <summary>
        /// Provide should call the Rebind{T} method on the StandardKernel to register
        /// a constant in the IoC container. Relies on Microsoft Fakes Framework.
        /// </summary>
        [TestMethod]
        [TestCategory(TestUsing.Fakes)]
        public void ProvideOfT_GivenTypeAndObject_BindsObjectWithNinject()
        {
            using (ShimsContext.Create())
            {
                // arrange
                var mockSyntax = Mock.Of<IBindingToSyntax<object>>();

                var mockBindingRoot = new Mock<IBindingRoot>();
                mockBindingRoot
                    .Setup(x => x.Rebind<object>())
                    .Returns(mockSyntax);

                ShimBindingRoot.AllInstances
                    .RebindOf1<object>((val) => mockBindingRoot.Object.Rebind<object>());

                var factory = new NinjectFactory();

                // act
                factory.Provide<object>(new object());

                // assert
                mockBindingRoot.Verify(x => x.Rebind<object>(), Times.Once);
            }
        }

        private class TestClass : ITestInterface
        {
        }

        private class TestModule : NinjectModule
        {
            private object constant;
            private Type type;

            public TestModule(Type type, object constant)
            {
                this.type = type;
                this.constant = constant;
            }

            public override void Load()
            {
                Bind(type).ToConstant(constant);
            }
        }
    }
}
