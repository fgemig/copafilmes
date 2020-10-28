﻿using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Dados
{
    public class RepositorioDeFilmes : IRepositorioDeFilmes
    {
        private readonly HttpClient _client;

        public RepositorioDeFilmes(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<IEnumerable<Filme>> ObterFilmes()
        {
            var response = await _client.GetAsync("api/filmes");

            string conteudo = await response.Content.ReadAsStringAsync();

            var filmes = JsonConvert.DeserializeObject<IEnumerable<Filme>>(conteudo);

            return filmes;
        }
    }
}
