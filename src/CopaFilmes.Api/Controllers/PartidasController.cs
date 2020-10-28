using System;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CopaFilmes.Api.Controllers
{
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

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] string idsSelecionados)
        {
            try
            {
                if (string.IsNullOrEmpty(idsSelecionados))
                    return BadRequest("Nenhum ID foi informado");
             
                var filmes = await _repositorioDeFilmes
                    .ObterFilmes();

                var idsSelecionadosArr = idsSelecionados.Split(',');

                var filmesSelecionados = filmes.Where(c => idsSelecionadosArr.Contains(c.Id));

                var partidas = _gerenciadorDePartidas.DefinirPartidas(filmesSelecionados);

                _gerenciadorDeCampeonato.Disputar(partidas);

                var campeao = _gerenciadorDeCampeonato.Campeao;
                var viceCampeao = _gerenciadorDeCampeonato.ViceCampecao;

                return Ok(new { 
                    campeao,
                    viceCampeao
                });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Falha ao consultar a API CopaFilmes");

                return StatusCode(500);
            }          
        }
    }
}
