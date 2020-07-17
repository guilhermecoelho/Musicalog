using Microsoft.Extensions.Configuration;
using Musicalog.api.Requests;
using Musicalog.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace Musicalog.MVC.Helpers
{
    public class BaseConnections : IBaseConnections
    {

        private readonly IConfiguration _configuration;
        private readonly string API_ADDRESS;

        public BaseConnections(IConfiguration configuration)
        {
            _configuration = configuration;

            API_ADDRESS = _configuration.GetSection("GeneralSettings").GetSection("ApiAddress").Value;
        }

        public AlbumsGetResponse GetAlbums(int pageNumber, string sortBy, bool isAsc = true)
        {
            AlbumsGetResponse response = new AlbumsGetResponse();

            string parameters = "?pageNumber=" + pageNumber + "&SortBy=" + sortBy + "&IsAsc=" + isAsc;

            using (var client = new HttpClient())
            {
                var result = getResult("Get" + parameters);

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    response = JsonConvert.DeserializeObject<AlbumsGetResponse>(readTask.Result);
                }
            }
            return response;
        }

        public AlbumsModel GetAlbumById(int id)
        {
            AlbumsModel response = new AlbumsModel();

            string parameters = "?id=" + id;

            using (var client = new HttpClient())
            {
                var result = getResult("GetById" + parameters);

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    response = JsonConvert.DeserializeObject<AlbumsModel>(readTask.Result);
                }
            }
            return response;
        }

        public AlbumsModel Save(AlbumsModel albumsModel)
        {
            AlbumsModel response = new AlbumsModel();
            string method;
            string jsonString;

            if (albumsModel.Id == 0)
            {
                method = "save";
                AlbumSaveRequest request = new AlbumSaveRequest
                {
                    AlbumTypeId = albumsModel.AlbumTypeId,
                    Artist = albumsModel.Artist,
                    Label = albumsModel.Label,
                    Name = albumsModel.Name,
                    Stock = albumsModel.Stock
                };

                jsonString = JsonConvert.SerializeObject(request);
            }
            else
            {
                method = "update";

                AlbumUpdateRequest request = new AlbumUpdateRequest
                {
                    Id = albumsModel.Id,
                    AlbumTypeId = albumsModel.AlbumTypeId,
                    Artist = albumsModel.Artist,
                    Label = albumsModel.Label,
                    Name = albumsModel.Name,
                    Stock = albumsModel.Stock
                };

                jsonString = JsonConvert.SerializeObject(request);
            }

            using (var client = new HttpClient())
            {
                var result = postResult(method, jsonString);

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    response = JsonConvert.DeserializeObject<AlbumsModel>(readTask.Result);
                }
            }
            return response;
        }

        public AlbumsModel Remove(int Id)
        {
            AlbumsModel response = new AlbumsModel();

            AlbumRemoveRequest request = new AlbumRemoveRequest
            {
                Id = Id
            };

            string jsonString = JsonConvert.SerializeObject(request);

            using (var client = new HttpClient())
            {
                var result = postResult("remove", jsonString);

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    response = JsonConvert.DeserializeObject<AlbumsModel>(readTask.Result);
                }
            }
            return response;
        }

        private HttpResponseMessage postResult(string methodName, string obj)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(API_ADDRESS);
                    var responseTask = client.PostAsync(methodName, new StringContent(obj, Encoding.UTF8, "application/json"));
                    responseTask.Wait();

                    response = responseTask.Result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            return response;
        }

        private HttpResponseMessage getResult(string methodName)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(API_ADDRESS);
                var responseTask = client.GetAsync(methodName);
                responseTask.Wait();

                response = responseTask.Result;
            }

            return response;
        }
    }
}
