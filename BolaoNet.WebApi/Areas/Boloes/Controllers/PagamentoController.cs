using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class PagamentoController:
        GenericApiController<Domain.Entities.Boloes.Pagamento>, Domain.Interfaces.Services.Boloes.IPagamentoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IPagamentoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IPagamentoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public PagamentoController()
            : base(new Domain.Services.FactoryService().CreatePagamentoService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}