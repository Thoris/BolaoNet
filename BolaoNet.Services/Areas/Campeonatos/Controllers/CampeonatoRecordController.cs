using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoRecordController:
        GenericApiController<Entities.Campeonatos.CampeonatoRecord>, Business.Interfaces.Campeonatos.ICampeonatoRecordBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Campeonatos.ICampeonatoRecordBO Dao
        {
            get { return (Business.Interfaces.Campeonatos.ICampeonatoRecordBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoRecordController()
            : base ( new Business.FactoryBO().CreateCampeonatoRecordBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}