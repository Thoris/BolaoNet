using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoMembroClassificacaoController :
        GenericApiController<Domain.Entities.Boloes.BolaoMembroClassificacao>,
        Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public BolaoMembroClassificacaoController()
        //    : base(new Domain.Services.FactoryService(null).CreateBolaoMembroClassificacaoService())
        //{

        //}
        public BolaoMembroClassificacaoController(Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService service)
            : base(service)
        {

        }

        #endregion

        #region Methods

        [HttpPost]
        public IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> LoadClassificacao(Domain.Entities.Boloes.Bolao bolao, int? rodada)
        {
            return Service.LoadClassificacao(bolao, rodada);
        }

        #endregion


    }
}