using CopaFilmes.Api.Repositorios;
using CopaFilmes.Api.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using CopaFilmes.Api.Models;
using System.Net.Http;
using Polly;

namespace CopaFilmes.Api.Extensoes
{
    public static class ConfiguracoesDI
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var politicaDeRetentativas = Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .RetryAsync(2, onRetry: (message, tentativa) =>
                {
                    Console.Out.WriteLineAsync($"Retentativa: {tentativa}");
                });

            services.AddHttpClient<IRepositorioDeFilmes, RepositorioDeFilmes>(client =>
            {
                client.BaseAddress = new Uri(configuration["ParametrosApi:UrlApiCopaFilmes"]);
            }).AddPolicyHandler(politicaDeRetentativas);

            services.AddScoped<IGerenciadorDePartidas, GerenciadorDePartidas>();
            services.AddScoped<IGerenciadorDeCampeonato, GerenciadorDeCampeonato>();
        }
    }
}
