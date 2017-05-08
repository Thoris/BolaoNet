using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class CampeonatoClassificacaoBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.CampeonatoClassificacao>,
        Interfaces.Campeonatos.ICampeonatoClassificacaoBO
    {
        #region Constructors/Destructors

        public CampeonatoClassificacaoBO(string userName, Dao.Campeonatos.ICampeonatoClassificacaoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.CampeonatoClassificacao>)dao)
        {

        }

        #endregion
    }
}
