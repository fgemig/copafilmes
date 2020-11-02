using CopaFilmes.Api.Repositorios;
using CopaFilmes.Api.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using CopaFilmes.Api.Models;

namespace CopaFilmes.Api.Extensoes
{
    public static class ConfiguracoesDI
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IRepositorioDeFilmes, RepositorioDeFilmes>(client =>
            {
                client.BaseAddress = new Uri(configuration["ParametrosApi:UrlApiCopaFilmes"]);
            });

            services.AddScoped<IGerenciadorDePartidas, GerenciadorDePartidas>();
            services.AddScoped<IGerenciadorDeCampeonato, GerenciadorDeCampeonato>();
        }
    }
}
