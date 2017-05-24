using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class JogoBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.Jogo>,
        Interfaces.Campeonatos.IJogoBO
    {

        #region Properties

        private Dao.Campeonatos.IJogoDao Dao
        {
            get { return (Dao.Campeonatos.IJogoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public JogoBO(string userName, Dao.Campeonatos.IJogoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.Jogo>)dao)
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

        #endregion
    }
}
