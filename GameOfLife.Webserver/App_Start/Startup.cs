// <copyright file="Startup.cs" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

[assembly: Microsoft.Owin.OwinStartup(typeof(GameOfLife.Webserver.App_Start.Startup))]

namespace GameOfLife.Webserver.App_Start
{
    using GameOfLife.Basics;
    using GameOfLife.Webserver.Dependencies;
    using GameOfLife.Webserver.IO;
    using Microsoft.AspNet.SignalR;
    using Ninject;
    using Owin;

    /// <summary>
    /// OWIN Startup class.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures an OWIN application.
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
