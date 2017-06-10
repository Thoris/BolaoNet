using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class JogoUsuarioConfiguration :
        Base.BaseConfiguration<Domain.Entities.Boloes.JogoUsuario>
    {
        
        #region Constructors/Destructors

        public JogoUsuarioConfiguration()
        {

        }

        #endregion
    }
}
