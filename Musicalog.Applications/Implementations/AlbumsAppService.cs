using AutoMapper;
using Microsoft.Extensions.Configuration;
using Musicalog.Applications.Entities;
using Musicalog.Applications.Interfaces;
using Musicalog.Applications.Requests;
using Musicalog.Applications.Responses;
using Musicalog_Domain.Entities;
using Musicalog_Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Musicalog.Applications.Implementations
{
    public class AlbumsAppService : AppServiceBase<AlbumsDomain>, IAlbumsAppService
    {

        private readonly IAlbumsService _albumService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AlbumsAppService(IAlbumsService albumService, IMapper mapper, IConfiguration configuration) : base(albumService)
        {
            _albumService = albumService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public GetAllAlbumsByFilterResponse GetAllAlbumsByFilter(GetAllAlbumsByFilterRequest request)
        {
            GetAllAlbumsByFilterResponse response = new GetAllAlbumsByFilterResponse();

            response.ListAlbums = new List<AlbumsApp>();

            var responseService = _albumService.GetAll();

            response.ListAlbums = _mapper.Map<List<AlbumsApp>>(responseService);

            string generalSettings = _configuration.GetSection("GeneralSettings").GetSection("PageSize").Value;

            int pageSize = String.IsNullOrEmpty(generalSettings) ? 10 : Convert.ToInt32(generalSettings);

            response.totalItens = response.ListAlbums.Count();
            response.PageSize = pageSize;
            response.PageNumber = request.PageNumber;

            response.ListAlbums = OrderList(response.ListAlbums, request.SortBy, request.IsAsc);

            response.ListAlbums = response.ListAlbums
                .Skip((request.PageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
           
            return response;
        }

        private List<AlbumsApp> OrderList(List<AlbumsApp> ListAlbums, string orderBy, bool? isAsc = true)
        {
            isAsc = isAsc == null ? true : isAsc;
            return orderBy switch
            {
                "name" => (bool)isAsc ? ListAlbums.OrderBy(x => x.Name).ToList() : ListAlbums.OrderByDescending(x => x.Name).ToList(),
                "artist" => (bool)isAsc ? ListAlbums.OrderBy(x => x.Artist).ToList() : ListAlbums.OrderByDescending(x => x.Artist).ToList(),
                "label" => (bool)isAsc ? ListAlbums.OrderBy(x => x.Label).ToList() : ListAlbums.OrderByDescending(x => x.Label).ToList(),
                "stock" => (bool)isAsc ? ListAlbums.OrderBy(x => x.Stock).ToList() : ListAlbums.OrderByDescending(x => x.Stock).ToList(),
                "albumTypeId" => (bool)isAsc ? ListAlbums.OrderBy(x => x.AlbumTypeId).ToList() : ListAlbums.OrderByDescending(x => x.AlbumTypeId).ToList(),
                _ => ListAlbums,
            };
        }
    }
}
