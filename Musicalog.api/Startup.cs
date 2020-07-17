using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Musicalog.api.Requests;
using Musicalog.api.Responses;
using Musicalog.API.Entitites;
using Musicalog.API.Responses;
using Musicalog.Applications.Entities;
using Musicalog.Applications.Implementations;
using Musicalog.Applications.Interfaces;
using Musicalog.Applications.Requests;
using Musicalog.Applications.Responses;
using Musicalog.Data;
using Musicalog.Data.Repositories;
using Musicalog_Domain.Entities;
using Musicalog_Domain.Interfaces;
using Musicalog_Domain.Services;

namespace Musicalog.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            #region DI
            //services.Add(new ServiceDescriptor(typeof(IAlbumRepository), typeof(AlbumRepository), ServiceLifetime.Transient));

            services.AddSingleton<IAlbumRepository, AlbumRepository>();
            services.AddSingleton<IAlbumsService, AlbumsService>();
            services.AddSingleton<IAlbumsAppService, AlbumsAppService>();


            #endregion

            #region automapper
            var config = new AutoMapper.MapperConfiguration(cfg =>
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

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            #endregion

            #region connection DB

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
