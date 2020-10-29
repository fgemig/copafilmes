using CopaFilmes.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Api.Interfaces
{
    public interface IRepositorioDeFilmes
    {
        Task<IEnumerable<Filme>> ObterFilmes();
        Task<IEnumerable<Filme>> ObterFilmesPorIds(string[] ids);
    }
}
