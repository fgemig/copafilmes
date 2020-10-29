using CopaFilmes.Api.Controllers;
using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Models;
using CopaFilmes.Testes.Integracao.Mocks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CopaFilmes.Testes.Integracao
{
    public class PartidasControllerDisputarCampeonato
    {
        private Mock<IRepositorioDeFilmes> _repositorioDeFilmesMock;
        private Mock<IGerenciadorDePartidas> _gerenciadorDePartidasMock;
        private Mock<IGerenciadorDeCampeonato> _gerenciadorDeCampeonatoMock;
        private Mock<ILogger<PartidasController>> _loggerMock;

        public PartidasControllerDisputarCampeonato()
        {
            _repositorioDeFilmesMock = new Mock<IRepositorioDeFilmes>();
            _gerenciadorDePartidasMock = new Mock<IGerenciadorDePartidas>();
            _gerenciadorDeCampeonatoMock = new Mock<IGerenciadorDeCampeonato>();
            _loggerMock = new Mock<ILogger<PartidasController>>();
        }

        private PartidasController CriarController()
        {          
            var controller = new PartidasController(
                _repositorioDeFilmesMock.Object,
                _gerenciadorDePartidasMock.Object,
                _gerenciadorDeCampeonatoMock.Object,
                _loggerMock.Object);

            return controller;
        }

        [Fact]
        public void DeveRetornarMensagemQuandoNaoForPassadoFilmesNaRequisicao()
        {
            var controller = CriarController();

            var parametrosPost = new string[] { };

            var retorno = controller
                .DisputarCampeonato(parametrosPost)
                .GetAwaiter()
                .GetResult();

            var conteudo = retorno as BadRequestObjectResult;
            var mensagem = conteudo.Value as string;

            mensagem.Should().Be("Nenhum ID de filme foi informado");
        }     

        [Fact]
        public void DeveRetornarMensagemQuandoAQuantidadeDeFilmesForDiferenteDeOito()
        {
            var controller = CriarController();

            var parametrosPost = new string[] { "tt3606756" };

            var retorno = controller
                .DisputarCampeonato(parametrosPost)
                .GetAwaiter()
                .GetResult();

            var conteudo = retorno as BadRequestObjectResult;
            var mensagem = conteudo.Value as string;

            mensagem.Should().Be("É permitido apenas 8 filmes no campeonato");
        }

        [Fact]
        public void DeveSelecionarUmaListaDeFilmesBaseadoNosValoresEnviadosPorParametro()
        {
            var parametrosPost = new string[] { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632" };
         
            _repositorioDeFilmesMock
                .Setup(r => r.ObterFilmesPorIds(It.IsAny<string[]>()))
                .ReturnsAsync(It.IsAny<IEnumerable<Filme>>());

            var controller = CriarController();

            var retorno = controller
                .DisputarCampeonato(parametrosPost)
                .GetAwaiter()
                .GetResult();

            _repositorioDeFilmesMock.Verify(r => r.ObterFilmesPorIds(It.IsAny<string[]>()), Times.Once());
        }

        [Fact]
        public void DadoUmaListaDeFilmesDeveGerarUmaListaDePartidas()
        {
            var parametrosPost = new string[] { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632" };

            var filmes = FilmesRepositorioFake
                .ObterListaDeFilmes()
                .Where(c => parametrosPost.Contains(c.Id));

            _repositorioDeFilmesMock
                .Setup(r => r.ObterFilmesPorIds(It.IsAny<string[]>()))
                .Returns(Task.FromResult(filmes));

            var partidas = PartidasRepositorioMock.ObterPartidas(filmes);

            _gerenciadorDePartidasMock
                .Setup(r => r.DefinirPartidas(filmes))
                .Returns(partidas.AsEnumerable());

            var gerenciadorDeCampeonatoMock = new Mock<IGerenciadorDeCampeonato>();
            var loggerMock = new Mock<ILogger<PartidasController>>();

            var controller = CriarController();

            var retorno = controller
                .DisputarCampeonato(parametrosPost)
                .GetAwaiter()
                .GetResult();

            _gerenciadorDePartidasMock.Verify(r => r.DefinirPartidas(filmes), Times.Once());
        }

        [Fact]
        public void DadoUmaListaDePartidasDeveIniciarUmaDisputaNoCampeonato()
        {
            var parametrosPost = new string[] { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632" };

            var filmes = FilmesRepositorioFake
                .ObterListaDeFilmes()
                .Where(c => parametrosPost.Contains(c.Id));

            _repositorioDeFilmesMock
                .Setup(r => r.ObterFilmesPorIds(It.IsAny<string[]>()))
                .Returns(Task.FromResult(filmes));

            var partidas = PartidasRepositorioMock.ObterPartidas(filmes);

            _gerenciadorDePartidasMock
                .Setup(r => r.DefinirPartidas(filmes))
                .Returns(partidas.AsEnumerable());

            _gerenciadorDeCampeonatoMock
                .Setup(r => r.Disputar(partidas))
                .Returns(new ResultadoCampeonato(It.IsAny<Filme>(), It.IsAny<Filme>()));

            var controller = CriarController();

            var retorno = controller
                .DisputarCampeonato(parametrosPost)
                .GetAwaiter()
                .GetResult();

            _gerenciadorDeCampeonatoMock.Verify(r => r.Disputar(partidas), Times.Once());
        }
    }
}
