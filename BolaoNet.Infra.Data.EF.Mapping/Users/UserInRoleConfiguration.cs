using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Users
{
    public class UserInRoleConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Users.UserInRole>
    {
        
        #region Constructors/Destructors

        public UserInRoleConfiguration()
        {

            ToTable("UserInRole");

            Property(c => c.RoleName)
                .HasMaxLength(RoleConfiguration.NomeLen);

            Property(c => c.UserName)
                .HasMaxLength(UserConfiguration.NomeLen);



        }

        #endregion
    }
}
