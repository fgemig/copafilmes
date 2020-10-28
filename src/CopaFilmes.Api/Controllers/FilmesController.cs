using System;
using System.Collections.Generic;
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
    public class FilmesController : ControllerBase
    {
        private readonly IRepositorioDeFilmes _repositorioDeFilmes;
        private readonly ILogger<FilmesController> _logger;

        public FilmesController(IRepositorioDeFilmes repositorioDeFilmes, ILogger<FilmesController> logger)
        {
            _repositorioDeFilmes = repositorioDeFilmes;
            _logger = logger;
        }

        /// <summary>
        /// Obtém uma lista de filmes disponíveis para disputar o campeonato
        /// </summary>       
        /// <returns></returns>
        /// <response code="200">Retorna uma lista de filmes</response>
        /// <response code="500">Erro interno no servidor</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(IEnumerable<Filme>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var filmes = await _repositorioDeFilmes.ObterFilmes();
                return Ok(filmes);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Falha ao consultar a API CopaFilmes");

                return StatusCode(500);
            }          
        }
    }
}
