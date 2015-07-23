using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Store/

        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
          
            return View(genres);
        }
        public ActionResult Browse(string genre)
        {
            //linq
            //var genremodel = storeDB.Genres.Single(g => g.Name == genre);
            var genremodel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);
            return View(genremodel);
        }
        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Find(id);
            return View(album);
        }
        //只能用于部分视图，不能在浏览器中直接访问
        [ChildActionOnly]
        public ActionResult GenreMenu()
        {
            var genres = storeDB.Genres.ToList();
            return PartialView(genres);
        }

    }
}
