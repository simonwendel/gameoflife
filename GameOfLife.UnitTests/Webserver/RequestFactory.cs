// <copyright file="RequestFactory.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.Webserver
{
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Hosting;

    /// <summary>
    /// Produces request for API controllers, to be used in testing.
    /// </summary>
    internal static class RequestFactory
    {
        /// <summary>
        /// Assigns a new request message and configuration object to a controller.
        /// </summary>
        /// <param name="controller">The API controller to configure.</param>
        public static void CreateRequestFor(ApiController controller)
        {
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
        }
    }
}
