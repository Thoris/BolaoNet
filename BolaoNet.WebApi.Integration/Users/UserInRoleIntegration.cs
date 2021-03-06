﻿using BolaoNet.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Users
{
    public class UserInRoleIntegration :
        Base.GenericIntegration<Domain.Entities.Users.UserInRole>, 
        Domain.Interfaces.Services.Users.IUserInRoleService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "UserInRole";

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="UserInRoleIntegration" />.
        /// </summary>
        /// <param name="url">Url para chamada dos métodos de integração.</param>
        public UserInRoleIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region IUserInRoleService members

        public IList<Domain.Entities.Users.Role> GetRolesInUser(Domain.Entities.Users.User user)
        {
            return base.HttpPostApi<IList<Domain.Entities.Users.Role>>(
              new Dictionary<string, string>(), user, "GetRolesInUser");
        }

        public IList<User> GetUsersInRole(Role role)
        {
            return base.HttpPostApi<IList<Domain.Entities.Users.User>>(
              new Dictionary<string, string>(), role, "GetUsersInRole");
        }

        #endregion
    }
}
