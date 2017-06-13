using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoController:
        GenericApiController<Domain.Entities.Campeonatos.Campeonato>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.ICampeonatoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoController()
            : base(new Domain.Services.FactoryService(null).CreateCampeonatoService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}