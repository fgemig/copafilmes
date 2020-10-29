using CopaFilmes.Api.Dados;
using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CopaFilmes.Api.Configs
{
    public static class DependenciasConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IRepositorioDeFilmes, RepositorioDeFilmes>(client =>
            {
                client.BaseAddress = new Uri(configuration["ParametrosApi:ApiCopaFilmes"]);
            });

            services.AddScoped<IGerenciadorDePartidas, GerenciadorDePartidas>();
            services.AddScoped<IGerenciadorDeCampeonato, GerenciadorDeCampeonato>();
        }
    }
}
