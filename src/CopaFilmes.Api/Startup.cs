using CopaFilmes.Api.Dados;
using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace CopaFilmes.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<IRepositorioDeFilmes, RepositorioDeFilmes>(client =>
            {
                client.BaseAddress = new Uri(Configuration["ApiCopaFilmes"]);
            });

            services.AddScoped<IGerenciadorDePartidas, GerenciadorDePartidas>();
            services.AddScoped<IGerenciadorDeCampeonato, GerenciadorDeCampeonato>();

            services.AddControllers();
        }

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
                endpoints.MapControllers();
            });
        }
    }
}
