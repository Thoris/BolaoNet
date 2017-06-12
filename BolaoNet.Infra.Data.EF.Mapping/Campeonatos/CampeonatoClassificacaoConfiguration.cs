using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Campeonatos
{
    public class CampeonatoClassificacaoConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Campeonatos.CampeonatoClassificacao>
    {        
        #region Constructors/Destructors

        public CampeonatoClassificacaoConfiguration()
        {

        }

        #endregion

    }
}
