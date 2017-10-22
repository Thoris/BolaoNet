using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

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

        [HttpPost]
        public override long Insert(Domain.Entities.Boloes.Pagamento entity)
        {
            long res = base.BaseBo.Insert(entity);

            Domain.Entities.Base.BaseEntity baseEntity = entity as Domain.Entities.Base.BaseEntity;

            string identityName = baseEntity.GetIdentifyName();

            if (string.IsNullOrEmpty(identityName))
                return res;

            object resIdentity = baseEntity.GetIdentityValue();

            return  1;
        }

        [HttpPost]
        public override bool Delete(Domain.Entities.Boloes.Pagamento entity)
        {
            Domain.Entities.Boloes.Pagamento entityLoaded = base.Load(entity);

            return base.Delete(entityLoaded);
        }
        [HttpPost]
        public IList<Domain.Entities.Boloes.Pagamento> GetPagamentosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetPagamentosBolao(bolao);
        }

        [HttpPost]
        public IList<Domain.Entities.Boloes.Pagamento> GetPagamentosBolaoSoma(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetPagamentosBolaoSoma(bolao);
        }

        #endregion
    }
}