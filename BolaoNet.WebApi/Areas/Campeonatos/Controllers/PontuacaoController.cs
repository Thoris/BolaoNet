using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class PontuacaoController:
        GenericApiController<Domain.Entities.Campeonatos.Pontuacao>, Domain.Interfaces.Services.Campeonatos.IPontuacaoService 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.IPontuacaoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.IPontuacaoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public PontuacaoController()
            : base ( null)
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}