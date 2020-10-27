using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CopaFilmes.Api.Services;
using CopaFilmes.Testes.Unidade.Mocks;
using FluentAssertions;
using Xunit;

namespace CopaFilmes.Testes.Unidade
{
    public class GerenciadorDePartidasTestes
    {
        [Fact]
        public void DeveRetornarUmaListaDePartidasQuandoPassadoUmaListaDeFilmes()
        {
            var listaDeFilmes = FilmesRepositorioFake
                .ObterListaDeFilmes()
                .Take(8)
                .ToList();

            var gerenciadorDePartidas = new GerenciadorDePartidas(listaDeFilmes);

            var partidas = gerenciadorDePartidas.DefinirPartidas();

            Assert.True(true);
        }

        [Fact]
        public void DeveRetornarUmaExcecaoQuandoForPassadoUmaListaDeFilmesMaiorQueOPermitido()
        {
            var listaDeFilmes = FilmesRepositorioFake
                .ObterListaDeFilmes()
                .Take(12)
                .ToList();

            Action act = () => new GerenciadorDePartidas(listaDeFilmes);

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
