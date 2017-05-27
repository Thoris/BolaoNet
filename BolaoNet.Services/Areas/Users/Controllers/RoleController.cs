using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Users.Controllers
{
    public class RoleController :
        GenericApiController<Entities.Users.Role>, Business.Interfaces.Users.IRoleBO 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Users.IRoleBO Dao
        {
            get { return (Business.Interfaces.Users.IRoleBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public RoleController()
            : base ( new Business.FactoryBO().CreateRoleBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}