﻿using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Users.Controllers
{
    public class RoleController :
        GenericApiController<Domain.Entities.Users.Role>, Domain.Interfaces.Services.Users.IRoleService 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Users.IRoleService Dao
        {
            get { return (Domain.Interfaces.Services.Users.IRoleService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public RoleController()
            : base(new Domain.Services.FactoryService().CreateRoleService())
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}