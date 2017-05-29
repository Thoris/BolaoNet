using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoPontuacaoController:
        GenericApiController<Entities.Boloes.BolaoPontuacao>, Business.Interfaces.Boloes.IBolaoPontuacaoBO 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoPontuacaoBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoPontuacaoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoPontuacaoController()
            : base ( new Business.FactoryBO().CreateBolaoPontuacaoBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}