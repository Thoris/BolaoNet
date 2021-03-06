﻿using BolaoNet.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Users
{
    public class UserInRoleRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Users.UserInRole>, 
        Domain.Interfaces.Repositories.Users.IUserInRoleDao
    {
        
        #region Constructors/Destructors

        public UserInRoleRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IUserInRoleDao members

        public IList<Domain.Entities.Users.Role> GetRolesInUser(string currentUserName, Domain.Entities.Users.User user)
        {
            var x =
            from r in base.DataContext.Roles
            join ur in base.DataContext.UserInRole
              on r.RoleName equals ur.RoleName
             where string.Compare (ur.UserName, user.UserName) == 0
            select r;

            return x.ToList<Domain.Entities.Users.Role>();
        }

        public IList<User> GetUsersInRole(string currentUserName, Role role)
        {
            var x =
            from r in base.DataContext.Usuarios
            join ur in base.DataContext.UserInRole
              on r.UserName equals ur.UserName
            where string.Compare(ur.RoleName, role.RoleName) == 0
            select r;

            return x.ToList<Domain.Entities.Users.User>();
        }

        #endregion
    }
}
