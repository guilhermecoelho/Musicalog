using Musicalog.API.Entitites;
using Musicalog_Domain.Entities;
using System.Collections.Generic;

namespace Musicalog.API.Responses
{
    public class AlbumsGetResponse : BaseResponse
    {
        public List<Album> ListAlbums { get; set; }
    }
}
