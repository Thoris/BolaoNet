using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoCriterioPontosController:
        GenericApiController<Domain.Entities.Boloes.BolaoCriterioPontos>, 
        Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoCriterioPontosController()
            : base(new Domain.Services.FactoryService().CreateBolaoCriterioPontosService())
        {

        }

        #endregion

        #region Methods


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