using Musicalog_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicalog.MVC.Models
{
    public class AlbumsGetResponse : BaseResponse
    {
        public List<AlbumsModel> ListAlbums = new List<AlbumsModel>();
    }
}
