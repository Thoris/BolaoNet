using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class PagamentoController:
        GenericApiController<Entities.Boloes.Pagamento>, Business.Interfaces.Boloes.IPagamentoBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IPagamentoBO Dao
        {
            get { return (Business.Interfaces.Boloes.IPagamentoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public PagamentoController()
            : base ( new Business.FactoryBO().CreatePagamentoBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}