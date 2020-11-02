using System.Collections.Generic;
using System.Linq;
using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Models;
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

            ResultadoCampeonato resultado = ObterResultados(listaDeFilmes);

            var campeao = resultado.Campeao.Titulo;

            campeao.Should().Be("Vingadores: Guerra Infinita");
        }        

        [Fact]
        public void AoIniciarUmCampeonatoDeveDecidirUmViceCampeao()
        {
            var listaDeFilmes = FilmesRepositorioFake
                .ObterListaDeFilmes()
                .Take(8)
                .ToList();

            ResultadoCampeonato resultado = ObterResultados(listaDeFilmes);

            var viceCampeao = resultado.ViceCampeao.Titulo;

            viceCampeao.Should().Be("Os Incríveis 2");
        }

        [Fact]
        public void AoIniciarUmCampeonatoDeveDecidirUmCampeaoPorCriterioDeDesempate()
        {
            var listaDeFilmes = new List<Filme>()
            {
                new Filme("tt3606756", "Os Incríveis 2", 2018, 9),
                new Filme("tt4154756", "Vingadores: Guerra Infinita", 2018, 9),
                new Filme("tt4881806", "Jurassic World: Reino Ameaçado",  2018, 6.7m),
                new Filme("tt5164214", "Oito Mulheres e um Segredo", 2018, 6.3m),
                new Filme("tt7784604", "Hereditário", 2018, 7.8m),                
                new Filme("tt5463162", "Deadpool 2", 2018, 8.1m),
                new Filme("tt3778644", "Han Solo: Uma História Star Wars", 2018, 7.2m),
                new Filme("tt3501632", "Thor: Ragnarok",  2017, 7.9m)
            };

            ResultadoCampeonato resultado = ObterResultados(listaDeFilmes);

            var viceCampeao = resultado.ViceCampeao.Titulo;

            viceCampeao.Should().Be("Vingadores: Guerra Infinita");
        }

        private static ResultadoCampeonato ObterResultados(List<Filme> listaDeFilmes)
        {
            IGerenciadorDePartidas gerenciadorDePartidas = new GerenciadorDePartidas();
            var partidas = gerenciadorDePartidas.DefinirPartidas(listaDeFilmes);

            IGerenciadorDeCampeonato gerenciadorDeCampeonatos = new GerenciadorDeCampeonato(gerenciadorDePartidas);
            var resultado = gerenciadorDeCampeonatos.Disputar(partidas);

            return resultado;
        }
    }
}
