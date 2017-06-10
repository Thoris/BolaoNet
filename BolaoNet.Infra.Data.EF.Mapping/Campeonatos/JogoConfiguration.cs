using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Campeonatos
{
    public class JogoConfiguration : 
        Base.BaseConfiguration<Domain.Entities.Campeonatos.Jogo>
    {
        
        #region Constructors/Destructors

        public JogoConfiguration()
        {

        }

        #endregion
    }
}
