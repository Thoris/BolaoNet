using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoHistoricoController:
        GenericApiController<Entities.Campeonatos.CampeonatoHistorico>, Business.Interfaces.Campeonatos.ICampeonatoHistoricoBO 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Campeonatos.ICampeonatoHistoricoBO Dao
        {
            get { return (Business.Interfaces.Campeonatos.ICampeonatoHistoricoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoHistoricoController()
            : base ( new Business.FactoryBO().CreateCampeonatoHistoricoBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}