using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class CampeonatoPosicaoController:
        GenericApiController<Entities.Campeonatos.CampeonatoPosicao>, Business.Interfaces.Campeonatos.ICampeonatoPosicaoBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Campeonatos.ICampeonatoPosicaoBO Dao
        {
            get { return (Business.Interfaces.Campeonatos.ICampeonatoPosicaoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoPosicaoController()
            : base ( new Business.FactoryBO().CreateCampeonatoPosicaoBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}