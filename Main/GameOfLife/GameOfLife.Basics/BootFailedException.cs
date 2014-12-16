// <copyright file="BootFailedException.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013.
// </copyright> 

/*
 * This is excluded from code coverage metrics, since there really 
 * is nothing to test.
 */

namespace GameOfLife.Basics
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    /// <summary>
    /// An exception signaling that booting a game failed.
    /// </summary>
    [Serializable, ExcludeFromCodeCoverage]
    public class BootFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the BootFailedException class.
        /// </summary>
        public BootFailedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the BootFailedException class with a specified 
        /// error message.
        /// </summary>
        /// <param name="message">The message that describes the error. </param>
        public BootFailedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BootFailedException class with a specified 
        /// error message and a reference to the inner exception that is the cause of 
        /// this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null 
        /// reference if no inner exception is specified.</param>
        public BootFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the BootFailedException class with 
        /// serialized data.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object 
        /// data about the exception being thrown.</param>
        /// <param name="context">The StreamingContext that contains contextual information 
        /// about the source or destination.</param>
        protected BootFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

// eof