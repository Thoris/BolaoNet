using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoPontuacaoConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoPontuacao>
    {
        
        #region Constructors/Destructors

        public BolaoPontuacaoConfiguration()
        {
            ToTable("BoloesPontuacao");

            Property(c => c.BackColorName)
                .HasMaxLength(50);

            Property(c => c.ForeColorName)
                .HasMaxLength(50);

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);

            Property(c => c.Titulo)
                .HasMaxLength(150);

        }

        #endregion
    }
}
