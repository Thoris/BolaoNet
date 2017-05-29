using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoGrupoController:
        GenericApiController<Entities.Campeonatos.CampeonatoGrupo>, Business.Interfaces.Campeonatos.ICampeonatoGrupoBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Campeonatos.ICampeonatoGrupoBO Dao
        {
            get { return (Business.Interfaces.Campeonatos.ICampeonatoGrupoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoGrupoController()
            : base ( new Business.FactoryBO().CreateCampeonatoGrupoBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}