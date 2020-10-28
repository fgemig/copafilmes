using CopaFilmes.Api.Models;
using System.Collections.Generic;

namespace CopaFilmes.Api.Interfaces
{
    public interface IGerenciadorDeCampeonato
    {
        public Filme Campeao { get; }
        public Filme ViceCampecao { get;  }
        public IEnumerable<Filme> Disputar(IEnumerable<Partida> partidas);
    }
}
