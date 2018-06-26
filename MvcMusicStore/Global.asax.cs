using PerformanceCounterHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcMusicStore.Infrastracture;
using MvcMusicStore.Util;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using ILogger = MvcMusicStore.Logger.ILogger;

namespace MvcMusicStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILogger logger;

        static MvcApplication()
        {
            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            logger = (ILogger)DependencyResolver.Current.GetService(typeof(ILogger));
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Creation of counters
            using (var counterHelper = PerformanceHelper.CreateCounterHelper<Counters>("Counters"))
            {
                counterHelper.RawValue(Counters.SuccessfulLogin, 0);
                counterHelper.RawValue(Counters.SuccessfulLogoff, 0);
                counterHelper.RawValue(Counters.GoHome, 0);
            }

            logger.LogInfo("Application Started");
        }
    }
}
