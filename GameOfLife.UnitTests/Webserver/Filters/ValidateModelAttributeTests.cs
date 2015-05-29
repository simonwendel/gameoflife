// <copyright file="ValidateModelAttributeTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests.Webserver.Filters
{
    using System.Net;
    using System.Web.Http.Controllers;
    using GameOfLife.Webserver.Filters;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the action filter that makes sure all parameters to an
    /// API controller are actually correct after model binding.
    /// </summary>
    [TestClass]
    public class ValidateModelAttributeTests
    {
        /// <summary>
        /// If the model state includes errors a HTTP 400 - Bad Request
        /// should be set in response.
        /// </summary>
        [TestMethod]
        public void OnActionExecuting_GivenInvalidModel_CreatesBadRequestResponse()
        {
            // arrange
            var context = ContextFactory.CreateActionContext();
            context.ModelState.AddModelError("error", "an error has occurred");

            var filter = new ValidateModelAttribute();

            // act
            filter.OnActionExecuting(context);

            // assert
            Assert.IsNotNull(context.Response);
            Assert.AreEqual(context.Response.StatusCode, HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// If the model state is valid, no change in the response should be made.
        /// </summary>
        [TestMethod]
        public void OnActionExecuting_GivenValidModel_DoesNothing()
        {
            // arrange
            var context = new HttpActionContext();
            var filter = new ValidateModelAttribute();

            // act
            filter.OnActionExecuting(context);

            // assert
            Assert.IsNull(context.Response);
        }
    }
}
