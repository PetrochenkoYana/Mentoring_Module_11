using PerformanceCounterHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MvcMusicStore.Infrastracture
{
    [PerformanceCounterCategory("MvcMusicStore",
        System.Diagnostics.PerformanceCounterCategoryType.MultiInstance,
        "MvcMusicStore")]
    public enum Counters
    {
        [PerformanceCounter("Succesful logins", "Succesful logins", PerformanceCounterType.NumberOfItems32)]
        SuccessfulLogin,

        [PerformanceCounter("Succesful logoffs", "Succesful logoffs", PerformanceCounterType.NumberOfItems32)]
        SuccessfulLogoff,

        [PerformanceCounter("Go Home", "Go Home", PerformanceCounterType.NumberOfItems32)]
        GoHome
    }
}