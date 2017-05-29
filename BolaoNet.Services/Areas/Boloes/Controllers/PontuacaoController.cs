using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class PontuacaoController:
        GenericApiController<Entities.Boloes.Pontuacao>, Business.Interfaces.Boloes.IPontuacaoBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IPontuacaoBO Dao
        {
            get { return (Business.Interfaces.Boloes.IPontuacaoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public PontuacaoController()
            : base ( new Business.FactoryBO().CreatePontuacaoBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}