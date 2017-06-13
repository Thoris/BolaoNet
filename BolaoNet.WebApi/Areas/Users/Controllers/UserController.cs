using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Users.Controllers
{
    public class UserController:
        GenericApiController<Domain.Entities.Users.User>, Domain.Interfaces.Services.Users.IUserService 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Users.IUserService Service
        {
            get { return (Domain.Interfaces.Services.Users.IUserService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public UserController()
            : base(new Domain.Services.FactoryService(null).CreateUserService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}