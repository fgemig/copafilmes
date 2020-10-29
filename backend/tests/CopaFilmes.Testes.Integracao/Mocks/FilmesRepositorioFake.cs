using CopaFilmes.Api.Models;
using System.Collections.Generic;

namespace CopaFilmes.Testes.Integracao.Mocks
{
    public class FilmesRepositorioFake
    {
        public static List<Filme> ObterListaDeFilmes()
        {
            var filmes = new List<Filme>()
            {
                new Filme("tt3606756", "Os Incríveis 2", 2018, 8.5m),
                new Filme("tt4881806", "Jurassic World: Reino Ameaçado",  2018, 6.7m),
                new Filme("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3m),
                new Filme("tt7784604", "Hereditário", 2018, 7.8m),
                new Filme("tt4154756", "Vingadores: Guerra Infinita", 2018, 8.8m),
                new Filme("tt5463162", "Deadpool 2", 2018, 8.1m),
                new Filme("tt3778644", "Han Solo: Uma História Star Wars", 2018, 7.2m),
                new Filme("tt3501632", "Thor: Ragnarok",  2017, 7.9m),
                new Filme("tt2854926", "Te Peguei!",  2018, 7.1m),
                new Filme("tt0317705", "Os Incríveis", 2004, 8),
                new Filme("tt3799232", "A Barraca do Beijo", 2018, 6.4m),
                new Filme("tt1365519", "Tomb Raider: A Origem", 2018, 6.5m),
                new Filme("tt1825683", "Pantera Negra", 2018, 7.5m),
                new Filme("tt5834262", "Hotel Artemis", 2018, 6.3m),
                new Filme("tt7690670", "Superfly", 2018, 5.1m),
                new Filme("tt6499752", "Upgrade", 2018, 7.8m),
            };

            return filmes;
        }
    }
}
