using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace BolaoNet.Infra.Data.EF.Mapping.Base
{
    public abstract class BaseConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        #region Constructors/Destructors()

        public BaseConfiguration()
        {

        }

        #endregion
    }
}
