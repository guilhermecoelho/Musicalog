using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Musicalog.api.Requests;
using Musicalog.api.Responses;
using Musicalog.API.Entitites;
using Musicalog.API.Responses;
using Musicalog.Applications.Interfaces;
using Musicalog.Applications.Requests;
using Musicalog_Domain.Entities;
using Musicalog_Domain.Interfaces;

namespace Musicalog.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumsAppService _albumsAppService;
        private readonly IMapper _mapper;

        public AlbumsController(IAlbumsAppService albumsAppService, IMapper mapper)
        {
            _albumsAppService = albumsAppService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get")]
        public AlbumsGetResponse Get([FromQuery] AlbumsRequest request)
        {
            AlbumsGetResponse albumResponse = new AlbumsGetResponse();
            albumResponse.ListAlbums = new List<Album>();

            GetAllAlbumsByFilterRequest getAllAlbumsByFilterRequest = _mapper.Map<GetAllAlbumsByFilterRequest>(request);

            var appServiceResponse = _albumsAppService.GetAllAlbumsByFilter(getAllAlbumsByFilterRequest);

            albumResponse = _mapper.Map<AlbumsGetResponse>(appServiceResponse);


            return albumResponse;
        }

        [HttpGet]
        [Route("GetById")]
        public Album GetById([FromQuery] int Id)
        {
            Album albumResponse = new Album();

            var appServiceResponse = _albumsAppService.GetById(Id);

            albumResponse = _mapper.Map<Album>(appServiceResponse);


            return albumResponse;
        }

        [HttpPost]
        [Route("save")]
        public AlbumSaveResponse Save([FromBody] AlbumSaveRequest request)
        {
            AlbumsDomain requestDomain = _mapper.Map<AlbumsDomain>(request);


            var serviceResponse =  _albumsAppService.Add(requestDomain);

            var albumResponse = _mapper.Map<AlbumSaveResponse>(serviceResponse);

            return albumResponse;
        }

        [HttpPost]
        [Route("update")]
        public AlbumUpdateResponse Update([FromBody] AlbumUpdateRequest request)
        {
            AlbumsDomain requestDomain = _mapper.Map<AlbumsDomain>(request);

            var serviceResponse = _albumsAppService.Update(requestDomain);

            var albumResponse = _mapper.Map<AlbumUpdateResponse>(serviceResponse);

            return albumResponse;
        }

        [HttpPost]
        [Route("remove")]
        public AlbumRemoveResponse Remove(AlbumRemoveRequest request)
        {
            AlbumsDomain requestDomain = _mapper.Map<AlbumsDomain>(request);

            var serviceResponse = _albumsAppService.Remove(requestDomain);

            var albumResponse = _mapper.Map<AlbumRemoveResponse>(serviceResponse);

            return albumResponse;
        }
    }
}
