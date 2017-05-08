using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class PontuacaoBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.Pontuacao>,
        Interfaces.Campeonatos.IPontuacaoBO
    {
        #region Constructors/Destructors

        public PontuacaoBO(string userName, Dao.Campeonatos.IPontuacaoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.Pontuacao>)dao)
        {

        }

        #endregion
    }
}
