using System.Collections.Generic;

namespace BolaoNet.Domain.Interfaces.Services.Users
{
    public interface IUserInRoleService
        : Base.IGenericService<Entities.Users.UserInRole>
    {

        IList<Entities.Users.Role> GetRolesInUser(Entities.Users.User user);
        IList<Entities.Users.User> GetUsersInRole(Entities.Users.Role role);

    }
}
