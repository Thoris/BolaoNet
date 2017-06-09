using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoRecordController:
        GenericApiController<Domain.Entities.Campeonatos.CampeonatoRecord>,
        Domain.Interfaces.Services.Campeonatos.ICampeonatoRecordService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Campeonatos.ICampeonatoRecordService Dao
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoRecordService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoRecordController()
            : base(new Domain.Services.FactoryService().CreateCampeonatoRecordService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}