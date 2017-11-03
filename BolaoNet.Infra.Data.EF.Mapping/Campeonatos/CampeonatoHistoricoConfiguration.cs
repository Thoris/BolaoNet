using BolaoNet.Infra.Data.EF.Mapping.DadosBasicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Campeonatos
{
    public class CampeonatoHistoricoConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Campeonatos.CampeonatoHistorico>
    {
        
        #region Constructors/Destructors

        public CampeonatoHistoricoConfiguration()
        {
            ToTable("CampeonatosHistorico");

            Property(c => c.NomeCampeonato)
                .HasMaxLength(CampeonatoConfiguration.NomeLen);

            Property(c => c.NomeTimeCampeao)
                .HasMaxLength(TimeConfiguration.NomeLen);

            Property(c => c.NomeTimeTerceiro)
                .HasMaxLength(TimeConfiguration.NomeLen);

            Property(c => c.NomeTimeVice)
                .HasMaxLength(TimeConfiguration.NomeLen);

            Property(c => c.Sede)
                .HasMaxLength(100);
        }

        #endregion
    }
}
