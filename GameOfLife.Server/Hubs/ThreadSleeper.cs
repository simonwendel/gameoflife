// <copyright file="ThreadSleeper.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

namespace GameOfLife.Server.Hubs
{
    using System.Configuration;
    using System.Threading;

    /// <summary>
    /// An <see cref="IThreadSleeper" /> implementation using an app setting for configuring the
    /// sleep period.
    /// </summary>
    /// <remarks>
    /// Uses the <value>gameStepSleepPeriod</value> app setting to configure the sleep period in
    /// milliseconds.
    /// </remarks>
    public class ThreadSleeper : IThreadSleeper
    {
        private int sleepPeriod;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreadSleeper" /> class.
        /// </summary>
        public ThreadSleeper()
        {
            SetSleepPeriod();
        }

        /// <summary>
        /// Will sleep the current thread for the configured period of time.
        /// </summary>
        public void Sleep()
        {
            Thread.Sleep(sleepPeriod);
        }

        private void SetSleepPeriod()
        {
            var sleepConfiguration = ConfigurationManager.AppSettings["gameStepSleepPeriod"];
            if (!int.TryParse(sleepConfiguration, out sleepPeriod))
            {
                sleepPeriod = 0;
            }
        }
    }
}
