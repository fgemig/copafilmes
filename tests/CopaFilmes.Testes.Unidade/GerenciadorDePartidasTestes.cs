using System;
using System.Linq;
using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Services;
using CopaFilmes.Testes.Unidade.Mocks;
using FluentAssertions;
using Xunit;

namespace CopaFilmes.Testes.Unidade
{
    public class GerenciadorDePartidasTestes
    {
        [Fact]
        public void DeveRetornarUmaExcecaoQuandoForPassadoUmaListaDeFilmesEmFormatoIncorreto()
        {
            var listaDeFilmes = FilmesRepositorioFake
                .ObterListaDeFilmes()
                .Take(13)
                .ToList();

            IGerenciadorDePartidas gerenciadorDePartidas = new GerenciadorDePartidas();
         
            Action act = () => gerenciadorDePartidas.DefinirPartidas(listaDeFilmes);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void DadoUmaListaDeFilmesDeveRetornarUmaListaDePartidas()
        {
            var listaDeFilmes = FilmesRepositorioFake
                .ObterListaDeFilmes()
                .Take(8)
                .ToList();

            IGerenciadorDePartidas gerenciadorDePartidas = new GerenciadorDePartidas();
            var partidas = gerenciadorDePartidas.DefinirPartidas(listaDeFilmes);

            partidas.Should().HaveCount(4);
        }
    }
}
