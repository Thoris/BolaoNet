using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Users
{
    public interface IUserDao : Base.IGenericDao<Entities.Users.User>
    {
        IList<Entities.Users.User> SearchByUserNameEmail(string currentUserName, string userName, string email);
    }
}
