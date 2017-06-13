using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoPosicaoController:
        GenericApiController<Domain.Entities.Campeonatos.CampeonatoPosicao>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoPosicaoController()
            : base(new Domain.Services.FactoryService(null).CreateCampeonatoPosicaoService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}