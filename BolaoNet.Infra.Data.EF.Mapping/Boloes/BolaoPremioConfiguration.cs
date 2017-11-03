using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoPremioConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoPremio>
    {
        
        #region Constructors/Destructors

        public BolaoPremioConfiguration()
        {
            ToTable("BoloesPremios");

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);


            Property(c => c.BackColorName)
                .HasMaxLength(30);

            Property(c => c.ForeColorName)
                .HasMaxLength(30);

            Property(c => c.Titulo)
                .HasMaxLength(150);

        }

        #endregion
    }
}
