using BolaoNet.Domain.Entities.Campeonatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Campeonatos
{
    public class JogoIntegration :
        Base.GenericIntegration<Domain.Entities.Campeonatos.Jogo>,
        Domain.Interfaces.Services.Campeonatos.IJogoService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Jogo";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="JogoIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public JogoIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region IJogoService members

        public bool InsertResult(Domain.Entities.Campeonatos.Jogo jogo, int gols1, int? penaltis1, int gols2, int? penaltis2, bool setCurrentData, Domain.Entities.Users.User validadoBy)
        {
            Dictionary<string, object> parameters = new Dictionary<string,object>();

            parameters.Add ("jogo", jogo);
            parameters.Add ("gols1", gols1);
            parameters.Add ("penaltis1", penaltis1);
            parameters.Add ("gols2", gols2);
            parameters.Add ("penaltis2", penaltis2);
            parameters.Add ("setCurrentData", setCurrentData);
            parameters.Add ("validadoBy", validadoBy);


            return base.HttpPostApi<bool>(parameters, "InsertResult");
        }
        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosByCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return base.HttpPostApi<ICollection<Domain.Entities.Campeonatos.Jogo>>(
                new Dictionary<string, string>(), campeonato, "GetJogosByCampeonato").ToList<Domain.Entities.Campeonatos.Jogo>();
        }
        public IList<Domain.Entities.Campeonatos.Jogo> LoadJogos(int rodada, DateTime dataInicial, DateTime dataFinal, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, string condition)
        {

            Dictionary<string, object> parameters = new Dictionary<string,object>();

            parameters.Add ("rodada", rodada);
            parameters.Add ("dataInicial", dataInicial);
            parameters.Add ("dataFinal", dataFinal);
            parameters.Add ("fase", fase);
            parameters.Add ("campeonato", campeonato);
            parameters.Add ("grupo", grupo);
            parameters.Add ("condition", condition);

            return HttpPostApi<ICollection<Domain.Entities.Campeonatos.Jogo>>(parameters, "LoadJogos").ToList<Domain.Entities.Campeonatos.Jogo>();

        }
        public IList<Domain.Entities.Campeonatos.Jogo> LoadFinishedJogos(Domain.Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("campeonato", campeonato);
            parameters.Add("totalJogos", totalJogos);

            return HttpPostApi<ICollection<Domain.Entities.Campeonatos.Jogo>>(parameters, "LoadFinishedJogos").ToList<Domain.Entities.Campeonatos.Jogo>();


        }
        public IList<Domain.Entities.Campeonatos.Jogo> LoadNextJogos(Domain.Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("campeonato", campeonato);
            parameters.Add("totalJogos", totalJogos);

            return HttpPostApi<ICollection<Domain.Entities.Campeonatos.Jogo>>(parameters, "LoadNextJogos").ToList<Domain.Entities.Campeonatos.Jogo>();

        }
        public IList<Domain.Entities.Campeonatos.Jogo> GetJogos(Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.ValueObjects.FilterJogosVO filter)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("campeonato", campeonato);
            parameters.Add("filter", filter);

            return HttpPostApi<ICollection<Domain.Entities.Campeonatos.Jogo>>(parameters, "GetJogos").ToList<Domain.Entities.Campeonatos.Jogo>();

        }
        public IList<Domain.Entities.Campeonatos.Jogo> SelectGoleadas(Domain.Entities.Campeonatos.Campeonato campeonato, int maxGols)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            parameters.Add("campeonato", campeonato);
            parameters.Add("maxGols", maxGols);

            return HttpPostApi<ICollection<Domain.Entities.Campeonatos.Jogo>>(parameters, "SelectGoleadas").ToList<Domain.Entities.Campeonatos.Jogo>();

        }
        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosTimesPossibilidades(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return base.HttpPostApi<ICollection<Domain.Entities.Campeonatos.Jogo>>(
            new Dictionary<string, string>(), campeonato, "GetJogosTimesPossibilidades").ToList<Domain.Entities.Campeonatos.Jogo>();
       
        }
        public Jogo GetLastValidJogo(Campeonato campeonato)
        {
            return base.HttpGetApi<Jogo>(new Dictionary<string, string>(), campeonato, "GetLastValidJogo");
        }

        #endregion
    }
}
