using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class BolaoCriterioPontosTimesBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.BolaoCriterioPontosTimes>,
        Interfaces.Boloes.IBolaoCriterioPontosTimesBO
    {
        #region Constructors/Destructors

        public BolaoCriterioPontosTimesBO(string userName, Dao.Boloes.IBolaoCriterioPontosTimesDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.BolaoCriterioPontosTimes>)dao)
        {

        }

        #endregion

        #region IBolaoCriterioPontosTimesBO members

        public IList<Entities.Boloes.BolaoCriterioPontosTimes> GetCriterioPontosBolao(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return GetList( x => string.Compare(x.NomeBolao, bolao.Nome, true) == 0).ToList<Entities.Boloes.BolaoCriterioPontosTimes>();
            
        }

        #endregion
    }
}
