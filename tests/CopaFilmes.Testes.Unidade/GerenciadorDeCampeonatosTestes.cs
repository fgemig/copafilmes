using System.Linq;
using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Services;
using CopaFilmes.Testes.Unidade.Mocks;
using FluentAssertions;
using Xunit;

namespace CopaFilmes.Testes.Unidade
{
    public class GerenciadorDeCampeonatosTestes
    {        
        [Fact]
        public void AoIniciarUmCampeonatoDeveDecidirUmCampeao()
        {
            var listaDeFilmes = FilmesRepositorioFake
                .ObterListaDeFilmes()
                .Take(8)
                .ToList();

            IGerenciadorDePartidas gerenciadorDePartidas = new GerenciadorDePartidas();
            var partidas = gerenciadorDePartidas.DefinirPartidas(listaDeFilmes);

            IGerenciadorDeCampeonato gerenciadorDeCampeonatos = new GerenciadorDeCampeonato(gerenciadorDePartidas);
            gerenciadorDeCampeonatos.Disputar(partidas);

            gerenciadorDeCampeonatos.Campeao.Titulo.Should().Be("Vingadores: Guerra Infinita");
        }

        [Fact]
        public void AoIniciarUmCampeonatoDeveDecidirUmViceCampeao()
        {
            var listaDeFilmes = FilmesRepositorioFake
                .ObterListaDeFilmes()
                .Take(8)
                .ToList();

            IGerenciadorDePartidas gerenciadorDePartidas = new GerenciadorDePartidas();
            var partidas = gerenciadorDePartidas.DefinirPartidas(listaDeFilmes);

            IGerenciadorDeCampeonato gerenciadorDeCampeonatos = new GerenciadorDeCampeonato(gerenciadorDePartidas);
            gerenciadorDeCampeonatos.Disputar(partidas);

            gerenciadorDeCampeonatos.ViceCampecao.Titulo.Should().Be("Os Incríveis 2");
        }
    }
}
