using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoCriterioPontosTimesConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoCriterioPontosTimes>
    {
        
        #region Constructors/Destructors

        public BolaoCriterioPontosTimesConfiguration()
        {
            ToTable("BoloesCriteriosPontosTimes");

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);


            Property(c => c.NomeTime)
                .HasMaxLength(DadosBasicos.TimeConfiguration.NomeLen);

        }

        #endregion
    }
}
