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

            filmes = filmes.OrderBy(c => c.Titulo);

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

        public IEnumerable<Partida> DefinirProximasPartidas(IEnumerable<Filme> filmesVencedores)
        {                      
            var partidas = new List<Partida>();
            
            for (int i = 0; i < filmesVencedores.Count(); i += 2)
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
