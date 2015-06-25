// <copyright file="IGameClientContract.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Webserver.Hubs
{
    using GameOfLife.Basics;

    /// <summary>
    /// Contract all game clients should implement on the receiving side.
    /// </summary>
    public interface IGameClientContract
    {
        /// <summary>
        /// Displays an error to the user.
        /// </summary>
        /// <param name="error">The complete error output.</param>
        void DisplayError(string error);

        /// <summary>
        /// Displays the results of a game run to the user.
        /// </summary>
        /// <param name="results">The results to render/display.</param>
        void DisplayResults(GameBase results);
    }
}
