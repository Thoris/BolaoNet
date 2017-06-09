using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoTimeController:
        GenericApiController<Domain.Entities.Campeonatos.CampeonatoTime>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService Dao
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoTimeController()
            : base(new Domain.Services.FactoryService().CreateCampeonatoTimeService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}