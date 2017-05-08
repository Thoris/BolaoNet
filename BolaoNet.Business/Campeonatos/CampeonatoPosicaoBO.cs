using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Campeonatos
{
    public class CampeonatoPosicaoBO :
        Base.BaseGenericBusinessBO<Entities.Campeonatos.CampeonatoPosicao>,
        Interfaces.Campeonatos.ICampeonatoPosicaoBO
    {
        #region Constructors/Destructors

        public CampeonatoPosicaoBO(string userName, Dao.Campeonatos.ICampeonatoPosicaoDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Campeonatos.CampeonatoPosicao>)dao)
        {

        }

        #endregion
    }
}
