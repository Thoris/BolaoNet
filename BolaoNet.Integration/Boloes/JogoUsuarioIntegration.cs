using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Boloes
{
    public class JogoUsuarioIntegration :
        Base.GenericIntegration<Entities.Boloes.JogoUsuario>,
        Business.Interfaces.Boloes.IJogoUsuarioBO
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "JogoUsuario";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="JogoUsuarioIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public JogoUsuarioIntegration(string url)
            : base (url, ModuleName)
        {

        }

        #endregion

        #region IJogoUsuarioBO members

        public bool InsertAposta(Entities.Campeonatos.Jogo jogo, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2)
        {
            throw new NotImplementedException();
        }


        public bool InsertAposta(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.Jogo jogo, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2)
        {
            throw new NotImplementedException();
        }

        public IList<Entities.Boloes.JogoUsuario> SearchJogoByDependenciaId(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.Jogo jogo)
        {
            throw new NotImplementedException();
        }

        public bool IsGrupoAlreadyApostasDone(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.CampeonatoGrupo grupo)
        {
            throw new NotImplementedException();
        }


        public int CalculatePontos(Entities.Interfaces.IPontosJogosUsuarioEntity pontosJogo, int time1, int time2, int? penaltis1, int? penaltis2, int apostaTime1, int apostaTime2, int? apostaPenaltis1, int? apostaPenaltis2)
        {
            throw new NotImplementedException();
        }
        public int CalculatePontosJogo(int[] values, IList<Entities.Boloes.BolaoCriterioPontosTimes> criteriosTimes, Entities.Interfaces.IPontosJogosUsuarioEntity pontosJogo, string nomeTime1, string nomeTime2, int time1, int time2, int? penaltis1, int? penaltis2, int apostaTime1, int apostaTime2, int? apostaPenaltis1, int? apostaPenaltis2)
        {
            throw new NotImplementedException();
        }
        public int CalculatePontos(Entities.Interfaces.IPontosJogosUsuarioEntity pontosJogo, int[] values)
        {
            throw new NotImplementedException();
        }
        public IList<Entities.Boloes.JogoUsuario> SearchJogosFromId(Entities.Campeonatos.Jogo jogo)
        {
            throw new NotImplementedException();
        }
        #endregion











        public bool UpdatePontuacao(Entities.Boloes.JogoUsuario jogoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
