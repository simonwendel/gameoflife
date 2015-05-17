// <copyright file="AssertExtensionTests.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.UnitTests
{
    using System;
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
                    "No exception thrown.";

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
                    "Exception of type ArgumentException expected, was of type NotImplementedException.";

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
    }
}
