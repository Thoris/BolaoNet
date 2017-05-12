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
        #region Constructors/Destructors

        public JogoBO(string userName, Dao.Campeonatos.IJogoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.Jogo>)dao)
        {

        }

        #endregion

    }
}
