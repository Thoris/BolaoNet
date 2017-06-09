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
        public JogoIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion

        #region IJogoService members

        public bool InsertResult(Domain.Entities.Campeonatos.Jogo jogo, int gols1, int? penaltis1, int gols2, int? penaltis2, bool setCurrentData, Domain.Entities.Users.User validadoBy)
        {
            throw new NotImplementedException();
        }
        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosByCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("nomeCampeonato", campeonato.Nome);


            return base.HttpGetApi<ICollection<Domain.Entities.Campeonatos.Jogo>>(
                parameters, "GetJogosByCampeonato").ToList();
        }

        #endregion


        public IList<Domain.Entities.Campeonatos.Jogo> LoadJogos(int rodada, DateTime dataInicial, DateTime dataFinal, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, string condition)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Campeonatos.Jogo> LoadFinishedJogos(Domain.Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            throw new NotImplementedException();
        }

        public IList<Domain.Entities.Campeonatos.Jogo> LoadNextJogos(Domain.Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            throw new NotImplementedException();
        }
    }
}
