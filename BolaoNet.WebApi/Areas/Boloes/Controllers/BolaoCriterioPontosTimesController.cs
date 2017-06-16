using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoCriterioPontosTimesController:
        GenericApiController<Domain.Entities.Boloes.BolaoCriterioPontosTimes>, 
        Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public BolaoCriterioPontosTimesController()
        //    : base(new Domain.Services.FactoryService(null).CreateBolaoCriterioPontosTimesService())
        //{

        //}
        public BolaoCriterioPontosTimesController(Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IBolaoCriterioPontosTimesService members


        public IList<Domain.Entities.Boloes.BolaoCriterioPontosTimes> GetCriterioPontosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetCriterioPontosBolao(bolao);
        }

        #endregion
    }
}