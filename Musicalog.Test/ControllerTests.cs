using AutoMapper;
using Moq;
using Musicalog.api.Controllers;
using Musicalog.api.Requests;
using Musicalog.Applications.Entities;
using Musicalog.Applications.Interfaces;
using Musicalog.Applications.Requests;
using Musicalog.Applications.Responses;
using Musicalog_Domain.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Musicalog.Test
{
    public class ControllerTests : TestsHelper
    {

        private AlbumsController controller;

        private GetAllAlbumsByFilterResponse getAllAlbumsByFilterResponse;

        private IMapper _mapper;

        private Mock<IAlbumsAppService> albumAppServiceMock;


        [SetUp]
        internal void Setup()
        {

            _mapper = MapperConfiguration();

            getAllAlbumsByFilterResponse = new GetAllAlbumsByFilterResponse();
            getAllAlbumsByFilterResponse.ListAlbums = new List<AlbumsApp> {
                  new AlbumsApp
                    {
                        Artist = "artist",
                        Id = 1,
                        Label = "label",
                        Name = "name",
                        Stock = 1
                    },
                     new AlbumsApp
                    {
                        Artist = "artist 2",
                        Id = 2,
                        Label = "label 2",
                        Name = "name 2",
                        Stock = 1
                    }
            };

            albumAppServiceMock = new Mock<IAlbumsAppService>();


            controller = new AlbumsController(albumAppServiceMock.Object, _mapper);
        }


        [Fact]
        public void GetAllSuccess()
        {
            Setup();

            AlbumsRequest request = new AlbumsRequest();

            albumAppServiceMock.Setup(p => p.GetAllAlbumsByFilter(It.IsAny<GetAllAlbumsByFilterRequest>())).Returns(getAllAlbumsByFilterResponse);


            var result = controller.Get(request);

            Assert.AreEqual(result.ListAlbums.Count, 2);

        }
        [Fact]
        public void GetAllSuccess_pageSize()
        {
            Setup();

            AlbumsRequest request = new AlbumsRequest();
            request.PageSize = 1;


            getAllAlbumsByFilterResponse.ListAlbums = getAllAlbumsByFilterResponse.ListAlbums
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();


            albumAppServiceMock.Setup(p => p.GetAllAlbumsByFilter(It.IsAny<GetAllAlbumsByFilterRequest>())).Returns(getAllAlbumsByFilterResponse);


            var result = controller.Get(request);

            Assert.AreEqual(result.ListAlbums.Count, 1);
            Assert.AreEqual(result.ListAlbums[0].Id, 1);

        }

        [Fact]
        public void GetAllSuccess_pageNumber_first()
        {
            Setup();

            AlbumsRequest request = new AlbumsRequest();
            request.PageSize = 1;
            request.PageNumber = 1;


            getAllAlbumsByFilterResponse.ListAlbums = getAllAlbumsByFilterResponse.ListAlbums
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();


            albumAppServiceMock.Setup(p => p.GetAllAlbumsByFilter(It.IsAny<GetAllAlbumsByFilterRequest>())).Returns(getAllAlbumsByFilterResponse);


            var result = controller.Get(request);

            Assert.AreEqual(result.ListAlbums.Count, 1);
            Assert.AreEqual(result.ListAlbums[0].Id, 1);

        }

        [Fact]
        public void GetAllSuccess_pageNumber_second()
        {
            Setup();

            AlbumsRequest request = new AlbumsRequest();
            request.PageSize = 1;
            request.PageNumber = 2;


            getAllAlbumsByFilterResponse.ListAlbums = getAllAlbumsByFilterResponse.ListAlbums
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();


            albumAppServiceMock.Setup(p => p.GetAllAlbumsByFilter(It.IsAny<GetAllAlbumsByFilterRequest>())).Returns(getAllAlbumsByFilterResponse);


            var result = controller.Get(request);

            Assert.AreEqual(result.ListAlbums.Count, 1);
            Assert.AreEqual(result.ListAlbums[0].Id, 2);
        }

        [Fact]
        public void Save_success()
        {
            Setup();

            AlbumsDomain responseService = new AlbumsDomain
            {
                Artist = "artist 2",
                Id = 2,
                Label = "label",
                Name = "name 2",
                Stock = 1
            };

            AlbumSaveRequest request = new AlbumSaveRequest
            {
                Artist = "artist 2",
                Label = "label",
                Name = "name 2",
                Stock = 1
            };

            albumAppServiceMock.Setup(p => p.Add(It.IsAny<AlbumsDomain>())).Returns(responseService);


            var result = controller.Save(request);

        }

        [Fact]
        public void Update_success()
        {
            Setup();

            AlbumsDomain responseService = new AlbumsDomain
            {
                Artist = "artist 2",
                Id = 2,
                Label = "label",
                Name = "name 2",
                Stock = 1
            };

            AlbumUpdateRequest request = new AlbumUpdateRequest
            {
                Artist = "artist 2",
                Label = "label",
                Name = "name 2",
                Stock = 1
            };

            albumAppServiceMock.Setup(p => p.Update(It.IsAny<AlbumsDomain>())).Returns(responseService);


            var result = controller.Update(request);

        }

        [Fact]
        public void Remove_success()
        {
            Setup();

            AlbumsDomain responseService = new AlbumsDomain
            {
                Artist = "artist",
                Id = 1,
                Label = "label",
                Name = "name",
                Stock = 1
            };

            AlbumRemoveRequest request = new AlbumRemoveRequest
            {
                Id = 1
            };

            albumAppServiceMock.Setup(p => p.Remove(It.IsAny<AlbumsDomain>())).Returns(responseService);


            var result = controller.Remove(request);

        }
    }
}
