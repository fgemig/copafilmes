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

        [Fact]
        public void AoGerarAsPartidasComUmaListaDeOitoFilmesOPrimeiroDeveDisputarComOUltimo()
        {
            var listaDeFilmes = FilmesRepositorioFake
                .ObterListaDeFilmes()
                .Take(8)
                .ToList();

            IGerenciadorDePartidas gerenciadorDePartidas = new GerenciadorDePartidas();
            var partidas = gerenciadorDePartidas.DefinirPartidas(listaDeFilmes).ToList();

            var partida = partidas[0];

            partida.FilmeA.Titulo.Should().Be("Deadpool 2");
            partida.FilmeB.Titulo.Should().Be("Vingadores: Guerra Infinita");
        }

        [Fact]
        public void AoGerarAsPartidasComUmaListaDeOitoFilmesOSegundoDeveDisputarComOSetimo()
        {
            var listaDeFilmes = FilmesRepositorioFake
                .ObterListaDeFilmes()
                .Take(8)
                .ToList();

            IGerenciadorDePartidas gerenciadorDePartidas = new GerenciadorDePartidas();
            var partidas = gerenciadorDePartidas.DefinirPartidas(listaDeFilmes).ToList();

            var partida = partidas[1];

            partida.FilmeA.Titulo.Should().Be("Han Solo: Uma História Star Wars");
            partida.FilmeB.Titulo.Should().Be("Thor: Ragnarok");
        }

        [Fact]
        public void AoGerarAsPartidasComUmaListaDeOitoFilmesOTerceiroDeveDisputarComOSexto()
        {
            var listaDeFilmes = FilmesRepositorioFake
                .ObterListaDeFilmes()
                .Take(8)
                .ToList();

            IGerenciadorDePartidas gerenciadorDePartidas = new GerenciadorDePartidas();
            var partidas = gerenciadorDePartidas.DefinirPartidas(listaDeFilmes).ToList();

            var partida = partidas[2];

            partida.FilmeA.Titulo.Should().Be("Hereditário");
            partida.FilmeB.Titulo.Should().Be("Os Incríveis 2");
        }

        [Fact]
        public void AoGerarAsPartidasComUmaListaDeOitoFilmesOQuartoDeveDisputarComOQuinto()
        {
            var listaDeFilmes = FilmesRepositorioFake
                .ObterListaDeFilmes()
                .Take(8)
                .ToList();

            IGerenciadorDePartidas gerenciadorDePartidas = new GerenciadorDePartidas();
            var partidas = gerenciadorDePartidas.DefinirPartidas(listaDeFilmes).ToList();

            var partida = partidas[3];

            partida.FilmeA.Titulo.Should().Be("Jurassic World: Reino Ameaçado");
            partida.FilmeB.Titulo.Should().Be("Oito Mulheres e um Segredo");
        }
    }
}
