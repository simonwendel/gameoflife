// <copyright file="IThreadSleeper.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Server.Hubs
{
    /// <summary>
    /// Service that can be used to halt a thread for some time.
    /// </summary>
    public interface IThreadSleeper
    {
        /// <summary>
        /// Will sleep the current thread.
        /// </summary>
        void Sleep();
    }
}
