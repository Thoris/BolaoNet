using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoCriterioPontosTimesApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoCriterioPontosTimes>,
        Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoCriterioPontosTimesApp" />.
        /// </summary>
        public BolaoCriterioPontosTimesApp(Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService service)
            : base (service)
        {

        }

        #endregion 

        #region IBolaoCriterioPontosTimesService members

        public IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> GetCriterioPontosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetCriterioPontosBolao(bolao);
        }

        #endregion
    }
}
