using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Users.Controllers
{
    public class UserController:
        GenericApiController<Entities.Users.User>, Business.Interfaces.Users.IUserBO 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Business.Interfaces.Users.IUserBO Dao
        {
            get { return (Business.Interfaces.Users.IUserBO)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public UserController()
            : base ( new Business.FactoryBO().CreateUserBO())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}