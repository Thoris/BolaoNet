using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoPremiacaoConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoPremiacao>
    {
        
        #region Constructors/Destructors

        public BolaoPremiacaoConfiguration()
        {
            ToTable("BoloesPremiacao");
             

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);

        }

        #endregion

    }
}
