using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoPremioController:
        GenericApiController<Entities.Boloes.BolaoPremio>, Business.Interfaces.Boloes.IBolaoPremioBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Boloes.IBolaoPremioBO Dao
        {
            get { return (Business.Interfaces.Boloes.IBolaoPremioBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoPremioController()
            : base ( new Business.FactoryBO().CreateBolaoPremioBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}