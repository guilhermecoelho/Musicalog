using AutoMapper;
using Microsoft.Extensions.Configuration;
using Moq;
using Musicalog.Applications.Implementations;
using Musicalog.Applications.Requests;
using Musicalog_Domain.Entities;
using Musicalog_Domain.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace Musicalog.Test
{
    public class ServiceTests : TestsHelper
    {

        private AlbumsAppService controller;
        private IConfiguration _configuration;

        private IMapper _mapper;

        private Mock<IAlbumsService> albumsServiceMock;

        private List<AlbumsDomain> listAlbumDomains = new List<AlbumsDomain>();


        [SetUp]
        internal void Setup()
        {

            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();

            _mapper = MapperConfiguration();

            albumsServiceMock = new Mock<IAlbumsService>();

            controller = new AlbumsAppService(albumsServiceMock.Object, _mapper, _configuration);


            listAlbumDomains.Add(
                  new AlbumsDomain
                  {
                      Artist = "iron maiden",
                      Id = 1,
                      Label = "emi",
                      Name = "powerslave",
                      Stock = 1
                  }
            );
            listAlbumDomains.Add(
                new AlbumsDomain
                {
                    Artist = "ac/dc",
                    Id = 2,
                    Label = "atlantic records",
                    Name = "back in black",
                    Stock = 1
                }
            );
            listAlbumDomains.Add(
               new AlbumsDomain
               {
                   Artist = "pennywise",
                   Id = 3,
                   Label = "fat records",
                   Name = "pennywise",
                   Stock = 3
               }
           );

        }


        [Fact]
        public void GetAll_Success()
        {
            Setup();

            albumsServiceMock.Setup(p => p.GetAll()).Returns(listAlbumDomains);

            GetAllAlbumsByFilterRequest request = new GetAllAlbumsByFilterRequest();

            var result = controller.GetAllAlbumsByFilter(request);

            Assert.AreEqual(result.ListAlbums.Count, 2);

        }

        [Fact]
        public void GetAll_moreThenPageSize()
        {
            Setup();

            AlbumsDomain albumExtra = new AlbumsDomain
            {
                Artist = "green day",
                Id = 4,
                Label = "warner",
                Name = "dookie",
                Stock = 4
            };

            listAlbumDomains.Add(
                 albumExtra
            );

            albumsServiceMock.Setup(p => p.GetAll()).Returns(listAlbumDomains);

            GetAllAlbumsByFilterRequest request = new GetAllAlbumsByFilterRequest();

            var result = controller.GetAllAlbumsByFilter(request);

            Assert.AreEqual(result.ListAlbums.Count, 2);

            listAlbumDomains.Remove(albumExtra);

        }

        [Fact]
        public void GetAll_Success_orderByName()
        {
            Setup();

            albumsServiceMock.Setup(p => p.GetAll()).Returns(listAlbumDomains);

            GetAllAlbumsByFilterRequest request = new GetAllAlbumsByFilterRequest();

            request.SortBy = "name";

            var result = controller.GetAllAlbumsByFilter(request);

            Assert.AreEqual(result.ListAlbums.Count, 2);
            Assert.AreEqual(result.ListAlbums[0].Name, "back in black");

        }
        [Fact]
        public void GetAll_Success_orderByNameDesc()
        {
            Setup();

            albumsServiceMock.Setup(p => p.GetAll()).Returns(listAlbumDomains);

            GetAllAlbumsByFilterRequest request = new GetAllAlbumsByFilterRequest();

            request.SortBy = "name";
            request.IsAsc = false;

            var result = controller.GetAllAlbumsByFilter(request);

            Assert.AreEqual(result.ListAlbums.Count, 2);
            Assert.AreEqual(result.ListAlbums[0].Name, "powerslave");

        }

        [Fact]
        public void GetAll_Success_orderByArtist()
        {
            Setup();

            albumsServiceMock.Setup(p => p.GetAll()).Returns(listAlbumDomains);

            GetAllAlbumsByFilterRequest request = new GetAllAlbumsByFilterRequest();

            request.SortBy = "artist";

            var result = controller.GetAllAlbumsByFilter(request);

            Assert.AreEqual(result.ListAlbums.Count, 2);
            Assert.AreEqual(result.ListAlbums[0].Artist, "ac/dc");

        }
        [Fact]
        public void GetAll_Success_orderByArtistDesc()
        {
            Setup();

            albumsServiceMock.Setup(p => p.GetAll()).Returns(listAlbumDomains);

            GetAllAlbumsByFilterRequest request = new GetAllAlbumsByFilterRequest();

            request.SortBy = "artist";
            request.IsAsc = false;

            var result = controller.GetAllAlbumsByFilter(request);

            Assert.AreEqual(result.ListAlbums.Count, 2);
            Assert.AreEqual(result.ListAlbums[0].Artist, "pennywise");
        }

        [Fact]
        public void GetAll_Success_orderBylabel()
        {
            Setup();

            albumsServiceMock.Setup(p => p.GetAll()).Returns(listAlbumDomains);

            GetAllAlbumsByFilterRequest request = new GetAllAlbumsByFilterRequest();

            request.SortBy = "label";

            var result = controller.GetAllAlbumsByFilter(request);

            Assert.AreEqual(result.ListAlbums.Count, 2);
            Assert.AreEqual(result.ListAlbums[0].Label, "atlantic records");

        }
        [Fact]
        public void GetAll_Success_orderByLabelDesc()
        {
            Setup();

            albumsServiceMock.Setup(p => p.GetAll()).Returns(listAlbumDomains);

            GetAllAlbumsByFilterRequest request = new GetAllAlbumsByFilterRequest();

            request.SortBy = "label";
            request.IsAsc = false;

            var result = controller.GetAllAlbumsByFilter(request);

            Assert.AreEqual(result.ListAlbums.Count, 2);
            Assert.AreEqual(result.ListAlbums[0].Label, "fat records");
        }

        [Fact]
        public void GetAllSuccess_pageNumber_first()
        {
            Setup();

            albumsServiceMock.Setup(p => p.GetAll()).Returns(listAlbumDomains);

            GetAllAlbumsByFilterRequest request = new GetAllAlbumsByFilterRequest();

            request.PageNumber = 1;

            var result = controller.GetAllAlbumsByFilter(request);

            Assert.AreEqual(result.ListAlbums.Count, 2);
            Assert.AreEqual(result.ListAlbums[0].Id, 1);

        }

        [Fact]
        public void GetAllSuccess_pageNumber_second()
        {
            Setup();

            albumsServiceMock.Setup(p => p.GetAll()).Returns(listAlbumDomains);

            GetAllAlbumsByFilterRequest request = new GetAllAlbumsByFilterRequest();

            request.PageNumber = 2;

            var result = controller.GetAllAlbumsByFilter(request);

            Assert.AreEqual(result.ListAlbums.Count, 1);
            Assert.AreEqual(result.ListAlbums[0].Id, 3);
        }
    }
}

