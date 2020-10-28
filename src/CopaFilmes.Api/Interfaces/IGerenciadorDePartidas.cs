using CopaFilmes.Api.Models;
using System.Collections.Generic;

namespace CopaFilmes.Api.Interfaces
{
    public interface IGerenciadorDePartidas
    {
        IEnumerable<Partida> DefinirPartidas(IEnumerable<Filme> filmes);
    }
}
