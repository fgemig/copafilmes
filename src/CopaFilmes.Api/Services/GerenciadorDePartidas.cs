using CopaFilmes.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Api.Services
{
    public class GerenciadorDePartidas
    {
        private readonly List<Filme> _filmes;

        public GerenciadorDePartidas(List<Filme> filmes)
        {
            if (filmes.Count() != 8)
                throw new ArgumentOutOfRangeException(nameof(filmes));

            _filmes = filmes;
        }

        public List<Partida> DefinirPartidas()
        {
            var partidas = new List<Partida>();

            int totalFilmes = _filmes.Count();

            for (int i = 1; i <= _filmes.Count() / 2; i++)
            {
                for (int j = totalFilmes; j >= totalFilmes; j--)
                {
                    partidas.Add(new Partida(_filmes[i - 1], _filmes[j - 1]));
                }

                totalFilmes--;
            }

            return partidas;
        }
    }
}
