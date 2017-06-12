using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Users
{
    public class UserConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Users.User>
    {
        
        #region Constructors/Destructors

        public UserConfiguration()
        {

        }

        #endregion
    }
}
