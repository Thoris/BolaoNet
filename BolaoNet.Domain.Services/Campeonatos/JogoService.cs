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


            if (IsSaveLog)
                CheckStart();

            bool res = Dao.InsertResult(base.CurrentUserName, DateTime.Now, jogo, gols1, penaltis1, gols2, penaltis2, setCurrentData, validadoBy);


            if (IsSaveLog)
            {
                if (res)
                    _logging.Info(this, GetMessageTotalTime("Inclusão de resultado [" + jogo.JogoId + "] gols1 [" + gols1 + "] gols2 [" + gols2 + "] setcurrent[" + setCurrentData + "] por validado [" + validadoBy.UserName + "] res: " + res));
                else
                    _logging.Warn(this, GetMessageTotalTime("Inclusão de resultado [" + jogo.JogoId + "] gols1 [" + gols1 + "] gols2 [" + gols2 + "] setcurrent[" + setCurrentData + "] por validado [" + validadoBy.UserName + "] res: " + res));
            
            }

            return res;
        }
        public IList<Entities.Campeonatos.Jogo> GetJogosByCampeonato(Entities.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Campeonatos.Jogo> res = Dao.GetJogosByCampeonato(this.CurrentUserName, campeonato);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Buscando jogos do campeonato [" + campeonato.Nome + "] total: " + res.Count));
            }

            return res;
        
        }
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

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Campeonatos.Jogo> res = Dao.LoadJogos(base.CurrentUserName, DateTime.Now, rodada, dataInicial, dataFinal,
                fase, campeonato, grupo, condition);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Buscando jogos do campeonato [" + campeonato.Nome + "] por período. total: " + res.Count));
            }

            return res;
        }
        public IList<Entities.Campeonatos.Jogo> LoadFinishedJogos(Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");
            if (totalJogos == 0)
                throw new ArgumentException("totalJogos");

            if (IsSaveLog)
                CheckStart();
            
            
            IList<Entities.Campeonatos.Jogo> res = Dao.LoadFinishedJogos(base.CurrentUserName, DateTime.Now, campeonato, totalJogos);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregando jogos finalizados do campeonato [" + campeonato.Nome + "] máximo [" + totalJogos + "] total: " + res.Count));
            }

            return res;

        }
        public IList<Entities.Campeonatos.Jogo> LoadNextJogos(Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");
            if (totalJogos == 0)
                throw new ArgumentException("totalJogos");

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Campeonatos.Jogo> res = Dao.LoadNextJogos(base.CurrentUserName, DateTime.Now, campeonato, totalJogos);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Buscando próximos jogos do campeonato [" + campeonato.Nome + "] máximo [" + totalJogos + "] total: " + res.Count));
            }

            return res;
        }
        public IList<Entities.Campeonatos.Jogo> GetJogos(Entities.Campeonatos.Campeonato campeonato, Entities.ValueObjects.FilterJogosVO filter)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");
            if (filter == null)
                throw new ArgumentException("filter");

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Campeonatos.Jogo> res = Dao.GetJogos(base.CurrentUserName, DateTime.Now, campeonato, filter);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Buscando jogos do campeonato [" + campeonato.Nome + "] total: " + res.Count));
            }

            return res;
        }
        public IList<Entities.Campeonatos.Jogo> SelectGoleadas(Entities.Campeonatos.Campeonato campeonato, int maxGols)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Campeonatos.Jogo> res = Dao.SelectGoleadas(base.CurrentUserName, DateTime.Now, campeonato, maxGols);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Buscando goleadas do campeonato [" + campeonato.Nome + "] total: " + res.Count));
            }

            return res;
        }
        public IList<Entities.Campeonatos.Jogo> GetJogosTimesPossibilidades(Entities.Campeonatos.Campeonato campeonato)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Campeonatos.Jogo> res = Dao.GetJogosTimesPossibilidades(base.CurrentUserName, DateTime.Now, campeonato);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Buscando jogos do campeonato [" + campeonato.Nome + "] que não foram concluídos e que estão em fase de eliminação: " + res.Count));
            }

            return res;
        }

        #endregion
    }
}
