using System;
using System.Threading.Tasks;
using CopaFilmes.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CopaFilmes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly IRepositorioDeFilmes _repositorioDeFilmes;
        private readonly ILogger<FilmesController> _logger;

        public FilmesController(
            IRepositorioDeFilmes repositorioDeFilmes,
            ILogger<FilmesController> logger)
        {
            _repositorioDeFilmes = repositorioDeFilmes;
            _logger = logger;
        }

        [HttpGet]
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
