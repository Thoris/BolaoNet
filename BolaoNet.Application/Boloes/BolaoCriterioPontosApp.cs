using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoCriterioPontosApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoCriterioPontos>,
        Application.Interfaces.Boloes.IBolaoCriterioPontosApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoCriterioPontosApp" />.
        /// </summary>
        public BolaoCriterioPontosApp(Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService service)
            : base (service)
        {

        }

        #endregion    
    
        #region IBolaoCriterioPontosService members

        public int[] GetCriteriosPontos(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetCriteriosPontos(bolao);
        }

        public IList<Domain.Entities.Boloes.BolaoCriterioPontos> GetCriterioPontosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetCriterioPontosBolao(bolao);
        }

        #endregion
    }
}
