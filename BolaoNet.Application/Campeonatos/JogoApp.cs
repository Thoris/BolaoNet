using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class JogoApp :
        Base.GenericApp<Domain.Entities.Campeonatos.Jogo>,
        Application.Interfaces.Campeonatos.IJogoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Campeonatos.IJogoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.IJogoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="JogoApp" />.
        /// </summary>
        public JogoApp(Domain.Interfaces.Services.Campeonatos.IJogoService service)
            : base (service)
        {

        }

        #endregion

        #region IJogoService members

        public bool InsertResult(Domain.Entities.Campeonatos.Jogo jogo, int gols1, int? penaltis1, int gols2, int? penaltis2, bool setCurrentData, Domain.Entities.Users.User validadoBy)
        {
            return Service.InsertResult(jogo, gols1, penaltis1, gols2, penaltis2, setCurrentData, validadoBy);
        }
        public IList<Domain.Entities.Campeonatos.Jogo> GetJogosByCampeonato(Domain.Entities.Campeonatos.Campeonato campeonato)
        {
            return Service.GetJogosByCampeonato(campeonato);
        }

        public IList<Domain.Entities.Campeonatos.Jogo> LoadJogos(int rodada, DateTime dataInicial, DateTime dataFinal, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, string condition)
        {
            return Service.LoadJogos(rodada, dataInicial, dataFinal, fase, campeonato, grupo, condition);
        }

        public IList<Domain.Entities.Campeonatos.Jogo> LoadFinishedJogos(Domain.Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            return Service.LoadFinishedJogos(campeonato, totalJogos);
        }

        public IList<Domain.Entities.Campeonatos.Jogo> LoadNextJogos(Domain.Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            return Service.LoadNextJogos(campeonato, totalJogos);
        }

        #endregion
    }
}
