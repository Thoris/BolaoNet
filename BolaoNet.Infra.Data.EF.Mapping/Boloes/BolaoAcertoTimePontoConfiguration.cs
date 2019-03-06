using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoAcertoTimePontoConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoAcertoTimePonto>
    {
        
        #region Constructors/Destructors

        public BolaoAcertoTimePontoConfiguration()
        {
            ToTable("BoloesAcertoTimePontos");

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);


            Property(c => c.NomeCampeonato)
                .HasMaxLength(Campeonatos.CampeonatoConfiguration.NomeLen);

        }

        #endregion

    }
}
