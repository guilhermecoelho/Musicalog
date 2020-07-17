using Musicalog.Applications.Entities;
using Musicalog_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musicalog.Applications.Responses
{
    public class GetAllAlbumsByFilterResponse : BaseResponse
    {

        public List<AlbumsApp> ListAlbums { get; set; }
    }
}
