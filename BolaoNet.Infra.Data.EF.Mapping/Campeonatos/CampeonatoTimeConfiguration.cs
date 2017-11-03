using BolaoNet.Infra.Data.EF.Mapping.DadosBasicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Campeonatos
{
    public class CampeonatoTimeConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Campeonatos.CampeonatoTime>
    {
        
        #region Constructors/Destructors

        public CampeonatoTimeConfiguration()
        {
            ToTable("CampeonatosTimes");

            Property(c => c.NomeCampeonato)
                .HasMaxLength(CampeonatoConfiguration.NomeLen);

            Property(c => c.NomeTime)
                .HasMaxLength(TimeConfiguration.NomeLen);

        }

        #endregion
    }
}
