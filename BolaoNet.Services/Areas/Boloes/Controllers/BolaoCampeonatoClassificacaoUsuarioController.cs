using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoCampeonatoClassificacaoUsuarioController:
        GenericApiController<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>,
        Business.Interfaces.Boloes.IBolaoCampeonatoClassificacaoUsuarioBO 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoCampeonatoClassificacaoUsuarioBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoCampeonatoClassificacaoUsuarioBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoCampeonatoClassificacaoUsuarioController()
            : base(new Business.FactoryBO().CreateBolaoCampeonatoClassificacaoUsuarioBO())
        {

        }

        #endregion

        #region Methods


        #endregion


    }
}