namespace CopaFilmes.Api.Models
{
    public class ResultadoCampeonato
    {
        public ResultadoCampeonato(Filme campeao, Filme viceCampeao)
        {
            Campeao = campeao;
            ViceCampeao = viceCampeao;
        }

        public Filme Campeao { get; private set; }

        public Filme ViceCampeao { get; private set; }
    }
}
