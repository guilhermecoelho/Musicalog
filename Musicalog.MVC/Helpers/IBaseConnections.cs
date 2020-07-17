using Musicalog.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.MVC.Helpers
{
    public interface IBaseConnections
    {
        AlbumsGetResponse GetAlbums(int pageNumber, string sortBy, bool isAsc = true);
        AlbumsModel GetAlbumById(int id);
        AlbumsModel Save(AlbumsModel albumsModel);
        AlbumsModel Remove(int Id);
    }
}
