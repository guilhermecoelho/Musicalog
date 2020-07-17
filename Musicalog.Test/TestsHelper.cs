using AutoMapper;
using Musicalog.api.Requests;
using Musicalog.api.Responses;
using Musicalog.API.Entitites;
using Musicalog.API.Responses;
using Musicalog.Applications.Entities;
using Musicalog.Applications.Requests;
using Musicalog.Applications.Responses;
using Musicalog_Domain.Entities;

namespace Musicalog.Test
{
    public class TestsHelper
    {

        public IMapper MapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<AlbumsDomain, AlbumsApp>();
                cfg.CreateMap<AlbumsRequest, GetAllAlbumsByFilterRequest>();
                cfg.CreateMap<AlbumsApp, Album>();
                cfg.CreateMap<GetAllAlbumsByFilterResponse, AlbumsGetResponse>();
                cfg.CreateMap<AlbumSaveRequest, AlbumsDomain>();
                cfg.CreateMap<AlbumsDomain, AlbumSaveResponse>();
                cfg.CreateMap<AlbumUpdateResponse, AlbumsDomain>();
                cfg.CreateMap<AlbumsDomain, AlbumUpdateResponse>();
                cfg.CreateMap<AlbumRemoveResponse, AlbumsDomain>();
                cfg.CreateMap<AlbumsDomain, AlbumRemoveRequest>();
                cfg.CreateMap<AlbumsDomain, Album>();
                cfg.CreateMap<AlbumUpdateRequest, AlbumsDomain>();
                cfg.CreateMap<AlbumRemoveRequest, AlbumsDomain>();
                cfg.CreateMap<AlbumsDomain, AlbumRemoveResponse>();
            });

            return config.CreateMapper();
        }
    }
}
