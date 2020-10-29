using CopaFilmes.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Testes.Integracao.Mocks
{
    public class PartidasRepositorioMock
    {
        public static IEnumerable<Partida> ObterPartidas(IEnumerable<Filme> filmes)
        {
            var partidas = new List<Partida>()
            {
                new Partida(filmes.ElementAt(0), filmes.ElementAt(1)),
                new Partida(filmes.ElementAt(2), filmes.ElementAt(3)),
                new Partida(filmes.ElementAt(4), filmes.ElementAt(5)),
                new Partida(filmes.ElementAt(6), filmes.ElementAt(7))
            };

            return partidas;
        }
    }
}
