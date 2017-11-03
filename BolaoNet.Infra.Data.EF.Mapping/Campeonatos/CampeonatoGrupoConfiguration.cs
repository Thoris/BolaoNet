using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Campeonatos
{
    public class CampeonatoGrupoConfiguration : 
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Campeonatos.CampeonatoGrupo>
    {
        #region Constants 

        public const int NomeLen = 20;

        #endregion

        #region Constructors/Destructors

        public CampeonatoGrupoConfiguration()
        {
            ToTable("CampeonatosGrupos");

            Property(c => c.Descricao)
                .HasMaxLength(255);

            Property(c => c.Nome)
                .HasMaxLength(NomeLen);

            Property(c => c.NomeCampeonato)
                .HasMaxLength(CampeonatoConfiguration.NomeLen);

        }

        #endregion
    }
}
