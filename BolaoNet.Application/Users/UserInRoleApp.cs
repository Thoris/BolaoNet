﻿using System.Collections.Generic;

namespace BolaoNet.Application.Users
{
    public class UserInRoleApp :
        Base.GenericApp<Domain.Entities.Users.UserInRole>,
        Application.Interfaces.Users.IUserInRoleApp
    {

        #region Properties

        private Domain.Interfaces.Services.Users.IUserInRoleService Service
        {
            get { return (Domain.Interfaces.Services.Users.IUserInRoleService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="UserInRoleApp" />.
        /// </summary>
        public UserInRoleApp(Domain.Interfaces.Services.Users.IUserInRoleService service)
            : base (service)
        {

        }

        #endregion

        #region IUserInRoleApp members

        public IList<Domain.Entities.Users.Role> GetRolesInUser(Domain.Entities.Users.User user)
        {
            return Service.GetRolesInUser(user);
        }
        public IList<Domain.Entities.Users.User> GetUsersInRole(Domain.Entities.Users.Role role)
        {
            return Service.GetUsersInRole(role);
        }

        #endregion
    }
}
