using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoRegraController:
        GenericApiController<Domain.Entities.Boloes.BolaoRegra>,
        Domain.Interfaces.Services.Boloes.IBolaoRegraService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoRegraService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoRegraService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public BolaoRegraController()
        //    : base(new Domain.Services.FactoryService(null).CreateBolaoRegraService())
        //{

        //}
        public BolaoRegraController(Domain.Interfaces.Services.Boloes.IBolaoRegraService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IBolaoRegraService members

        [HttpPost]
        public IList<Domain.Entities.Boloes.BolaoRegra> GetRegrasBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetRegrasBolao(bolao);
        }

        #endregion
    }
}