using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Musicalog.MVC.Helpers;
using Musicalog.MVC.Models;

namespace Musicalog.MVC.Controllers
{
    public class AlbumDetailsController : Controller
    {
        private readonly IBaseConnections _baseConnections;

        public AlbumDetailsController(IBaseConnections baseConnections)
        {
            _baseConnections = baseConnections;
        }

        // GET: AlbumDetailsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AlbumDetailsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AlbumDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AlbumDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlbumDetailsController/Edit/5
        public ActionResult Edit(int id)
        {
            AlbumsModel album = _baseConnections.GetAlbumById(id);
            return View(album);
        }

        // POST: AlbumDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AlbumDetailsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AlbumDetailsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
