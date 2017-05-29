using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoFaseController:
        GenericApiController<Entities.Campeonatos.CampeonatoFase>, Business.Interfaces.Campeonatos.ICampeonatoFaseBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Campeonatos.ICampeonatoFaseBO Dao
        {
            get { return (Business.Interfaces.Campeonatos.ICampeonatoFaseBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoFaseController()
            : base ( new Business.FactoryBO().CreateCampeonatoFaseBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}