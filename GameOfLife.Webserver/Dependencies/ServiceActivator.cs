// <copyright file="ServiceActivator.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Webserver.Dependencies
{
    using System;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;

    /// <summary>
    /// A service activator the is to be injected into the Web API pipeline and used for
    /// resolving dependencies and wiring up API controllers.
    /// </summary>
    internal class ServiceActivator : IHttpControllerActivator
    {
        private IObjectFactory factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceActivator"/> class.
        /// </summary>
        /// <param name="factory">
        /// The object factory used for building objects and resolving dependencies.
        /// </param>
        public ServiceActivator(IObjectFactory factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// Creates an <see cref="IHttpController"/> object.
        /// </summary>
        /// <param name="request">The message request.</param>
        /// <param name="controllerDescriptor">The HTTP controller descriptor.</param>
        /// <param name="controllerType">The type of the controller.</param>
        /// <returns>An <see cref="IHttpController"/> object.</returns>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return (IHttpController)factory.Build(controllerType);
        }
    }
}
