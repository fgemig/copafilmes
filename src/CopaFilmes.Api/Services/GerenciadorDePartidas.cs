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
            if (filmes.Count() % 2 != 0)
                throw new ArgumentException("É permitido apenas grupos de filmes pares");

            var partidas = new List<Partida>();

            int totalFilmes = filmes.Count();

            for (int i = 1; i <= filmes.Count() / 2; i++)
            {
                for (int j = totalFilmes; j >= totalFilmes; j--)
                {
                    var novaPartida = new Partida(
                        filmeA: filmes.ElementAt(i - 1),
                        filmeB: filmes.ElementAt(j - 1)
                    );

                    partidas.Add(novaPartida);
                }

                totalFilmes--;
            }

            return partidas;
        }
    }
}
