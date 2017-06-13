using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class JogoService :
        Base.BaseGenericService<Entities.Campeonatos.Jogo>,
        Interfaces.Services.Campeonatos.IJogoService
    {

        #region Properties

        private Interfaces.Repositories.Campeonatos.IJogoDao Dao
        {
            get { return (Interfaces.Repositories.Campeonatos.IJogoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public JogoService(string userName, Interfaces.Repositories.Campeonatos.IJogoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.Jogo>)dao, logging)
        {
            if (dao == null)
                throw new ArgumentException("dao");

        }

        #endregion

        #region IJogoBO members

        public bool InsertResult(Entities.Campeonatos.Jogo jogo, int gols1, int? penaltis1, int gols2, int? penaltis2, bool setCurrentData, Entities.Users.User validadoBy)
        {
            if (jogo == null)
                throw new ArgumentException("jogo");
            if (jogo.JogoId == 0)
                throw new ArgumentException("jogo.Id");
            if (validadoBy == null)
                throw new ArgumentException("validadoBy");
            if (string.IsNullOrEmpty(validadoBy.UserName))
                throw new ArgumentException("validadoBy.UserName");


            return Dao.InsertResult(base.CurrentUserName, DateTime.Now, jogo, gols1, penaltis1, gols2, penaltis2, setCurrentData, validadoBy);
        }
        public IList<Entities.Campeonatos.Jogo> GetJogosByCampeonato(Entities.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");

            return Dao.GetJogosByCampeonato(this.CurrentUserName, campeonato);
        }

        #endregion





        public IList<Entities.Campeonatos.Jogo> LoadJogos(int rodada, DateTime dataInicial, DateTime dataFinal, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.Campeonato campeonato, Entities.Campeonatos.CampeonatoGrupo grupo, string condition)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");
            if (fase == null)
                throw new ArgumentException("fase");
            if (string.IsNullOrEmpty(fase.Nome))
                throw new ArgumentException("fase.Nome");
            if (grupo == null)
                throw new ArgumentException("grupo");
            if (string.IsNullOrEmpty(grupo.Nome))
                throw new ArgumentException("grupo.Nome");


            return Dao.LoadJogos(base.CurrentUserName, DateTime.Now, rodada, dataInicial, dataFinal,
                fase, campeonato, grupo, condition);
        }

        public IList<Entities.Campeonatos.Jogo> LoadFinishedJogos(Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");
            if (totalJogos == 0)
                throw new ArgumentException("totalJogos");

            return Dao.LoadFinishedJogos(base.CurrentUserName, DateTime.Now, campeonato, totalJogos);

        }

        public IList<Entities.Campeonatos.Jogo> LoadNextJogos(Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");
            if (totalJogos == 0)
                throw new ArgumentException("totalJogos");

            return Dao.LoadNextJogos(base.CurrentUserName, DateTime.Now, campeonato, totalJogos);
        }
    }
}
