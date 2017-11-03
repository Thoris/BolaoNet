using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Users
{
    public class RoleConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Users.Role>
    {

        #region Constants

        public const int NomeLen = 150;

        #endregion

        #region Constructors/Destructors

        public RoleConfiguration()
        {
            ToTable("Roles");

            Property(c => c.Descricao)
                .HasMaxLength(255);

            Property(c => c.RoleName)
                .HasMaxLength(NomeLen);



        }

        #endregion
    }
}
