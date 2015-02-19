// <copyright file="FilterConfig.cs" company="N/A"> 
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright> 

namespace GameOfLife.WebServer
{
    using System.Web.Mvc;

    /// <summary>
    /// Configures global filters.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Register MVC filters with a collection.
        /// </summary>
        /// <param name="filters">Global filter collection to map into.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
