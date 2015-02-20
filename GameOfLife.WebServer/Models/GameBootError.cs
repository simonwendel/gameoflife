// <copyright file="GameBootError.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.WebServer.Models
{
    /// <summary>
    /// An error message to the client that game boot failed.
    /// </summary>
    public class GameBootError
    {
        /// <summary>
        /// Gets or sets a value explaining the failure.
        /// </summary>
        public string Message { get; set; }
    }
}