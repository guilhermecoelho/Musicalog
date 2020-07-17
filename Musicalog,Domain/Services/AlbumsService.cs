using Musicalog_Domain.Entities;
using Musicalog_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Musicalog_Domain.Services
{
    public class AlbumsService : ServiceBase<AlbumsDomain>, IAlbumsService
    {

        private readonly IAlbumRepository _albumRepository;

        public AlbumsService(IAlbumRepository albumRepository) :base(albumRepository)
        {
            _albumRepository = albumRepository;
        }

    }
}
