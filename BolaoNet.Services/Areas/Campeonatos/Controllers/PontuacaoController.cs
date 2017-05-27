using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Campeonatos.Controllers
{
    public class PontuacaoController:
        GenericApiController<Entities.Campeonatos.Pontuacao>, Business.Interfaces.Campeonatos.IPontuacaoBO 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Campeonatos.IPontuacaoBO Dao
        {
            get { return (Business.Interfaces.Campeonatos.IPontuacaoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public PontuacaoController()
            : base ( null)
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}