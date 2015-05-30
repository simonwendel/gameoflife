// <copyright file="NoNullArgumentsAttributeTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.Webserver.Filters
{
    using System.Net;
    using GameOfLife.Webserver.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the action filter that makes sure no parameters to an
    /// API controller action method are null after model binding.
    /// </summary>
    [TestClass]
    public class NoNullArgumentsAttributeTests
    {
        /// <summary>
        /// If the context has no arguments at all, then nothing should
        /// happen to the response.
        /// </summary>
        [TestMethod]
        public void OnActionExecuting_GivenNoArguments_DoesNothing()
        {
            // arrange
            var context = ContextFactory.CreateActionContext();
            var filter = new NoNullArgumentsAttribute();

            // act
            filter.OnActionExecuting(context);

            // assert
            Assert.IsNull(context.Response);
        }

        /// <summary>
        /// If the context does have arguments, but none of them are null, then
        /// nothing should happen to the response.
        /// </summary>
        [TestMethod]
        public void OnActionExecuting_GivenNoNullArguments_DoesNothing()
        {
            // arrange
            var context = ContextFactory.CreateActionContext();
            var filter = new NoNullArgumentsAttribute();

            context.ActionArguments.Add("anArgument", new object());
            context.ActionArguments.Add("anotherArgument", new object());

            // act
            filter.OnActionExecuting(context);

            // assert
            Assert.IsNull(context.Response);
        }

        /// <summary>
        /// If the context does have arguments, but none of them are null, then
        /// nothing should happen to the response.
        /// </summary>
        [TestMethod]
        public void OnActionExecuting_GivenNullArgument_CreatesBadRequestResponse()
        {
            // arrange
            var context = ContextFactory.CreateActionContext();
            var filter = new NoNullArgumentsAttribute();

            context.ActionArguments.Add("anArgument", new object());
            context.ActionArguments.Add("anotherArgument", null);

            // act
            filter.OnActionExecuting(context);

            // assert
            Assert.IsNotNull(context.Response);
            Assert.AreEqual(context.Response.StatusCode, HttpStatusCode.BadRequest);
        }
    }
}
