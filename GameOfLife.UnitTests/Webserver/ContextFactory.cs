// <copyright file="ContextFactory.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

/*
 * NOTICE:
 * -------
 * This is a simplified version of the ContextUtil class from the test suite for the
 * Web API source code tree, with the modification of cleanup of names, access modifiers and
 * parameter lists.
 *
 * Original source file is of course
 * Copyright (c) Microsoft Open Technologies, Inc. All rights reserved.
 *
 * LICENSE:
 * ---------------------
 * Licensed under the Apache License, Version 2.0 (the "License"); you
 * may not use this file except in compliance with the License. You may
 * obtain a copy of the License at

 * http://www.apache.org/licenses/LICENSE-2.0

 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
 * implied. See the License for the specific language governing permissions
 * and limitations under the License.
 * ---------------------
 *
 * Original file from
 * https://aspnetwebstack.codeplex.com/SourceControl/latest#test/System.Web.Http.Test/Util/ContextUtil.cs
 * at commit 5fa60ca38b5837cc843b5d4552113f9a0235c3bf.
 */

namespace GameOfLife.UnitTests.Webserver
{
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Routing;
    using Moq;

    /// <summary>
    /// Produces Web API contexts.
    /// </summary>
    internal static class ContextFactory
    {
        /// <summary>
        /// Creates a complete <see cref="HttpActionContext"/> object to use in testing.
        /// </summary>
        /// <returns>An action context completely wired up.</returns>
        public static HttpActionContext CreateActionContext()
        {
            var context = CreateControllerContext();
            var descriptor = CreateActionDescriptor();

            descriptor.ControllerDescriptor = context.ControllerDescriptor;
            return new HttpActionContext(context, descriptor);
        }

        private static HttpControllerContext CreateControllerContext()
        {
            var route = new HttpRouteData(new HttpRoute());

            using (var configuration = new HttpConfiguration())
            using (var request = new HttpRequestMessage())
            {
                request.SetConfiguration(configuration);
                request.SetRouteData(route);

                var context = new HttpControllerContext(configuration, route, request);
                context.ControllerDescriptor = CreateControllerDescriptor(configuration);

                return context;
            }
        }

        private static HttpControllerDescriptor CreateControllerDescriptor(HttpConfiguration configuration)
        {
            return new HttpControllerDescriptor()
            {
                Configuration = configuration,
                ControllerName = "FakeController"
            };
        }

        private static HttpActionDescriptor CreateActionDescriptor()
        {
            var mock = new Mock<HttpActionDescriptor>
            {
                CallBase = true
            };

            mock
                .SetupGet(d => d.ActionName)
                .Returns("ActionName");

            return mock.Object;
        }
    }
}
