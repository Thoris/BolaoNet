using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class PagamentoController:
        GenericApiController<Domain.Entities.Boloes.Pagamento>, 
        Domain.Interfaces.Services.Boloes.IPagamentoService
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

        //public PagamentoController()
        //    : base(new Domain.Services.FactoryService(null).CreatePagamentoService())
        //{

        //}
        public PagamentoController(Domain.Interfaces.Services.Boloes.IPagamentoService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IPagamentoService members

        public IList<Domain.Entities.Boloes.Pagamento> GetPagamentosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetPagamentosBolao(bolao);
        }

        public IList<Domain.Entities.Boloes.Pagamento> GetPagamentosBolaoSoma(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetPagamentosBolaoSoma(bolao);
        }

        #endregion
    }
}