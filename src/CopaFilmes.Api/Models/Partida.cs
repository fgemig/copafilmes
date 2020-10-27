using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Api.Models
{
    /// <summary>
    /// Cria a instância de uma partida e obtém o filme vencedor
    /// </summary>
    public class Partida
    {
        public Partida(Filme filmeA, Filme filmeB)
        {
            FilmeA = filmeA ?? throw new ArgumentNullException(nameof(filmeA));
            FilmeB = filmeB ?? throw new ArgumentNullException(nameof(filmeB));
        }

        public Filme FilmeA { get; }

        public Filme FilmeB { get; }

        /// <summary>
        /// Obtém o filme vencedor por critério de nota. Caso as notas sejam iguais, o vencedor será definido por ordem alfabética.
        /// </summary>
        /// <returns></returns>
        public Filme FilmeVencedor()
        {
            if (FilmeA.Nota > FilmeB.Nota)
                return FilmeA;

            if (FilmeB.Nota > FilmeA.Nota)
                return FilmeB;

            return VencedorPorCriterioDeDesempate();
        }

        private Filme VencedorPorCriterioDeDesempate()
        {
            var lista = new List<Filme>() { FilmeA, FilmeB };

            return lista.OrderBy(c => c.Titulo).First();
        }
    }
}
