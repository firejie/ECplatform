using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Sql;
using System.Configuration;
using MySql.Data.MySqlClient;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        
        MusicStoreEntities storeDB = new MusicStoreEntities();

        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();

            return View(genres);
        }

        public ActionResult Browser(string genre)
        {
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);

            return View(genreModel);
        }

        public ActionResult Details(int id)
        {
            var album = storeDB.Albums.Find(id);
            return View(album);
        }
    }
}
