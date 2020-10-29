using System.Collections.Generic;

namespace CopaFilmes.Api.Models
{
    public class ResultadoCampeonato
    {
        public ResultadoCampeonato(Filme campeao, Filme viceCampeao, IEnumerable<Partida> partidasJogadas)
        {
            Campeao = campeao;
            ViceCampeao = viceCampeao;
            PartidasJogadas = partidasJogadas;
        }

        public Filme Campeao { get; private set; }

        public Filme ViceCampeao { get; private set; }

        IEnumerable<Partida> PartidasJogadas { get; }
    }
}
