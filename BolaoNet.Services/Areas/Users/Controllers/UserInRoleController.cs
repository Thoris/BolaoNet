using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Users.Controllers
{
    public class UserInRoleController:
        GenericApiController<Entities.Users.UserInRole>, Business.Interfaces.Users.IUserInRoleBO
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Users.IUserInRoleBO Dao
        {
            get { return (Business.Interfaces.Users.IUserInRoleBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public UserInRoleController()
            : base ( new Business.FactoryBO().CreateUserInRoleBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}