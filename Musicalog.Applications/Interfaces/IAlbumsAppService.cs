using Musicalog.Applications.Requests;
using Musicalog.Applications.Responses;
using Musicalog_Domain.Entities;
using System.Collections.Generic;

namespace Musicalog.Applications.Interfaces
{
    public interface IAlbumsAppService : IAppServiceBase<AlbumsDomain>
    {
        GetAllAlbumsByFilterResponse GetAllAlbumsByFilter(GetAllAlbumsByFilterRequest request);
    }
}
