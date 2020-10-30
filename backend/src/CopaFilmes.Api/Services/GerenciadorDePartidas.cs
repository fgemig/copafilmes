using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Api.Services
{
    public class GerenciadorDePartidas : IGerenciadorDePartidas
    {
        public IEnumerable<Partida> DefinirPartidas(IEnumerable<Filme> filmes)
        {
            var partidas = new List<Partida>();

            var totalDeFilmes = filmes.Count();

            if (totalDeFilmes % 2 != 0)
                throw new ArgumentException("É permitido apenas grupos de filmes pares");

            filmes = filmes.OrderBy(c => c.Titulo);
           
            var contadorReverso = totalDeFilmes - 1;

            for (int contador = 0; contador <= totalDeFilmes - 1; contador++)
            {
                if (contador < contadorReverso)
                {
                    var novaPartida = new Partida(
                        filmeA: filmes.ElementAt(contador),
                        filmeB: filmes.ElementAt(contadorReverso));

                    partidas.Add(novaPartida);
                }

                contadorReverso--;
            }

            return partidas;
        }

        public IEnumerable<Partida> DefinirProximasPartidas(IEnumerable<Filme> filmesVencedores)
        {
            var totalDeFilmesVencedores = filmesVencedores.Count();
            var partidas = new List<Partida>();
            
            for (int i = 0; i < totalDeFilmesVencedores; i += 2)
            {
                var filmes = filmesVencedores.Skip(i).Take(2);

                partidas.Add(new Partida(
                    filmeA: filmes.ElementAt(0),
                    filmeB: filmes.ElementAt(1)
                ));
            }

            return partidas;
        }
    }
}
