using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoCriterioPontosBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoCriterioPontos>,
        Interfaces.Boloes.IBolaoCriterioPontosBO
    {
        
        #region Constructors/Destructors

        public BolaoCriterioPontosBO(string userName, Dao.Boloes.IBolaoCriterioPontosDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoCriterioPontos>)dao)
        {

        }

        #endregion

        #region IBolaoCriterioPontosBO members

        public int[] GetCriteriosPontos(Entities.Boloes.Bolao bolao)
        {

            IList<Entities.Boloes.BolaoCriterioPontos> criterios = GetCriterioPontosBolao(bolao);

            int[] values = new int[(int)Entities.Boloes.BolaoCriterioPontos.CriteriosID.Cheio + 1];

            for (int c = 0; c < criterios.Count; c++)
            {
                if (criterios[c].Pontos != null)
                    values[(int)criterios[c].CriterioID] = (int)criterios[c].Pontos;
            }

            return values;
        }

        public IList<Entities.Boloes.BolaoCriterioPontos> GetCriterioPontosBolao(Entities.Boloes.Bolao bolao)
        {
            return null;
        }
        
        #endregion
    }
}
