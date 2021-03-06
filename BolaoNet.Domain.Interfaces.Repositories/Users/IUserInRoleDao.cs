﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Users
{
    public interface IUserInRoleDao : Base.IGenericDao<Entities.Users.UserInRole>
    {
        IList<Entities.Users.Role> GetRolesInUser(string currentUserName, Entities.Users.User user);
        IList<Entities.Users.User> GetUsersInRole(string currentUserName, Entities.Users.Role role);
    }
}
