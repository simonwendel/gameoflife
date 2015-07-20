// <copyright file="AssertExtension.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Tests
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
        private const string NoExceptionMessage =
            "AssertExtension.Throws<T> failed. No exception was thrown.";

        private const string WrongExceptionTypeMessage =
            "AssertExtension.Throws<T> failed. Expected:<{0}>. Actual:<{1}>.";

        /// <summary>
        /// When passed in an action, that action should be invoked and checked for throwing
        /// an exception of specified type.
        /// </summary>
        /// <typeparam name="T">The type of exception to check for.</typeparam>
        /// <param name="action">The action to be invoked and checked for exceptions.</param>
        /// <exception cref="AssertFailedException">
        /// Thrown if the action does not throw an exception of type T.
        /// </exception>
        public static void Throws<T>(Action action) where T : Exception
        {
            Throws<T>(action, string.Empty);
        }

        /// <summary>
        /// When passed in an action, that action should be invoked and checked for throwing
        /// an exception of specified type.
        /// </summary>
        /// <typeparam name="T">The type of exception to check for.</typeparam>
        /// <param name="action">The action to be invoked and checked for exceptions.</param>
        /// <param name="message">A message to display if the assertion fails. This message can be seen in the unit test results.</param>
        /// <param name="parameters">An array of parameters to use when formatting <paramref name="message"/>.</param>
        public static void Throws<T>(Action action, string message, params object[] parameters) where T : Exception
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
                message = BuildMessageForWrongException<T>(message, parameters, ex);
                throw new AssertFailedException(message, ex);
            }

            throw new AssertFailedException(NoExceptionMessage);
        }

        private static string BuildMessageForWrongException<ExpectedType>(string message, object[] parameters, Exception actualException) where ExpectedType : Exception
        {
            var culture = CultureInfo.CurrentCulture;
            var expectedType = typeof(ExpectedType).GetType().Name;
            var actualType = actualException.GetType().Name;

            message = string.Format(
                culture,
                WrongExceptionTypeMessage,
                expectedType,
                actualType);

            if (parameters.Length > 0)
            {
                message = string.Concat(message, " {0}");
                message = string.Format(culture, message, parameters);
            }

            return message;
        }
    }
}
