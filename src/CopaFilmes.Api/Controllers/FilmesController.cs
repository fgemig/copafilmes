using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CopaFilmes.Api.Configs;
using CopaFilmes.Api.Interfaces;
using CopaFilmes.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace CopaFilmes.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly IRepositorioDeFilmes _repositorioDeFilmes;
        private readonly IMemoryCache _cache;
        private readonly ILogger<FilmesController> _logger;

        public FilmesController(IRepositorioDeFilmes repositorioDeFilmes, IMemoryCache cache, ILogger<FilmesController> logger)
        {
            _repositorioDeFilmes = repositorioDeFilmes;
            _cache = cache;
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
        public async Task<IActionResult> ObterFilmes()
        {
            try
            {
                if (_cache.TryGetValue(ChavesCache.FILMES, out IEnumerable<Filme> filmesCache))
                {
                    return Ok(filmesCache);                   
                }

                var filmes = await _repositorioDeFilmes.ObterFilmes();

                _cache.Set(ChavesCache.FILMES, filmes, new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30)));

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
