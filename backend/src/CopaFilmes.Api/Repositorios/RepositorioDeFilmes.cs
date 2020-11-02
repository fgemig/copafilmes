using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Repositorios
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

            response.EnsureSuccessStatusCode();

            string conteudo = await response.Content.ReadAsStringAsync();

            var filmes = JsonConvert.DeserializeObject<IEnumerable<Filme>>(conteudo);

            return filmes;
        }

        public async Task<IEnumerable<Filme>> ObterFilmesPorIds(string[] ids)
        {
            var filmes = await ObterFilmes();

            var filmesSelecionados = filmes.Where(c => ids.Contains(c.Id));

            return filmesSelecionados;
        }
    }
}
