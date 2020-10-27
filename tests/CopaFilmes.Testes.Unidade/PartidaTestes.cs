using CopaFilmes.Api.Models;
using System;
using Xunit;

namespace CopaFilmes.Testes.Unidade
{
    public class PartidaTestes
    {
        [Fact]
        public void IniciadoUmaPartidaDeveObterOFilmeVencedor()
        {
            var filmeA = new Filme("tt5463162", "Deadpool 2", 2018, 8.1m);
            var filmeB = new Filme("tt1825683", "Pantera Negra", 2018, 7.5m);

            var partida = new Partida(filmeA, filmeB);

            var filmeVencedor = partida.FilmeVencedor();

            Assert.Equal(filmeA.Titulo, filmeVencedor.Titulo);
        }

        [Fact]
        public void IniciadoUmaPartidaComFilmesDeMesmaNotaDeveObterVencedorPorCriterioDeDesempate()
        {
            var filmeA = new Filme("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3m);
            var filmeB = new Filme("tt5834262", "Hotel Artemis", 2018, 6.3m);

            var partida = new Partida(filmeA, filmeB);

            var filmeVencedor = partida.FilmeVencedor();

            Assert.Equal(filmeB.Titulo, filmeVencedor.Titulo);
        }

        [Fact]
        public void IniciadoUmaPartidaDeveLancarUmaExcecaoCasoAlgumDosFilmesSejaNulo()
        {
            var filmeA = new Filme("tt2854926", "Te Peguei!", 2018, 7.1m);

            Assert.Throws<ArgumentNullException>(() => new Partida(filmeA, null));
        }
    }
}
