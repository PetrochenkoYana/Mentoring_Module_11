using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcMusicStore.Infrastracture;
using MvcMusicStore.Models;
using NLog;
using PerformanceCounterHelper;
using ILogger = MvcMusicStore.Logger.ILogger;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly MusicStoreEntities _storeContext = new MusicStoreEntities();
        private readonly Logger.ILogger logger;

        static CounterHelper<Counters> counterHelper;

        static HomeController()
        {
            counterHelper = PerformanceHelper.CreateCounterHelper<Counters>("Counters");
        }

        public HomeController(ILogger logger)
        {
            this.logger = logger;
        }
        // GET: /Home/
        public async Task<ActionResult> Index()
        {
            logger.LogDebug("Enter to Home");
            counterHelper.Increment(Counters.GoHome);
            return View(await _storeContext.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(6)
                .ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _storeContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}