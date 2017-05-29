using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoGrupoTimeController:
        GenericApiController<Entities.Campeonatos.CampeonatoGrupoTime>, Business.Interfaces.Campeonatos.ICampeonatoGrupoTimeBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Campeonatos.ICampeonatoGrupoTimeBO Dao
        {
            get { return (Business.Interfaces.Campeonatos.ICampeonatoGrupoTimeBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoGrupoTimeController()
            : base ( new Business.FactoryBO().CreateCampeonatoGrupoTimeBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}