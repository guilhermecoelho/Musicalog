using System;

using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Musicalog.MVC.Helpers;
using Musicalog.MVC.Models;


namespace Musicalog.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration; 
        private readonly IBaseConnections _baseConnections;

        AlbumsViewModel albumsViewModel = new AlbumsViewModel();


        public IQueryable<AlbumsModel> Album { get; set; }


        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IBaseConnections baseConnections)
        {
            _logger = logger;
            _configuration = configuration;
            _baseConnections = baseConnections;
        }


        public IActionResult Index(int page, string sortOrder)
        {

            ViewData["NameSort"] = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewData["ArtistSort"] = String.IsNullOrEmpty(sortOrder) ? "artist" : "";
            ViewData["AlbumTypeSort"] = String.IsNullOrEmpty(sortOrder) ? "albumType" : "";
            ViewData["StockSort"] = String.IsNullOrEmpty(sortOrder) ? "stock" : "";


            var serviceResponse = _baseConnections.GetAlbums(page, sortOrder );

            albumsViewModel.AlbumsModels = serviceResponse.ListAlbums;
            albumsViewModel.PageSize = serviceResponse.PageSize;
            albumsViewModel.PageIndex = page;

            return View(albumsViewModel);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AlbumDetails(int id)
        {
            AlbumsModel album = new AlbumsModel();

            if (id != 0)
                album = _baseConnections.GetAlbumById(id);

            return View(album);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlbumDetails(AlbumsModel albumsModel)
        { 
            try
            {
                if (ModelState.IsValid)
                {
                    _baseConnections.Save(albumsModel);
                    return RedirectToAction(nameof(Index));
                }

                return View(albumsModel);

            }
            catch
            {
                return View(albumsModel);
            }
        }

        public ActionResult AlbumDelete(int id)
        {
            try
            {
                _baseConnections.Remove(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
