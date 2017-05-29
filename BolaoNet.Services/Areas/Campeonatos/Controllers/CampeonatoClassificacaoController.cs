using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoClassificacaoController:
        GenericApiController<Entities.Campeonatos.CampeonatoClassificacao>, Business.Interfaces.Campeonatos.ICampeonatoClassificacaoBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Campeonatos.ICampeonatoClassificacaoBO Dao
        {
            get { return (Business.Interfaces.Campeonatos.ICampeonatoClassificacaoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoClassificacaoController()
            : base ( new Business.FactoryBO().CreateCampeonatoClassificacaoBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}