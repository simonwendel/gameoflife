// <copyright file="AssertExtension.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests
{
    using System;
    using System.Globalization;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Defines static extensions to the Assert class from the Microsoft
    /// unit testing framework.
    /// </summary>
    public static class AssertExtension
    {
        /// <summary>
        /// When passed in an action, that action should be invoked and checked for throwing
        /// an exception of specified type.
        /// </summary>
        /// <typeparam name="T">The type of exception to check for.</typeparam>
        /// <param name="action">The action to be invoked.</param>
        /// <exception cref="AssertFailedException">
        /// Thrown if the action does not throw an exception of type T.
        /// </exception>
        public static void Throws<T>(Action action) where T : Exception
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            try
            {
                action();
            }
            catch (T)
            {
                return;
            }
            catch (Exception ex)
            {
                var expectedType = typeof(T).GetType().Name;
                var actualType = ex.GetType().Name;
                var message = string.Format(
                    CultureInfo.CurrentCulture,
                    "Exception of type {0} expected, was of type {1}.",
                    expectedType,
                    actualType);

                throw new AssertFailedException(message, ex);
            }

            throw new AssertFailedException("No exception thrown.");
        }
    }
}
