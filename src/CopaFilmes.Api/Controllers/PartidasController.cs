﻿using System;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CopaFilmes.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class PartidasController : ControllerBase
    {
        private readonly IRepositorioDeFilmes _repositorioDeFilmes;
        private readonly IGerenciadorDePartidas _gerenciadorDePartidas;
        private readonly IGerenciadorDeCampeonato _gerenciadorDeCampeonato;
        private readonly ILogger<FilmesController> _logger;

        public PartidasController(
            IRepositorioDeFilmes repositorioDeFilmes,
            IGerenciadorDePartidas gerenciadorDePartidas,
            IGerenciadorDeCampeonato gerenciadorDeCampeonato,
            ILogger<FilmesController> logger)
        {
            _repositorioDeFilmes = repositorioDeFilmes;
            _gerenciadorDePartidas = gerenciadorDePartidas;
            _gerenciadorDeCampeonato = gerenciadorDeCampeonato;
            _logger = logger;
        }

        /// <summary>
        /// Cria um campeonato e retorna os filmes vencedores
        /// </summary>
        /// <param name="idsSelecionados">Ids dos filmes selecionados para competir</param>
        /// <response code="200">Veículo cadastrado</response>
        /// <response code="400">Requisição mal formatada</response>
        /// <response code="500">Erro interno no servidor</response>
        [HttpPost]
        [ProducesResponseType(typeof(ResultadoCampeonato), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] string[] idsSelecionados)
        {
            try
            {
                if (idsSelecionados.Length == 0)
                    return BadRequest("Nenhum ID foi informado");

                if (idsSelecionados.Length != 8)
                    return BadRequest("É permitido apenas 8 filmes por campeonato");

                var filmes = await _repositorioDeFilmes
                    .ObterFilmes();

                var filmesSelecionados = filmes.Where(c => idsSelecionados.Contains(c.Id));

                var partidas = _gerenciadorDePartidas.DefinirPartidas(filmesSelecionados);
                var resultado = _gerenciadorDeCampeonato.Disputar(partidas);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falha ao iniciar a partida");

                return StatusCode(500);
            }
        }
    }
}
