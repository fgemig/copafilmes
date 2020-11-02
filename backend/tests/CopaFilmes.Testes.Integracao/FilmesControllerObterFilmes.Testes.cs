using CopaFilmes.Api.Controllers;
using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Models;
using CopaFilmes.Testes.Integracao.Helpers;
using CopaFilmes.Testes.Integracao.Mocks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xunit;

namespace CopaFilmes.Testes.Integracao
{
    public class FilmesControllerObterFilmes
    {
        [Fact]
        public void DeveRetornarUmaListaDeFilmesDisponiveis()
        {
            var repositorioDeFilmesMock = new Mock<IRepositorioDeFilmes>();

            repositorioDeFilmesMock
                .Setup(r => r.ObterFilmes())
                .ReturnsAsync(FilmesRepositorioFake.ObterListaDeFilmes());

            var loggerMock = new Mock<ILogger<FilmesController>>();

            var optionsMock = new Mock<IOptions<ParametrosApi>>();
            optionsMock.Setup(o => o.Value).Returns(new ParametrosApi
            {
                UrlApiCopaFilmes = "",
                CacheExpiracaoEmMinutos = 30
            });

            var memoryCacheMock = MockMemoryCache.GetMemoryCache(null);

            var controller = new FilmesController(repositorioDeFilmesMock.Object, memoryCacheMock, loggerMock.Object, optionsMock.Object);

            var retorno = controller.ObterFilmes().GetAwaiter().GetResult();

            var conteudo = retorno as OkObjectResult;
            var filmes = conteudo.Value as IEnumerable<Filme>;

            filmes.Should().HaveCount(16);
        }

        [Fact]
        public void QuandoExceptionForLancadaDeveLogarAMensagemDaExcecao()
        {
            var repositorioDeFilmesMock = new Mock<IRepositorioDeFilmes>();

            repositorioDeFilmesMock
                .Setup(r => r.ObterFilmes())
                .ReturnsAsync(FilmesRepositorioFake.ObterListaDeFilmes());

            var exception = new HttpRequestException("Houve um erro");

            repositorioDeFilmesMock
                .Setup(t => t.ObterFilmes())
                .Throws(exception);

            var loggerMock = new Mock<ILogger<FilmesController>>();

            var optionsMock = new Mock<IOptions<ParametrosApi>>();
            optionsMock.Setup(o => o.Value).Returns(new ParametrosApi
            {
                UrlApiCopaFilmes = "",
                CacheExpiracaoEmMinutos = 30
            });

            var memoryCacheMock = MockMemoryCache.GetMemoryCache(null);

            var controller = new FilmesController(repositorioDeFilmesMock.Object, memoryCacheMock, loggerMock.Object, optionsMock.Object);

            var retorno = controller.ObterFilmes().GetAwaiter().GetResult();

            loggerMock.Verify(l =>
               l.Log(
                   LogLevel.Error,
                   It.IsAny<EventId>(),
                   It.Is<object>((v, t) => true),
                   exception,
                   It.Is<Func<object, Exception, string>>((v, t) => true)),
                   Times.Once());
        }
    }
}
