using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Api.Services
{
    public class GerenciadorDeCampeonato : IGerenciadorDeCampeonato
    {
        private readonly IGerenciadorDePartidas _gerenciadorDePartidas;

        public GerenciadorDeCampeonato(IGerenciadorDePartidas gerenciadorDePartidas)
        {
            _gerenciadorDePartidas = gerenciadorDePartidas;
        }

        public Filme Campeao { get; set; }

        public Filme ViceCampecao { get; set; }

        public IEnumerable<Filme> Disputar(IEnumerable<Partida> partidas)
        {
            var filmesVencedores = new List<Filme>();

            foreach (var partida in partidas)
                filmesVencedores.Add(partida.FilmeVencedor());

            var proximasPartidas = _gerenciadorDePartidas.DefinirPartidas(filmesVencedores);

            if (filmesVencedores.Count == 2)
            {
                Campeao = filmesVencedores.First();
                return filmesVencedores;
            }
            else
            {
                ViceCampecao = filmesVencedores.First();
            }
                
            return Disputar(proximasPartidas);
        }
    }
}
