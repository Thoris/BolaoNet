using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoRegraConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoRegra>
    {
        
        #region Constructors/Destructors

        public BolaoRegraConfiguration()
        {
            ToTable("BoloesRegras");

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);


            Property(c => c.Descricao)
                .HasMaxLength(255);


        }

        #endregion
    }
}
