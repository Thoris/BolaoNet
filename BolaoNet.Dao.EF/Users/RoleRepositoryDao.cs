using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Users
{
    public class RoleRepositoryDao : 
        Base.BaseRepositoryDao<Entities.Users.Role>, Dao.Users.IRoleDao
    {
        
        #region Constructors/Destructors

        public RoleRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}
