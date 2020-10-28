using CopaFilmes.Api.Models;
using System.Collections.Generic;

namespace CopaFilmes.Api.Interfaces
{
    public interface IGerenciadorDeCampeonato
    {
        ResultadoCampeonato Disputar(IEnumerable<Partida> partidas);
    }
}
