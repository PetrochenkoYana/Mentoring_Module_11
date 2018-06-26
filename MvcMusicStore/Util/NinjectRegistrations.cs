using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using NLog;
using ILogger = MvcMusicStore.Logger.ILogger;

namespace MvcMusicStore.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<Logger.Logger>();
        }
    }
}