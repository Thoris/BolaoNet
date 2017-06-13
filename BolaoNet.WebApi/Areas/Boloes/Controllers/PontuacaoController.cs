using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class PontuacaoController:
        GenericApiController<Domain.Entities.Boloes.Pontuacao>, Domain.Interfaces.Services.Boloes.IPontuacaoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IPontuacaoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IPontuacaoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public PontuacaoController()
            : base(new Domain.Services.FactoryService(null).CreatePontuacaoService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}