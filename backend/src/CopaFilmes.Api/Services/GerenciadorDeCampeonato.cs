using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Api.Services
{
    public class GerenciadorDeCampeonato : IGerenciadorDeCampeonato
    {
        private readonly IGerenciadorDePartidas _gerenciadorDePartidas;
        private readonly List<Partida> _partidasJogadas;

        public GerenciadorDeCampeonato(IGerenciadorDePartidas gerenciadorDePartidas)
        {
            _gerenciadorDePartidas = gerenciadorDePartidas;
            _partidasJogadas = new List<Partida>();
        }

        public ResultadoCampeonato Disputar(IEnumerable<Partida> partidas)
        {
            _partidasJogadas.AddRange(partidas);

            var filmesVencedores = new List<Filme>();

            foreach (var partida in partidas)
                filmesVencedores.Add(partida.FilmeVencedor());

            var proximasPartidas = _gerenciadorDePartidas.DefinirProximasPartidas(filmesVencedores);

            if (filmesVencedores.Count == 2)
            {                
                return ObterResultadoCampeonato(filmesVencedores);
            }           
                
            return Disputar(proximasPartidas);
        }

        private ResultadoCampeonato ObterResultadoCampeonato(List<Filme> filmesVencedores)
        {            
            filmesVencedores = filmesVencedores
                .OrderByDescending(c => c.Nota)
                .ToList();

            var filmeA = filmesVencedores.ElementAt(0);
            var filmeB = filmesVencedores.ElementAt(1);

            if (filmeA.Nota == filmeB.Nota)
            {
                var partidadeDeDesempate = new Partida(filmeA, filmeB);

                var filmeCampeao = partidadeDeDesempate.VencedorPorCriterioDeDesempate();

                var filmeViceCampeao = filmesVencedores.Where(c => c.Id != filmeCampeao.Id).First();

                filmeA = filmeCampeao;
                filmeB = filmeViceCampeao;

                _partidasJogadas.Add(partidadeDeDesempate);
            }

            var partidaDaFinal = new Partida(filmeA, filmeB);

            _partidasJogadas.Add(partidaDaFinal);

            var resultado = new ResultadoCampeonato(filmeA, filmeB, _partidasJogadas);

            return resultado;
        }
    }
}
