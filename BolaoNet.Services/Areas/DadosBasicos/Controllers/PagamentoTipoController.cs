using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.DadosBasicos.Controllers
{
    public class PagamentoTipoController:
        GenericApiController<Entities.DadosBasicos.PagamentoTipo>, Business.Interfaces.DadosBasicos.IPagamentoTipoBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.DadosBasicos.IPagamentoTipoBO Dao
        {
            get { return (Business.Interfaces.DadosBasicos.IPagamentoTipoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public PagamentoTipoController()
            : base ( new Business.FactoryBO().CreatePagamentoTipoBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}