// <copyright file="Startup.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

[assembly: Microsoft.Owin.OwinStartup("GameOfLife.SignalR", typeof(GameOfLife.Server.Startup))]

namespace GameOfLife.Server
{
    using GameOfLife.Basics;
    using GameOfLife.Server.Dependencies;
    using GameOfLife.Server.IO;
    using Microsoft.AspNet.SignalR;
    using Ninject;
    using Owin;

    /// <summary>
    /// OWIN Startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures OWIN application for SignalR.
        /// </summary>
        /// <param name="application"><see cref="IAppBuilder" /> to configure.</param>
        public void Configuration(IAppBuilder application)
        {
            var kernel = new StandardKernel();

            kernel.Bind<IBootstrapper>().ToConstant(new NinjectBootstrapper(kernel));
            kernel.Bind<IFormatter>().ToConstant(new EmptyFormatter());

            var resolver = new NinjectDependencyResolver(kernel);
            var config = new HubConfiguration();
            config.Resolver = resolver;

            application.MapSignalR(config);
        }
    }
}
