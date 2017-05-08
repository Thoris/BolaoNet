using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Campeonatos
{
    public class JogoRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Campeonatos.Jogo>, Dao.Campeonatos.IJogoDao
    {
        
        #region Constructors/Destructors

        public JogoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IJogoDao Members

        public bool InsertResult(string currentUserName, int gols1, int gols2, int? penaltis1, int? penaltis2, Entities.Campeonatos.Jogo entry)
        {
            throw new NotImplementedException();
        }

        public bool RemoveResult(string currentUserName, Entities.Campeonatos.Jogo entry)
        {
            throw new NotImplementedException();
        }

        public IList<Entities.Campeonatos.Jogo> SelectAllByPeriod(string currentUser, int rodada, Entities.Campeonatos.Campeonato campeonato, DateTime dataInicial, DateTime dataFinal, string time, string fase, string grupo)
        {
            throw new NotImplementedException();
        }

        public IList<Entities.Campeonatos.Jogo> SelectJogosByTime(string currentUser, Entities.Campeonatos.Campeonato campeonato, Entities.DadosBasicos.Time time)
        {
            throw new NotImplementedException();
        }

        public IList<Entities.Campeonatos.Jogo> SelectGoleadas(string currentUser, Entities.Campeonatos.Campeonato campeonato, int maxGols)
        {
            throw new NotImplementedException();
        }

        public IList<Entities.Campeonatos.Jogo> LoadNextJogos(string currentUser, Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            throw new NotImplementedException();
        }

        public IList<Entities.Campeonatos.Jogo> LoadFinishedJogos(string currentUser, Entities.Campeonatos.Campeonato campeonato, int totalJogos)
        {
            throw new NotImplementedException();
        }

        public int NextJogo(string currentUser, Entities.Campeonatos.Campeonato campeonato)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
