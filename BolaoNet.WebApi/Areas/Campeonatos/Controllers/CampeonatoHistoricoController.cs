using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoHistoricoController:
        GenericApiController<Domain.Entities.Campeonatos.CampeonatoHistorico>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoHistoricoController()
            : base(new Domain.Services.FactoryService(null).CreateCampeonatoHistoricoService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}