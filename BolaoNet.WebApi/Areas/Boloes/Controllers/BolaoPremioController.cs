using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoPremioController:
        GenericApiController<Domain.Entities.Boloes.BolaoPremio>, 
        Domain.Interfaces.Services.Boloes.IBolaoPremioService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoPremioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoPremioService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public BolaoPremioController()
        //    : base(new Domain.Services.FactoryService(null).CreateBolaoPremioService())
        //{

        //}
        public BolaoPremioController(Domain.Interfaces.Services.Boloes.IBolaoPremioService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IBolaoPremioService members

        [HttpPost]
        public IList<Domain.Entities.Boloes.BolaoPremio> GetPremiosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetPremiosBolao(bolao);
        }

        #endregion
    }
}