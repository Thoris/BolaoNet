using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.WebApi.Areas.Boloes.Controllers
{
    public class BolaoAcertoTimePontoController:
        GenericApiController<Domain.Entities.Boloes.BolaoAcertoTimePonto>,
        Domain.Interfaces.Services.Boloes.IBolaoAcertoTimePontoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoAcertoTimePontoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoAcertoTimePontoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors
         
        public BolaoAcertoTimePontoController(Domain.Interfaces.Services.Boloes.IBolaoAcertoTimePontoService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IBolaoAcertoTimePontoService members

       

        #endregion
    }
}