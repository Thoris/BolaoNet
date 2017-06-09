using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Users
{
    public class RoleRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Users.Role>, Domain.Interfaces.Repositories.Users.IRoleDao
    {
        
        #region Constructors/Destructors

        public RoleRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
