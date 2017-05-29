using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoTimeController:
        GenericApiController<Entities.Campeonatos.CampeonatoTime>, Business.Interfaces.Campeonatos.ICampeonatoTimeBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Campeonatos.ICampeonatoTimeBO Dao
        {
            get { return (Business.Interfaces.Campeonatos.ICampeonatoTimeBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoTimeController()
            : base ( new Business.FactoryBO().CreateCampeonatoTimeBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}