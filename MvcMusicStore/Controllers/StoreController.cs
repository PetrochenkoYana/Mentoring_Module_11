using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcMusicStore.Models;
using MvcMusicStore.Logger;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly MusicStoreEntities _storeContext = new MusicStoreEntities();
        private readonly Logger.ILogger logger;

        public StoreController(ILogger logger)
        {
            this.logger = logger;
        }

        // GET: /Store/
        public async Task<ActionResult> Index()
        {
            logger.LogError(new ApplicationException("error"), "MessageError");
            return View(await _storeContext.Genres.ToListAsync());
        }

        // GET: /Store/Browse?genre=Disco
        public async Task<ActionResult> Browse(string genre)
        {
            return View(await _storeContext.Genres.Include("Albums").SingleAsync(g => g.Name == genre));
        }

        public async Task<ActionResult> Details(int id)
        {
            var album = await _storeContext.Albums.FindAsync(id);

            return album != null ? View(album) : (ActionResult)HttpNotFound();
        }

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            return PartialView(
                _storeContext.Genres.OrderByDescending(
                    g => g.Albums.Sum(a => a.OrderDetails.Sum(od => od.Quantity))).Take(9).ToList());
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