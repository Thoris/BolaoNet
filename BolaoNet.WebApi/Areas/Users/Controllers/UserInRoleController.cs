using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

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
        private Domain.Interfaces.Services.Users.IUserInRoleService Service
        {
            get { return (Domain.Interfaces.Services.Users.IUserInRoleService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public UserInRoleController()
        //    : base(new Domain.Services.FactoryService(null).CreateUserInRoleService())
        //{

        //}
        public UserInRoleController(Domain.Interfaces.Services.Users.IUserInRoleService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IUserInRoleService members

        [HttpPost]
        public IList<Domain.Entities.Users.Role> GetRolesInUser(Domain.Entities.Users.User user)
        {
            return Service.GetRolesInUser(user);
        }

        #endregion
    }
}