﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Go.Repositorio;
using Microsoft.EntityFrameworkCore;
using Go.Logica.RepoInterfaces;
using Go.Logica;

namespace Go.API
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
            services.AddDbContext<CoreContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddScoped<IPuntoRepositorio, PuntoRepositorio>();
            services.AddScoped<IPuntoLogica, PuntoLogica>();
            services.AddScoped<ITablero, Tablero>();
            services.AddScoped<ICoordenada, Coordenada>();
            services.AddScoped<IPartidaRepositorio, PartidaRepositorio>();
            services.AddScoped<IJugadorRepositorio, JugadorRepositorio>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
