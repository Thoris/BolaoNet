using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Users.Controllers
{
    public class UserInRoleController:
        GenericApiController<Domain.Entities.Users.UserInRole>,
        Domain.Interfaces.Services.Users.IUserInRoleService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Users.IUserInRoleService Dao
        {
            get { return (Domain.Interfaces.Services.Users.IUserInRoleService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public UserInRoleController()
            : base(new Domain.Services.FactoryService().CreateUserInRoleService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}