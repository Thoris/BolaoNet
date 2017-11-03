using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Boloes
{
    public class BolaoPontoRodadaConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Boloes.BolaoPontoRodada>
    {
        
        #region Constructors/Destructors

        public BolaoPontoRodadaConfiguration()
        {
            ToTable("BoloesPontosRodadas");

            Property(c => c.NomeBolao)
                .HasMaxLength(BolaoConfiguration.NomeLen);


            Property(c => c.NomeCampeonato)
                .HasMaxLength(Campeonatos.CampeonatoConfiguration.NomeLen);

            Property(c => c.NomeFase)
                .HasMaxLength(Campeonatos.CampeonatoFaseConfiguration.NomeLen);

            Property(c => c.NomeGrupo)
                .HasMaxLength(Campeonatos.CampeonatoGrupoConfiguration.NomeLen);

            Property(c => c.Titulo)
                .HasMaxLength(150);






        }

        #endregion
    }
}
