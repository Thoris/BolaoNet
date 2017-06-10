using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoConfiguration : 
        Base.BaseConfiguration<Domain.Entities.Boloes.Bolao>
    {        
        #region Constructors/Destructors

        public BolaoConfiguration()
        {

        }

        #endregion

    }
}
