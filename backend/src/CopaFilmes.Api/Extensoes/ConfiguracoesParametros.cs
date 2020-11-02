using CopaFilmes.Api.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CopaFilmes.Api.Extensoes
{
    public static class ConfiguracoesParametros
    {
        public static void AddParametros(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.Configure<ParametrosApi>(configuration.GetSection("ParametrosApi"));
        }
    }
}
