using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoMembroClassificacaoController :
        GenericApiController<Entities.Boloes.BolaoMembroClassificacao>, Business.Interfaces.Boloes.IBolaoMembroClassificacaoBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoMembroClassificacaoBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoMembroClassificacaoBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoMembroClassificacaoController()
            : base(new Business.FactoryBO().CreateBolaoMembroClassificacaoBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}