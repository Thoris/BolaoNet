using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoController:
        GenericApiController<Entities.Campeonatos.Campeonato>, Business.Interfaces.Campeonatos.ICampeonatoBO 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Campeonatos.ICampeonatoBO Dao
        {
            get { return (Business.Interfaces.Campeonatos.ICampeonatoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoController()
            : base ( new Business.FactoryBO().CreateCampeonatoBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}