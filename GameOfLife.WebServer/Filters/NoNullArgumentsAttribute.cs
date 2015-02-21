// <copyright file="NoNullArgumentsAttribute.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.WebServer.Filters
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    /// <summary>
    /// Action filter to validate all models coming into the Web API, returning a detailed HTTP 400 
    /// Bad Request response if any parameter to the action method is null.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class NoNullArgumentsAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Occurs before the action method is invoked.
        /// </summary>
        /// <param name="context">The action context.</param>
        public override void OnActionExecuting(HttpActionContext context)
        {
            var nullParameters = context.ActionArguments
                .Where(x => x.Value == null)
                .Select(x => x.Key);

            if (nullParameters.Count() > 0)
            {
                var keys = string.Join(", ", nullParameters);
                var message = string.Format(
                    "Null arguments not allowed to method {0}.{1}. Offending parameters: {2}",
                    context.ActionDescriptor.ControllerDescriptor.ControllerName,
                    context.ActionDescriptor.ActionName,
                    keys);

                context.Response = context.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, message);
            }
        }
    }
}

// eof