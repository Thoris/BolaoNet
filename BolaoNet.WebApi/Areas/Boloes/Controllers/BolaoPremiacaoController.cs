using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoPremiacaoController:
        GenericApiController<Domain.Entities.Boloes.BolaoPremiacao>, 
        Domain.Interfaces.Services.Boloes.IBolaoPremiacaoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoPremiacaoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoPremiacaoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public BolaoCriterioPontosController()
        //    : base(new Domain.Services.FactoryService(null).CreateBolaoCriterioPontosService())
        //{

        //}
        public BolaoPremiacaoController(Domain.Interfaces.Services.Boloes.IBolaoPremiacaoService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IBolaoCriterioPontosService members

        [HttpPost]
        public IList<Domain.Entities.Boloes.BolaoPremiacao> LoadPremiacaoBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.LoadPremiacaoBolao(bolao);
        }

        #endregion

    }
}