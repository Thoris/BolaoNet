using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoGrupoTimeController:
        GenericApiController<Domain.Entities.Campeonatos.CampeonatoGrupoTime>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService Dao
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoGrupoTimeController()
            : base(new Domain.Services.FactoryService().CreateCampeonatoGrupoTimeService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}