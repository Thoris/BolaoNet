using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.DadosBasicos.Controllers
{
    public class PagamentoTipoController:
        GenericApiController<Domain.Entities.DadosBasicos.PagamentoTipo>, Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService Service
        {
            get { return (Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public PagamentoTipoController()
            : base(new Domain.Services.FactoryService(null).CreatePagamentoTipoService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}