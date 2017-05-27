using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoPontoRodadaUsuarioController:
        GenericApiController<Entities.Boloes.BolaoPontoRodadaUsuario>, Business.Interfaces.Boloes.IBolaoPontoRodadaUsuarioBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoPontoRodadaUsuarioBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoPontoRodadaUsuarioBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoPontoRodadaUsuarioController()
            : base(new Business.FactoryBO().CreateBolaoPontoRodadaUsuarioBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}