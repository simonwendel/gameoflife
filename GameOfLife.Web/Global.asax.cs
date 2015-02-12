// <copyright file="Global.asax.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

/*
 * This class is excluded from code coverage metrics, as it is 
 * a plain and standard MVC 3 application entry point.
 */

namespace GameOfLife.Web
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Mvc;
    using System.Web.Routing;
    using GameOfLife.Web.Dependencies;

    /// <summary>
    /// The main web application front end for this Game Of Life.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class GameOfLifeHttpApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Handles all wire-up on application star by registering areas, filters and routes.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Reliability",
            "CA2000:Dispose objects before losing scope",
            Justification = "I think this will be disposed by the dep resolver on app take-down.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "Marking as static crashes wire-up.")]
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            DependencyResolver.SetResolver(
                new ResolverBootstrapper(new[] 
                { 
                    new IOModule() 
                }));
        }

        /// <summary>
        /// Registers filters with a global filter collection.
        /// </summary>
        /// <param name="filters">The collection to register global filters with.</param>
        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        /// <summary>
        /// Registers routes with the routing system via a route collection.
        /// </summary>
        /// <param name="routes">The collection to register routes with.</param>
        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}", // URL with parameters
                new { controller = "Home", action = "Index" });
        }
    }
}

// eof