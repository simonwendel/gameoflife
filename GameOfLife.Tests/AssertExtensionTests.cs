// <copyright file="AssertExtensionTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2016.
// </copyright>

namespace GameOfLife.Tests
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests the AssertExtension class.
    /// </summary>
    [TestClass]
    public class AssertExtensionTests
    {
        /// <summary>
        /// When Throws{T} is given an action that does not throw an exception,
        /// an AssertFailedException is thrown instead.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void ThrowsOfT_GivenActionNotThrowingAtAll_ThrowsException()
        {
            // arrange
            var obj = new object();

            try
            {
                // act
                AssertExtension.Throws<Exception>(() => { obj = null; });
            }
            catch (AssertFailedException ex)
            {
                // assert
                var expectedMessage =
                    "AssertExtension.Throws<T> failed. No exception was thrown.";

                Assert.AreEqual(expectedMessage, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The Throws{T} should throw AssertFailedException when the action
        /// passed in throws an exception not of type T.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void ThrowsOfT_GivenActionThrowingNotT_ThrowsException()
        {
            try
            {
                // act
                AssertExtension.Throws<ArgumentException>(() => { throw new NotImplementedException(); });
            }
            catch (AssertFailedException ex)
            {
                // assert
                var expectedMessage =
                    "AssertExtension.Throws<T> failed. Expected:<ArgumentException>. Actual:<NotImplementedException>.";

                Assert.AreEqual(expectedMessage, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// If the action passed to Throws{T} throws the correct type of exception,
        /// the method should quietly return.
        /// </summary>
        [TestMethod]
        public void ThrowsOfT_GivenActionThrowingT_Passes()
        {
            // act / assert
            AssertExtension.Throws<ArgumentException>(() => { throw new ArgumentException("somearg"); });
        }

        /// <summary>
        /// When Throws{T} is given an action that does not throw an exception,
        /// an AssertFailedException is thrown instead. The exception message
        /// includes the formatted message.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Globalization",
            "CA1303:Do not pass literals as localized parameters",
            MessageId = "GameOfLife.Tests.AssertExtension.Throws<System.Exception>(System.Action,System.String,System.Object[])",
            Justification = "A resource table for this is just silly.")]
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void ThrowsOfT_GivenMessageAndActionNotThrowingAtAll_ThrowsException()
        {
            // arrange
            var obj = new object();

            try
            {
                // act
                AssertExtension.Throws<Exception>(() => { obj = null; }, "some mess{0}.", "age");
            }
            catch (AssertFailedException ex)
            {
                // assert
                var expectedMessage =
                    "AssertExtension.Throws<T> failed. No exception thrown. some message.";

                Assert.AreEqual(expectedMessage, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// The Throws{T} should throw AssertFailedException when the action
        /// passed in throws an exception not of type T. The exception message
        /// includes the formatted message.
        /// </summary>
        [SuppressMessage(
            "Microsoft.Globalization",
            "CA1303:Do not pass literals as localized parameters",
            MessageId = "GameOfLife.Tests.AssertExtension.Throws<System.ArgumentException>(System.Action,System.String,System.Object[])",
            Justification = "A resource table for this is just silly.")]
        [TestMethod]
        [ExpectedException(typeof(AssertFailedException))]
        public void ThrowsOfT_GivenMessageAndActionThrowingNotT_ThrowsException()
        {
            try
            {
                // act
                AssertExtension.Throws<ArgumentException>(
                    () => { throw new NotImplementedException(); }, "some mess{0}.", "age");
            }
            catch (AssertFailedException ex)
            {
                // assert
                var expectedMessage =
                    "AssertExtension.Throws<T> failed. Expected:<ArgumentException>. Actual:<NotImplementedException>. some message.";

                Assert.AreEqual(expectedMessage, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// When the Throws{T} method is given <value>null</value> <paramref name="action"/>
        /// an <see cref="ArgumentNullException"/> is thrown.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowsOfT_GivenNullAction_ThrowsException()
        {
            // act / assert
            AssertExtension.Throws<NotImplementedException>(null);
        }
    }
}
