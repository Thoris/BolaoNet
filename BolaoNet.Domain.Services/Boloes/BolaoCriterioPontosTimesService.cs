using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoCriterioPontosTimesService :
        Base.BaseGenericService<Entities.Boloes.BolaoCriterioPontosTimes>,
        Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService
    {
        #region Constructors/Destructors

        public BolaoCriterioPontosTimesService(string userName, Interfaces.Repositories.Boloes.IBolaoCriterioPontosTimesDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoCriterioPontosTimes>)dao, logging)
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
